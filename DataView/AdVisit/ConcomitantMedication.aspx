<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConcomitantMedication.aspx.cs" Inherits="DataView_AdVisit_ConcomitantMedication" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | DataView | Concomitant Medication | Prior/Concomitant Medication Form</title>
     <link href="../../css/calender.css" rel="stylesheet" />
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
                        <asp:Label runat="server" ID="lblPage">Prior/Concomitant Medication Form</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>DataView</li>
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
                                                <asp:Label ID="lblCONMEDNO" runat="server">Serial Number</asp:Label>
                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxCONMEDNO" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC" ReadOnly="True"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Event No not correct" ControlToValidate="TextBoxCONMEDNO"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td align="center" class="auto-style2">
                                                <asp:ImageButton ID="ImageQueryCONMEDNO" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCONMEDNO_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="auto-style2">
                                                <asp:Label ID="lblCMBRNDNM" runat="server">Generic name of the drug (Brand Name)</asp:Label>
                                            </td>
                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxCMBRNDNM" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please fill Generic name of the drug (Brand Name)" ControlToValidate="TextBoxCMBRNDNM"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="center" class="auto-style2">
                                                <asp:ImageButton ID="ImageQueryCMBRNDNM" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMBRNDNM_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="auto-style2">
                                                <asp:Label ID="lblCMINDI" runat="server">Indication</asp:Label>
                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxCMINDI" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please fill Indication" ControlToValidate="TextBoxCMINDI"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td align="center" class="auto-style2">
                                                <asp:ImageButton ID="ImageQueryCMINDI" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMINDI_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="auto-style2">
                                                <asp:Label ID="lblCMSTDT" runat="server">Start date</asp:Label>
                                            </td>
                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxCMSTDT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC" placeholder="DD-MMM-YYYY" onkeydown="return false"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please fill Start Date" ControlToValidate="TextBoxCMSTDT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                <asp:CalendarExtender ID="TextBoxCMSTDT_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxCMSTDT">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryCMSTDT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMSTDT_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="auto-style2">
                                                <asp:Label ID="lblCMENDT" runat="server">End Date</asp:Label>
                                            </td>
                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxCMENDT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC" placeholder="DD-MMM-YYYY" onkeydown="return false"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please fill End Date" ControlToValidate="TextBoxCMENDT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                <asp:CalendarExtender ID="TextBoxCMENDT_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxCMENDT">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryCMENDT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMENDT_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="auto-style2">
                                                <asp:Label ID="lblCMRUTE" runat="server">Route</asp:Label>
                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxCMRUTE" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please Mention Route" ControlToValidate="TextBoxCMRUTE"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td align="center" class="auto-style2">
                                                <asp:ImageButton ID="ImageQueryCMRUTE" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMRUTE_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="auto-style2">
                                                <asp:Label ID="lblCMDSE" runat="server">Dose</asp:Label>
                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxCMDSE" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please Mention Dose" ControlToValidate="TextBoxCMDSE"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td align="center" class="auto-style2">
                                                <asp:ImageButton ID="ImageQueryCMDSE" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMDSE_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="auto-style2">
                                                <asp:Label ID="lblCMFREQ" runat="server">Frenquency</asp:Label>
                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxCMFREQ" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please Mention Frenquency" ControlToValidate="TextBoxCMFREQ"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td align="center" class="auto-style2">
                                                <asp:ImageButton ID="ImageQueryCMFREQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMFREQ_Click" />
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

    <!-- Query Serial Number-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Serial Number" ID="RAISECONMEDNO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECONMEDNO" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCONMEDNO" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCONMEDNO" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCONMEDNO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCONMEDNO2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCONMEDNO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCONMEDNO3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Serial Number" ID="RAISECONMEDNOMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECONMEDNOMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Serial Number Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Serial Number" ID="RespondedCONMEDNO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedCONMEDNO" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedCONMEDNO" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedCONMEDNO" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCONMEDNO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedCONMEDNO2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCONMEDNO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedCONMEDNO3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Serial Number" ID="CLOSECONMEDNOMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSECONMEDNOMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSECONMEDNOMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Serial Number Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Serial Number" ID="CloseCONMEDNO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseCONMEDNO" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseCONMEDNO" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseCONMEDNO" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCONMEDNO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseCONMEDNO2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCONMEDNO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseCONMEDNO3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Serial Number" ID="LockCONMEDNO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockCONMEDNO" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockCONMEDNO" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockCONMEDNO" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCONMEDNO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockCONMEDNO2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCONMEDNO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockCONMEDNO3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCONMEDNOText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

    <!-- Query Generic name of the drug (Brand Name)-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Generic name of the drug (Brand Name)" ID="RAISECMBRNDNM" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMBRNDNM" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMBRNDNM" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMBRNDNM" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMBRNDNM2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMBRNDNM2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMBRNDNM3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMBRNDNM3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Generic name of the drug (Brand Name)" ID="RAISECMBRNDNMMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMBRNDNMMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Generic name of the drug (Brand Name) Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Generic name of the drug (Brand Name)" ID="RespondedCMBRNDNM" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedCMBRNDNM" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedCMBRNDNM" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedCMBRNDNM" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMBRNDNM2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedCMBRNDNM2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMBRNDNM3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedCMBRNDNM3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Generic name of the drug (Brand Name)" ID="CLOSECMBRNDNMMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSECMBRNDNMMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSECMBRNDNMMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Generic name of the drug (Brand Name) Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Generic name of the drug (Brand Name)" ID="CloseCMBRNDNM" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseCMBRNDNM" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseCMBRNDNM" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseCMBRNDNM" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMBRNDNM2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseCMBRNDNM2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMBRNDNM3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseCMBRNDNM3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Generic name of the drug (Brand Name)" ID="LockCMBRNDNM" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockCMBRNDNM" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockCMBRNDNM" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockCMBRNDNM" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMBRNDNM2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockCMBRNDNM2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMBRNDNM3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockCMBRNDNM3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMBRNDNMText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

    <!-- Query Indication-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Indication" ID="RAISECMINDI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMINDI" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMINDI" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMINDI" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMINDI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMINDI2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMINDI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMINDI3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Indication" ID="RAISECMINDIMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMINDIMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Indication Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Indication" ID="RespondedCMINDI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedCMINDI" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedCMINDI" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedCMINDI" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMINDI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedCMINDI2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMINDI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedCMINDI3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Indication" ID="CLOSECMINDIMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSECMINDIMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSECMINDIMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Indication Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Indication" ID="CloseCMINDI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseCMINDI" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseCMINDI" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseCMINDI" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMINDI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseCMINDI2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMINDI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseCMINDI3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Indication" ID="LockCMINDI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockCMINDI" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockCMINDI" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockCMINDI" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMINDI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockCMINDI2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMINDI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockCMINDI3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMINDIText" runat="server" BorderStyle="Solid">
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
        <ASPP:PopupPanel HeaderText="Raise Query: Start Date" ID="RAISECMSTDT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMSTDT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMSTDT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMSTDT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMSTDT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMSTDT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMSTDT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMSTDT3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Start Date" ID="RAISECMSTDTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMSTDTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Start Date Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Start Date" ID="RespondedCMSTDT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedCMSTDT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedCMSTDT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedCMSTDT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMSTDT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedCMSTDT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMSTDT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedCMSTDT3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Start Date" ID="CLOSECMSTDTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSECMSTDTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSECMSTDTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Start Date Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Start Date" ID="CloseCMSTDT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseCMSTDT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseCMSTDT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseCMSTDT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMSTDT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseCMSTDT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMSTDT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseCMSTDT3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Start Date" ID="LockCMSTDT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockCMSTDT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockCMSTDT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockCMSTDT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMSTDT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockCMSTDT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMSTDT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockCMSTDT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMSTDTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

    <!-- Query End Date-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: End Date" ID="RAISECMENDT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMENDT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMENDT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMENDT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMENDT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMENDT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMENDT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMENDT3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: End Date" ID="RAISECMENDTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMENDTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid">
                            Query has been Raised to the End Date Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: End Date" ID="RespondedCMENDT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedCMENDT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedCMENDT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedCMENDT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMENDT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedCMENDT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMENDT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedCMENDT3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: End Date" ID="CLOSECMENDTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSECMENDTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSECMENDTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the End Date Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: End Date" ID="CloseCMENDT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseCMENDT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseCMENDT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseCMENDT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMENDT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseCMENDT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMENDT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseCMENDT3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: End Date" ID="LockCMENDT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockCMENDT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockCMENDT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockCMENDT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMENDT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockCMENDT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMENDT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockCMENDT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMENDTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

    <!-- Query Route-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Route" ID="RAISECMRUTE" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMRUTE" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMRUTE" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMRUTE" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMRUTE2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMRUTE2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMRUTE3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMRUTE3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Route" ID="RAISECMRUTEMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMRUTEMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Route Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Route" ID="RespondedCMRUTE" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedCMRUTE" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedCMRUTE" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedCMRUTE" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMRUTE2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedCMRUTE2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMRUTE3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedCMRUTE3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Route" ID="CLOSECMRUTEMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSECMRUTEMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSECMRUTEMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Route Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Route" ID="CloseCMRUTE" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseCMRUTE" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseCMRUTE" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseCMRUTE" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMRUTE2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseCMRUTE2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMRUTE3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseCMRUTE3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Route" ID="LockCMRUTE" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockCMRUTE" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockCMRUTE" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockCMRUTE" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMRUTE2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockCMRUTE2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMRUTE3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockCMRUTE3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMRUTEText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

    <!-- Query Dose-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Dose" ID="RAISECMDSE" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMDSE" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMDSE" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMDSE" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMDSE2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMDSE2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMDSE3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMDSE3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Dose" ID="RAISECMDSEMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMDSEMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Dose Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Dose" ID="RespondedCMDSE" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedCMDSE" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedCMDSE" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedCMDSE" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMDSE2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedCMDSE2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMDSE3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedCMDSE3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Dose" ID="CLOSECMDSEMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSECMDSEMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSECMDSEMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Dose Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Dose" ID="CloseCMDSE" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseCMDSE" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseCMDSE" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseCMDSE" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMDSE2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseCMDSE2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMDSE3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseCMDSE3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Dose" ID="LockCMDSE" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockCMDSE" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockCMDSE" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockCMDSE" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMDSE2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockCMDSE2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMDSE3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockCMDSE3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMDSEText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

    <!-- Query Frequency-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Frequency" ID="RAISECMFREQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMFREQ" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMFREQ" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMFREQ" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMFREQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMFREQ2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseCMFREQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMFREQ3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Frequency" ID="RAISECMFREQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMFREQMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Frequency Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Frequency" ID="RespondedCMFREQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedCMFREQ" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedCMFREQ" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedCMFREQ" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMFREQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedCMFREQ2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedCMFREQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedCMFREQ3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Frequency" ID="CLOSECMFREQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSECMFREQMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSECMFREQMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Frequency Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Frequency" ID="CloseCMFREQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseCMFREQ" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseCMFREQ" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseCMFREQ" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMFREQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseCMFREQ2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseCMFREQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseCMFREQ3" runat="server"> </asp:Label>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Frequency" ID="LockCMFREQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockCMFREQ" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockCMFREQ" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockCMFREQ" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMFREQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockCMFREQ2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMFREQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockCMFREQ3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockCMFREQText" runat="server" BorderStyle="Solid">
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
