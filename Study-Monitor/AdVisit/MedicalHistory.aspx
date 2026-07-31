<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MedicalHistory.aspx.cs" Inherits="Study_Monitor_AdVisit_MedicalHistory" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | Study Monitor | Medical History | Medical History Record</title>
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

        .auto-style8 {
            height: 40px;
            text-align: left;
            font-weight: normal;
            padding-left: 10px;
            padding-right: 10px;
            background-color: burlywood;
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
            var validated = Page_ClientValidate('IC');
            if (validated) {
                var confirm_value = document.createElement("INPUT");

                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Do you want to Lock Medical History Record page?")) {
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
            if (confirm("Do you want to SDV Medical History Record page?")) {

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
            if (confirm("Do you want to Unlocked Medical History Record page?")) {

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
                        <asp:Label runat="server" ID="lblPage">Medical History Record</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Study Monitor</li>
                        <li>
                            <asp:LinkButton ID="lblVisit" runat="server" OnClick="lblVisit_Click">Medical History</asp:LinkButton></li>
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
                                                <asp:Label ID="lblMSHSNO" runat="server">Medical History Serial No.</asp:Label>
                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxMSHSNO" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC" ReadOnly="True"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Event No not correct" ControlToValidate="TextBoxMSHSNO"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td align="center" class="auto-style2">
                                                <asp:ImageButton ID="ImageQueryMSHSNO" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMSHSNO_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="auto-style2">
                                                <asp:Label ID="lblMSHDESC" runat="server">Medical condition/ Surgery</asp:Label>
                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxMSHDESC" TextMode="MultiLine" runat="server" class="form-control" Height="60px" Width="350px" placeholder="" Rows="5" Columns="20" Style="resize: none;"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please fill Medical condition/ Surgery" ControlToValidate="TextBoxMSHDESC"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td align="center" class="auto-style2">
                                                <asp:ImageButton ID="ImageQueryMSHDESC" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMSHDESC_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="auto-style2">
                                                <asp:Label ID="lblMSHSD" runat="server">Start date</asp:Label>
                                            </td>
                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxMSHSD" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC" placeholder="DD-MMM-YYYY" onkeydown="return false" AutoPostBack="true" OnTextChanged="TextBoxMSHSD_TextChanged"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please fill Start Date" ControlToValidate="TextBoxMSHSD"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                <asp:CalendarExtender ID="TextBoxMSHSD_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxMSHSD">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMSHSD" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMSHSD_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="auto-style2">
                                                <asp:Label ID="lblMSHOG" runat="server">Medication Taken</asp:Label>
                                            </td>
                                            <td align="center" class="auto-style2">
                                                <asp:DropDownList ID="RadioButtonListMSHOG" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListMSHOG_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please mention Medication Taken"
                                                    CssClass="Validators" Display="None" ControlToValidate="RadioButtonListMSHOG"
                                                    ValidationGroup="IC" ForeColor="Red"></asp:RequiredFieldValidator>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMSHOG" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMSHOG_Click" />
                                            </td>
                                        </tr>
                                        <tr id="panelHide" runat="server" visible="false">
                                            <td align="center" class="auto-style2">
                                                <asp:Label ID="lblMSHED" runat="server">Stop Date</asp:Label>
                                            </td>
                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxMSHED" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC" placeholder="DD-MMM-YYYY" onkeydown="return false"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please fill Stop Date" ControlToValidate="TextBoxMSHED"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                <asp:CalendarExtender ID="TextBoxMSHED_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxMSHED">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMSHED" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMSHED_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="auto-style2">
                                                <asp:Label ID="lblMSHTM" runat="server">Is Medication Ongoing</asp:Label>
                                            </td>
                                            <td align="center" class="auto-style2">

                                                <asp:DropDownList ID="RadioButtonListMSHTM" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="select Is Medication Ongoing" ControlToValidate="RadioButtonListMSHTM"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="center" class="auto-style2">
                                                <asp:ImageButton ID="ImageQueryMSHTM" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMSHTM_Click" />
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

    <!-- Query Medical History Serial No.-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Medical History Serial No." ID="RAISEMSHSNO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMSHSNO" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMSHSNO" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMSHSNO" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMSHSNO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMSHSNO2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMSHSNO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMSHSNO3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMSHSNO"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMSHSNO" runat="server" Text="Raise Query" OnClick="QueryRaiseMSHSNO_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Medical History Serial No." ID="RAISEMSHSNOMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMSHSNOMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Medical History Serial No. Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Medical History Serial No." ID="RespondedMSHSNO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMSHSNO" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMSHSNO" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMSHSNO" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMSHSNO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMSHSNO2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMSHSNO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMSHSNO3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMSHSNOClose" runat="server" Text="Close Query"   OnClick="CloseQueryMSHSNO_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Medical History Serial No." ID="CLOSEMSHSNOMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMSHSNOMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMSHSNOMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Medical History Serial No. Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Medical History Serial No." ID="CloseMSHSNO" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMSHSNO" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMSHSNO" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMSHSNO" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMSHSNO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMSHSNO2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMSHSNO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMSHSNO3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMSHSNO" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMSHSNO_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Medical History Serial No." ID="LockMSHSNO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMSHSNO" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMSHSNO" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMSHSNO" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMSHSNO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMSHSNO2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMSHSNO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMSHSNO3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMSHSNOText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Medical condition/ Surgery-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Medical condition/ Surgery" ID="RAISEMSHDESC" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMSHDESC" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMSHDESC" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMSHDESC" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMSHDESC2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMSHDESC2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMSHDESC3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMSHDESC3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMSHDESC"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMSHDESC" runat="server" Text="Raise Query" OnClick="QueryRaiseMSHDESC_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Medical condition/ Surgery" ID="RAISEMSHDESCMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMSHDESCMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Medical condition/ Surgery Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Medical condition/ Surgery" ID="RespondedMSHDESC" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMSHDESC" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMSHDESC" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMSHDESC" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMSHDESC2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMSHDESC2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMSHDESC3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMSHDESC3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMSHDESCClose" runat="server" Text="Close Query"   OnClick="CloseQueryMSHDESC_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Medical condition/ Surgery" ID="CLOSEMSHDESCMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMSHDESCMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMSHDESCMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Medical condition/ Surgery Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Medical condition/ Surgery" ID="CloseMSHDESC" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMSHDESC" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMSHDESC" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMSHDESC" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMSHDESC2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMSHDESC2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMSHDESC3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMSHDESC3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMSHDESC" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMSHDESC_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Medical condition/ Surgery" ID="LockMSHDESC" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMSHDESC" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMSHDESC" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMSHDESC" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMSHDESC2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMSHDESC2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMSHDESC3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMSHDESC3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMSHDESCText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Start date-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Start date" ID="RAISEMSHSD" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMSHSD" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMSHSD" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMSHSD" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMSHSD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMSHSD2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMSHSD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMSHSD3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMSHSD"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMSHSD" runat="server" Text="Raise Query" OnClick="QueryRaiseMSHSD_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start date" ID="RAISEMSHSDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMSHSDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Start date Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Start date" ID="RespondedMSHSD" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMSHSD" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMSHSD" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMSHSD" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMSHSD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMSHSD2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMSHSD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMSHSD3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMSHSDClose" runat="server" Text="Close Query"   OnClick="CloseQueryMSHSD_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start date" ID="CLOSEMSHSDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMSHSDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMSHSDMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Start date Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Start date" ID="CloseMSHSD" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMSHSD" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMSHSD" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMSHSD" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMSHSD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMSHSD2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMSHSD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMSHSD3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMSHSD" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMSHSD_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start date" ID="LockMSHSD" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMSHSD" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMSHSD" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMSHSD" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMSHSD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMSHSD2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMSHSD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMSHSD3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMSHSDText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Medication Taken-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Medication Taken" ID="RAISEMSHOG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMSHOG" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMSHOG" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMSHOG" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMSHOG2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMSHOG2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMSHOG3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMSHOG3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMSHOG"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMSHOG" runat="server" Text="Raise Query" OnClick="QueryRaiseMSHOG_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Medication Taken" ID="RAISEMSHOGMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMSHOGMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Medication Taken Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Medication Taken" ID="RespondedMSHOG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMSHOG" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMSHOG" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMSHOG" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMSHOG2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMSHOG2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMSHOG3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMSHOG3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMSHOGClose" runat="server" Text="Close Query"   OnClick="CloseQueryMSHOG_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Medication Taken" ID="CLOSEMSHOGMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMSHOGMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMSHOGMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Medication Taken Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Medication Taken" ID="CloseMSHOG" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMSHOG" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMSHOG" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMSHOG" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMSHOG2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMSHOG2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMSHOG3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMSHOG3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMSHOG" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMSHOG_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Medication Taken" ID="LockMSHOG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMSHOG" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMSHOG" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMSHOG" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMSHOG2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMSHOG2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMSHOG3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMSHOG3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMSHOGText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: Stop Date" ID="RAISEMSHED" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMSHED" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMSHED" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMSHED" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMSHED2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMSHED2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMSHED3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMSHED3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMSHED"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMSHED" runat="server" Text="Raise Query" OnClick="QueryRaiseMSHED_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="RAISEMSHEDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMSHEDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Stop Date Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="RespondedMSHED" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMSHED" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMSHED" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMSHED" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMSHED2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMSHED2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMSHED3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMSHED3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMSHEDClose" runat="server" Text="Close Query"   OnClick="CloseQueryMSHED_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="CLOSEMSHEDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMSHEDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMSHEDMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Stop Date Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="CloseMSHED" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMSHED" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMSHED" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMSHED" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMSHED2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMSHED2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMSHED3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMSHED3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMSHED" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMSHED_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="LockMSHED" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMSHED" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMSHED" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMSHED" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMSHED2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMSHED2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMSHED3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMSHED3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMSHEDText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Medication Ongoing-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Medication Ongoing" ID="RAISEMSHTM" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMSHTM" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMSHTM" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMSHTM" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMSHTM2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMSHTM2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMSHTM3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMSHTM3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMSHTM"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMSHTM" runat="server" Text="Raise Query" OnClick="QueryRaiseMSHTM_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Medication Ongoing" ID="RAISEMSHTMMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMSHTMMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Medication Ongoing Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Medication Ongoing" ID="RespondedMSHTM" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMSHTM" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMSHTM" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMSHTM" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMSHTM2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMSHTM2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMSHTM3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMSHTM3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMSHTMClose" runat="server" Text="Close Query"   OnClick="CloseQueryMSHTM_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Medication Ongoing" ID="CLOSEMSHTMMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMSHTMMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMSHTMMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Medication Ongoing Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Medication Ongoing" ID="CloseMSHTM" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMSHTM" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMSHTM" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMSHTM" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMSHTM2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMSHTM2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMSHTM3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMSHTM3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMSHTM" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMSHTM_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Medication Ongoing" ID="LockMSHTM" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMSHTM" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMSHTM" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMSHTM" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMSHTM2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMSHTM2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMSHTM3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMSHTM3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMSHTMText" runat="server" BorderStyle="Solid" >
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
