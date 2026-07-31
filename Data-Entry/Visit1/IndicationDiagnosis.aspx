<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IndicationDiagnosis.aspx.cs" Inherits="Data_Entry_Visit1_IndicationDiagnosis" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | Data Entry | Visit 1 | Indication Diagnosis</title>
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
                if (confirm("Do you want to Submit Indication Diagnosis page?")) {
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
            if (confirm("Do you want to Save Indication Diagnosis page?")) {

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
                        <asp:Label runat="server" ID="lblPage">Indication Diagnosis</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Data Entry</li>
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
                                    </table>


                                    <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                        <colgroup>
                                            <col width="45%" />
                                            <col width="45%" />
                                            <col width="10%" />
                                        </colgroup>
                                         <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDDIA">Diagnosis</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorIDDIA" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Diagnosis"
                                                    ControlToValidate="RadioButtonListIDDIA"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:DropDownList ID="RadioButtonListIDDIA" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListIDDIA_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>MCL</asp:ListItem>
                                                    <asp:ListItem>CLL</asp:ListItem>
                                                    <asp:ListItem>SLL</asp:ListItem>
                                                    <asp:ListItem>WM</asp:ListItem>
                                                    <asp:ListItem>MZL</asp:ListItem>
                                                    <asp:ListItem>FL</asp:ListItem>
                                                </asp:DropDownList>


                                            </td>


                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDDIA" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDDIA_Click" />
                                            </td>
                                        </tr>
                                         <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDDCT">Diagnosis confirmed through</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorIDDCT" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Diagnosis confirmed through"
                                                    ControlToValidate="RadioButtonListIDDCT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:DropDownList ID="RadioButtonListIDDCT" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Blood test</asp:ListItem>
                                                    <asp:ListItem>Biopsy</asp:ListItem>
                                                </asp:DropDownList>


                                            </td>


                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDDCT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDDCT_Click" />
                                            </td>
                                        </tr>
                                         <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDSF">Specify Finding</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Specify Finding" ControlToValidate="TextBoxIDSF"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                               
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxIDSF" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Specify Finding" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDSF" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDSF_Click" /></td>
                                        </tr>
                                         <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDDODYR">Duration of disease (Years)</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Duration of disease (Years)" ControlToValidate="TextBoxIDDODYR"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxIDDODYR" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration of disease (Years)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="2"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDDODYR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDDODYR_Click" /></td>
                                        </tr>
                                         <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDDODMT">Duration of disease (Months)</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Duration of disease (Months)" ControlToValidate="TextBoxIDDODMT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxIDDODMT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration of disease (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="2"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDDODMT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDDODMT_Click" /></td>
                                        </tr>
                                         <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDAOM">Any other malignancy</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorIDAOM" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Any other malignancy"
                                                    ControlToValidate="RadioButtonListIDAOM"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListIDAOM" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListIDAOM_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDAOM" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDAOM_Click" />
                                            </td>
                                        </tr>
                                         <tr class="auto-style2" id="hideIDAOMSPY" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDAOMSPY">Specify</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Specify" ControlToValidate="TextBoxIDAOMSPY"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxIDAOMSPY" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Specify" ValidationGroup="IC" ></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDAOMSPY" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDAOMSPY_Click" /></td>
                                        </tr>
                                         <tr class="auto-style2" id="hideIDAOMYR" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDAOMYR">Since Years</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Since Years" ControlToValidate="TextBoxIDAOMYR"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxIDAOMYR" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Since Years" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="2"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDAOMYR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDAOMYR_Click" /></td>
                                        </tr>
                                         <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDCT">Is PET-CT/whole body CT scan performed earlier (last 6 months)</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorIDCT" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Is PET-CT/whole body CT scan performed earlier (last 6 months)"
                                                    ControlToValidate="RadioButtonListIDCT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListIDCT" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListIDCT_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDCT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDCT_Click" />
                                            </td>
                                        </tr>
                                         <tr class="auto-style2" id="hideIDCTFIND" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDCTFIND">PET-CT/whole body CT scan Findings</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention PET-CT/whole body CT scan Findings" ControlToValidate="TextBoxIDCTFIND"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxIDCTFIND" runat="server" class="form-control" Height="45px" Width="350px" placeholder="PET-CT/whole body CT scan Findings" ValidationGroup="IC" ></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDCTFIND" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDCTFIND_Click" /></td>
                                        </tr>
                                         <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDXRAY">Is chest X-ray performed earlier (last 6 months)</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorIDXRAY" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Is chest X-ray performed earlier (last 6 months)"
                                                    ControlToValidate="RadioButtonListIDXRAY"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListIDXRAY" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListIDXRAY_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDXRAY" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDXRAY_Click" />
                                            </td>
                                        </tr>
                                         <tr class="auto-style2" id="hideIDXRAYFIND" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDXRAYFIND">chest X-ray Findings</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention chest X-ray Findings" ControlToValidate="TextBoxIDXRAYFIND"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxIDXRAYFIND" runat="server" class="form-control" Height="45px" Width="350px" placeholder="chest X-ray Findings" ValidationGroup="IC" ></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDXRAYFIND" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDXRAYFIND_Click" /></td>
                                        </tr>
                                         <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDUSG">Is USG abdomen performed earlier (last 6 months)</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorIDUSG" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Is USG abdomen performed earlier (last 6 months)"
                                                    ControlToValidate="RadioButtonListIDUSG"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListIDUSG" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListIDUSG_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDUSG" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDUSG_Click" />
                                            </td>
                                        </tr>
                                         <tr class="auto-style2" id="hideIDUSGFIND" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblIDUSGFIND">USG abdomen Findings</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention USG abdomen Findings" ControlToValidate="TextBoxIDUSGFIND"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxIDUSGFIND" runat="server" class="form-control" Height="45px" Width="350px" placeholder="USG abdomen Findings" ValidationGroup="IC" ></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryIDUSGFIND" Height="25px" Width="25px" runat="server" OnClick="ImageQueryIDUSGFIND_Click" /></td>
                                        </tr>
                                         <tr class="auto-style2" id="hideCSRSS" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblCSRSS">Rai Staging System</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCSRSS" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Rai Staging System"
                                                    ControlToValidate="RadioButtonListCSRSS"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListCSRSS" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Low Risk (Stage 0)</asp:ListItem>
                                                    <asp:ListItem>Intermediate Risk (Stages I)</asp:ListItem>
                                                    <asp:ListItem>Intermediate Risk (Stages II)</asp:ListItem>
                                                    <asp:ListItem>High Risk (Stages III)</asp:ListItem>
                                                    <asp:ListItem>High Risk (Stages IV)</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryCSRSS" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCSRSS_Click" />
                                            </td>
                                        </tr>
                                         <tr class="auto-style2" id="hideCSBSS" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblCSBSS">Binet Staging System</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCSBSS" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Binet Staging System"
                                                    ControlToValidate="RadioButtonListCSBSS"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListCSBSS" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>A Stage</asp:ListItem>
                                                    <asp:ListItem>B Stage</asp:ListItem>
                                                    <asp:ListItem>C Stage</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryCSBSS" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCSBSS_Click" />
                                            </td>
                                        </tr>
                                         <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblCSSH">Smoking history</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCSSH" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Smoking history"
                                                    ControlToValidate="RadioButtonListCSSH"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListCSSH" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListCSSH_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryCSSH" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCSSH_Click" />
                                            </td>
                                        </tr>
                                         <tr class="auto-style2" id="hideCSSHYR" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblCSSHYR">Smoking Since Years</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Smoking Since Years" ControlToValidate="TextBoxCSSHYR"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCSSHYR" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Smoking Since Years" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="2" ></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryCSSHYR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCSSHYR_Click" /></td>
                                        </tr>
                                         <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblCSAUH">Alcohol use history</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCSAUH" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Alcohol use history"
                                                    ControlToValidate="RadioButtonListCSAUH"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListCSAUH" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListCSAUH_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryCSAUH" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCSAUH_Click" />
                                            </td>
                                        </tr>
                                         <tr class="auto-style2" id="hideCSAUHYR" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblCSAUHYR">Alcohol Since Years</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Alcohol Since Years" ControlToValidate="TextBoxCSAUHYR"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCSAUHYR" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Alcohol Since Years" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="2" ></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryCSAUHYR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCSAUHYR_Click" /></td>
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

   <!-- Query Diagnosis: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Diagnosis:" ID="RAISEIDDIA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDDIA" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDDIA" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDDIA" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDDIA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDDIA2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDDIA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDDIA3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDDIA" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDDIA" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDDIA" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDDIA" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDDIA" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDDIA_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Diagnosis:" ID="RAISEIDDIAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDDIAMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Diagnosis Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Diagnosis confirmed through: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Diagnosis confirmed through:" ID="RAISEIDDCT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDDCT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDDCT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDDCT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDDCT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDDCT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDDCT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDDCT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDDCT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDDCT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDDCT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDDCT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDDCT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDDCT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Diagnosis confirmed through:" ID="RAISEIDDCTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDDCTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Diagnosis confirmed through Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Specify Finding: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Specify Finding:" ID="RAISEIDSF" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDSF" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDSF" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDSF" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDSF2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDSF2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDSF3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDSF3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDSF" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDSF" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDSF" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDSF" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDSF" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDSF_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Specify Finding:" ID="RAISEIDSFMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDSFMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Specify Finding Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Duration of disease (Years): -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Duration of disease (Years):" ID="RAISEIDDODYR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDDODYR" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDDODYR" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDDODYR" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDDODYR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDDODYR2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDDODYR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDDODYR3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDDODYR" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDDODYR" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDDODYR" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDDODYR" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDDODYR" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDDODYR_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Duration of disease (Years):" ID="RAISEIDDODYRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDDODYRMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Duration of disease (Years) Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Duration of disease (Months): -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Duration of disease (Months):" ID="RAISEIDDODMT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDDODMT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDDODMT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDDODMT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDDODMT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDDODMT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDDODMT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDDODMT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDDODMT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDDODMT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDDODMT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDDODMT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDDODMT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDDODMT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Duration of disease (Months):" ID="RAISEIDDODMTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDDODMTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Duration of disease (Months) Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Any other malignancy: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Any other malignancy:" ID="RAISEIDAOM" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDAOM" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDAOM" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDAOM" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDAOM2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDAOM2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDAOM3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDAOM3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDAOM" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDAOM" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDAOM" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDAOM" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDAOM" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDAOM_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Any other malignancy:" ID="RAISEIDAOMMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDAOMMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Any other malignancy Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Specify: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Specify:" ID="RAISEIDAOMSPY" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDAOMSPY" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDAOMSPY" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDAOMSPY" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDAOMSPY2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDAOMSPY2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDAOMSPY3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDAOMSPY3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDAOMSPY" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDAOMSPY" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDAOMSPY" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDAOMSPY" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDAOMSPY" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDAOMSPY_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Specify:" ID="RAISEIDAOMSPYMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDAOMSPYMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Specify Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Since Years: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Since Years:" ID="RAISEIDAOMYR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDAOMYR" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDAOMYR" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDAOMYR" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDAOMYR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDAOMYR2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDAOMYR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDAOMYR3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDAOMYR" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDAOMYR" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDAOMYR" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDAOMYR" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDAOMYR" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDAOMYR_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Since Years:" ID="RAISEIDAOMYRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDAOMYRMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Since Years Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Is PET-CT/whole body CT scan performed earlier (last 6 months): -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Is PET-CT/whole body CT scan performed earlier (last 6 months):" ID="RAISEIDCT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDCT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDCT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDCT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDCT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDCT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDCT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDCT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDCT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDCT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDCT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDCT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDCT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDCT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Is PET-CT/whole body CT scan performed earlier (last 6 months):" ID="RAISEIDCTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDCTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel9" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Is PET-CT/whole body CT scan performed earlier (last 6 months) Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query PET-CT/whole body CT scan Findings: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: PET-CT/whole body CT scan Findings:" ID="RAISEIDCTFIND" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDCTFIND" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDCTFIND" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDCTFIND" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDCTFIND2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDCTFIND2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDCTFIND3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDCTFIND3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDCTFIND" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDCTFIND" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDCTFIND" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDCTFIND" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDCTFIND" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDCTFIND_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: PET-CT/whole body CT scan Findings:" ID="RAISEIDCTFINDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDCTFINDMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel10" runat="server" BorderStyle="Solid">
                            Query has been Responded of the PET-CT/whole body CT scan Findings Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Is chest X-ray performed earlier (last 6 months): -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Is chest X-ray performed earlier (last 6 months):" ID="RAISEIDXRAY" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDXRAY" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDXRAY" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDXRAY" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDXRAY2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDXRAY2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDXRAY3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDXRAY3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDXRAY" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDXRAY" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDXRAY" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDXRAY" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDXRAY" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDXRAY_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Is chest X-ray performed earlier (last 6 months):" ID="RAISEIDXRAYMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDXRAYMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel11" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Is chest X-ray performed earlier (last 6 months) Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query chest X-ray Findings: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: chest X-ray Findings:" ID="RAISEIDXRAYFIND" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDXRAYFIND" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDXRAYFIND" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDXRAYFIND" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDXRAYFIND2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDXRAYFIND2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDXRAYFIND3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDXRAYFIND3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDXRAYFIND" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDXRAYFIND" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDXRAYFIND" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDXRAYFIND" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDXRAYFIND" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDXRAYFIND_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: chest X-ray Findings:" ID="RAISEIDXRAYFINDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDXRAYFINDMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel12" runat="server" BorderStyle="Solid">
                            Query has been Responded of the chest X-ray Findings Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Is USG abdomen performed earlier (last 6 months): -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Is USG abdomen performed earlier (last 6 months):" ID="RAISEIDUSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDUSG" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDUSG" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDUSG" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDUSG2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDUSG2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDUSG3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDUSG3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDUSG" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDUSG" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDUSG" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDUSG" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDUSG" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDUSG_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Is USG abdomen performed earlier (last 6 months):" ID="RAISEIDUSGMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDUSGMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel13" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Is USG abdomen performed earlier (last 6 months) Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query USG abdomen Findings: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: USG abdomen Findings:" ID="RAISEIDUSGFIND" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDUSGFIND" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseIDUSGFIND" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseIDUSGFIND" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDUSGFIND2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseIDUSGFIND2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseIDUSGFIND3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseIDUSGFIND3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideIDUSGFIND" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondIDUSGFIND" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseIDUSGFIND" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseIDUSGFIND" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseIDUSGFIND" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseIDUSGFIND_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: USG abdomen Findings:" ID="RAISEIDUSGFINDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEIDUSGFINDMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel14" runat="server" BorderStyle="Solid">
                            Query has been Responded of the USG abdomen Findings Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Rai Staging System: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Rai Staging System:" ID="RAISECSRSS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECSRSS" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCSRSS" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCSRSS" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCSRSS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCSRSS2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCSRSS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCSRSS3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCSRSS" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCSRSS" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseCSRSS" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCSRSS" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseCSRSS" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseCSRSS_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Rai Staging System:" ID="RAISECSRSSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECSRSSMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel15" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Rai Staging System Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Binet Staging System: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Binet Staging System:" ID="RAISECSBSS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECSBSS" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCSBSS" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCSBSS" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCSBSS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCSBSS2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCSBSS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCSBSS3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCSBSS" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCSBSS" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseCSBSS" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCSBSS" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseCSBSS" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseCSBSS_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Binet Staging System:" ID="RAISECSBSSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECSBSSMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel16" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Binet Staging System Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Smoking history: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Smoking history:" ID="RAISECSSH" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECSSH" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCSSH" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCSSH" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCSSH2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCSSH2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCSSH3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCSSH3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCSSH" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCSSH" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseCSSH" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCSSH" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseCSSH" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseCSSH_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Smoking history:" ID="RAISECSSHMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECSSHMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel17" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Smoking history Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Smoking Since Years: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Smoking Since Years:" ID="RAISECSSHYR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECSSHYR" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCSSHYR" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCSSHYR" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCSSHYR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCSSHYR2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCSSHYR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCSSHYR3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCSSHYR" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCSSHYR" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseCSSHYR" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCSSHYR" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseCSSHYR" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseCSSHYR_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Smoking Since Years:" ID="RAISECSSHYRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECSSHYRMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel18" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Smoking Since Years Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Alcohol use history: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Alcohol use history:" ID="RAISECSAUH" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECSAUH" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCSAUH" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCSAUH" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCSAUH2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCSAUH2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCSAUH3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCSAUH3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCSAUH" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCSAUH" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseCSAUH" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCSAUH" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseCSAUH" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseCSAUH_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Alcohol use history:" ID="RAISECSAUHMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECSAUHMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel19" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Alcohol use history Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Alcohol Since Years: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Alcohol Since Years:" ID="RAISECSAUHYR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECSAUHYR" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCSAUHYR" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCSAUHYR" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCSAUHYR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCSAUHYR2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCSAUHYR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCSAUHYR3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCSAUHYR" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCSAUHYR" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseCSAUHYR" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCSAUHYR" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseCSAUHYR" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseCSAUHYR_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Alcohol Since Years:" ID="RAISECSAUHYRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECSAUHYRMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel20" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Alcohol Since Years Field
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
