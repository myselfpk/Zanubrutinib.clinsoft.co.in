<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EtilogyOfHF.aspx.cs" Inherits="DataView_Visit1_EtilogyOfHF" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | DataView | Visit 1 | Etilogy Of HF</title>
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
                        <asp:Label runat="server" ID="lblPage">Etilogy Of HF</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>DataView</li>
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
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblHF1OPT">Ischemic Heart Disease</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkHF1OPT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF1OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF1OPT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblHF2OPT">Rheumatic heart disease</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkHF2OPT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF2OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF2OPT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblHF3OPT">Non rheumatic valvular heart disease</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkHF3OPT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF3OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF3OPT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblHF4OPT">Dilated cardiomyopathy</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkHF4OPT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF4OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF4OPT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblHF5OPT">Hypertrophic cardiomyopathy</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkHF5OPT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF5OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF5OPT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblHF6OPT">Restrictive cardiomyopathy</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkHF6OPT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF6OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF6OPT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblHF7OPT">Congenital heart disease</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkHF7OPT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF7OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF7OPT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblHF8OPT">Right heart failure</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkHF8OPT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF8OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF8OPT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblHF9OPT">Peripartum cardiomyopathy</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkHF9OPT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF9OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF9OPT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblHF10OPT">Myocarditis</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkHF10OPT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF10OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF10OPT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblHF11OPT">Infective endocarditis</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkHF11OPT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF11OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF11OPT_Click" />
                                            </td>
                                        </tr>



                                    </table>
                                    <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                        <colgroup>
                                            <col width="5%" />
                                            <col width="40%" />
                                            <col width="45%" />
                                            <col width="10%" />
                                        </colgroup>
                                        <tr class="section-header">
                                            <td colspan="4">If any other Etilogy Of HF are present, please provide details below:
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>1.</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblHF12OPT1">Others Etiology of HF</asp:Label>

                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxHF12OPT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF12OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF12OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>2.</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblHF13OPT1">Others Etiology of HF</asp:Label>

                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxHF13OPT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF13OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF13OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>3.</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblHF14OPT1">Others Etiology of HF</asp:Label>

                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxHF14OPT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF14OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF14OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>4.</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblHF15OPT1">Others Etiology of HF</asp:Label>

                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxHF15OPT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHF15OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHF15OPT_Click" /></td>

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

    <asp:Label runat="server" ID="lblHF12OPT" Text="Others Etiology of HF 1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblHF13OPT" Text="Others Etiology of HF 2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblHF14OPT" Text="Others Etiology of HF 3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblHF15OPT" Text="Others Etiology of HF 4" Visible="false"></asp:Label>

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

    <!-- Query Ischemic Heart Disease-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Ischemic Heart Disease" ID="RAISEHF1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF1OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF1OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF1OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF1OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Ischemic Heart Disease" ID="RAISEHF1OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF1OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Ischemic Heart Disease Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Ischemic Heart Disease" ID="RespondedHF1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF1OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF1OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF1OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF1OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Ischemic Heart Disease" ID="CLOSEHF1OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF1OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF1OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Ischemic Heart Disease Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Ischemic Heart Disease" ID="CloseHF1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF1OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF1OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF1OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF1OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Ischemic Heart Disease" ID="LockHF1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF1OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF1OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF1OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF1OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF1OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Rheumatic heart disease-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Rheumatic heart disease" ID="RAISEHF2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF2OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF2OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF2OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF2OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Rheumatic heart disease" ID="RAISEHF2OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF2OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Rheumatic heart disease Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Rheumatic heart disease" ID="RespondedHF2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF2OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF2OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF2OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF2OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Rheumatic heart disease" ID="CLOSEHF2OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF2OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF2OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Rheumatic heart disease Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Rheumatic heart disease" ID="CloseHF2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF2OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF2OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF2OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF2OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Rheumatic heart disease" ID="LockHF2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF2OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF2OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF2OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF2OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF2OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Non rheumatic valvular heart disease-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Non rheumatic valvular heart disease" ID="RAISEHF3OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF3OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF3OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF3OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF3OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF3OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF3OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF3OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Non rheumatic valvular heart disease" ID="RAISEHF3OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF3OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Non rheumatic valvular heart disease Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Non rheumatic valvular heart disease" ID="RespondedHF3OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF3OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF3OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF3OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF3OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF3OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF3OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF3OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Non rheumatic valvular heart disease" ID="CLOSEHF3OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF3OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF3OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Non rheumatic valvular heart disease Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Non rheumatic valvular heart disease" ID="CloseHF3OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF3OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF3OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF3OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF3OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF3OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF3OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF3OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Non rheumatic valvular heart disease" ID="LockHF3OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF3OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF3OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF3OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF3OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF3OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF3OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF3OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF3OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Dilated cardiomyopathy-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Dilated cardiomyopathy" ID="RAISEHF4OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF4OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF4OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF4OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF4OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF4OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF4OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF4OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Dilated cardiomyopathy" ID="RAISEHF4OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF4OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Dilated cardiomyopathy Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Dilated cardiomyopathy" ID="RespondedHF4OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF4OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF4OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF4OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF4OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF4OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF4OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF4OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Dilated cardiomyopathy" ID="CLOSEHF4OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF4OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF4OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Dilated cardiomyopathy Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Dilated cardiomyopathy" ID="CloseHF4OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF4OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF4OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF4OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF4OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF4OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF4OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF4OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Dilated cardiomyopathy" ID="LockHF4OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF4OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF4OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF4OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF4OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF4OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF4OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF4OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF4OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Hypertrophic cardiomyopathy-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Hypertrophic cardiomyopathy" ID="RAISEHF5OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF5OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF5OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF5OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF5OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF5OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF5OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF5OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Hypertrophic cardiomyopathy" ID="RAISEHF5OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF5OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Hypertrophic cardiomyopathy Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Hypertrophic cardiomyopathy" ID="RespondedHF5OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF5OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF5OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF5OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF5OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF5OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF5OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF5OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Hypertrophic cardiomyopathy" ID="CLOSEHF5OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF5OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF5OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Hypertrophic cardiomyopathy Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Hypertrophic cardiomyopathy" ID="CloseHF5OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF5OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF5OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF5OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF5OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF5OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF5OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF5OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Hypertrophic cardiomyopathy" ID="LockHF5OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF5OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF5OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF5OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF5OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF5OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF5OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF5OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF5OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Restrictive cardiomyopathy-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Restrictive cardiomyopathy" ID="RAISEHF6OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF6OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF6OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF6OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF6OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF6OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF6OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF6OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Restrictive cardiomyopathy" ID="RAISEHF6OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF6OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Restrictive cardiomyopathy Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Restrictive cardiomyopathy" ID="RespondedHF6OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF6OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF6OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF6OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF6OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF6OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF6OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF6OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Restrictive cardiomyopathy" ID="CLOSEHF6OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF6OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF6OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Restrictive cardiomyopathy Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Restrictive cardiomyopathy" ID="CloseHF6OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF6OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF6OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF6OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF6OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF6OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF6OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF6OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Restrictive cardiomyopathy" ID="LockHF6OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF6OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF6OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF6OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF6OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF6OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF6OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF6OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF6OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Congenital heart disease-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Congenital heart disease" ID="RAISEHF7OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF7OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF7OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF7OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF7OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF7OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF7OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF7OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Congenital heart disease" ID="RAISEHF7OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF7OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Congenital heart disease Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Congenital heart disease" ID="RespondedHF7OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF7OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF7OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF7OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF7OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF7OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF7OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF7OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Congenital heart disease" ID="CLOSEHF7OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF7OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF7OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Congenital heart disease Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Congenital heart disease" ID="CloseHF7OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF7OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF7OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF7OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF7OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF7OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF7OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF7OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Congenital heart disease" ID="LockHF7OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF7OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF7OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF7OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF7OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF7OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF7OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF7OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF7OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Right heart failure-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Right heart failure" ID="RAISEHF8OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF8OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF8OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF8OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF8OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF8OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF8OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF8OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Right heart failure" ID="RAISEHF8OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF8OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Right heart failure Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Right heart failure" ID="RespondedHF8OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF8OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF8OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF8OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF8OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF8OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF8OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF8OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Right heart failure" ID="CLOSEHF8OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF8OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF8OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Right heart failure Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Right heart failure" ID="CloseHF8OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF8OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF8OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF8OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF8OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF8OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF8OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF8OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Right heart failure" ID="LockHF8OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF8OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF8OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF8OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF8OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF8OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF8OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF8OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF8OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Peripartum cardiomyopathy-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Peripartum cardiomyopathy" ID="RAISEHF9OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF9OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF9OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF9OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF9OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF9OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF9OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF9OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Peripartum cardiomyopathy" ID="RAISEHF9OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF9OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel9" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Peripartum cardiomyopathy Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Peripartum cardiomyopathy" ID="RespondedHF9OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF9OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF9OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF9OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF9OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF9OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF9OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF9OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Peripartum cardiomyopathy" ID="CLOSEHF9OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF9OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF9OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Peripartum cardiomyopathy Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Peripartum cardiomyopathy" ID="CloseHF9OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF9OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF9OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF9OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF9OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF9OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF9OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF9OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Peripartum cardiomyopathy" ID="LockHF9OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF9OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF9OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF9OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF9OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF9OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF9OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF9OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF9OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Myocarditis-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Myocarditis" ID="RAISEHF10OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF10OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF10OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF10OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF10OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF10OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF10OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF10OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Myocarditis" ID="RAISEHF10OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF10OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel10" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Myocarditis Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Myocarditis" ID="RespondedHF10OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF10OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF10OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF10OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF10OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF10OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF10OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF10OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Myocarditis" ID="CLOSEHF10OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF10OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF10OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Myocarditis Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Myocarditis" ID="CloseHF10OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF10OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF10OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF10OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF10OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF10OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF10OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF10OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Myocarditis" ID="LockHF10OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF10OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF10OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF10OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF10OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF10OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF10OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF10OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF10OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Infective endocarditis-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Infective endocarditis" ID="RAISEHF11OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF11OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF11OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF11OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF11OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF11OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF11OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF11OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Infective endocarditis" ID="RAISEHF11OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF11OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel11" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Infective endocarditis Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Infective endocarditis" ID="RespondedHF11OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF11OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF11OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF11OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF11OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF11OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF11OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF11OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Infective endocarditis" ID="CLOSEHF11OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF11OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF11OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Infective endocarditis Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Infective endocarditis" ID="CloseHF11OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF11OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF11OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF11OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF11OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF11OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF11OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF11OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Infective endocarditis" ID="LockHF11OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF11OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF11OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF11OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF11OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF11OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF11OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF11OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF11OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Others Etiology of HF 1-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 1" ID="RAISEHF12OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF12OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF12OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF12OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF12OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF12OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF12OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF12OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 1" ID="RAISEHF12OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF12OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel12" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Others Etiology of HF 1 Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 1" ID="RespondedHF12OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF12OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF12OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF12OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF12OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF12OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF12OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF12OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                    
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 1" ID="CLOSEHF12OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF12OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF12OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Others Etiology of HF 1 Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 1" ID="CloseHF12OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF12OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF12OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF12OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF12OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF12OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF12OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF12OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 1" ID="LockHF12OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF12OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF12OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF12OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF12OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF12OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF12OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF12OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF12OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Others Etiology of HF 2-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 2" ID="RAISEHF13OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF13OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF13OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF13OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF13OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF13OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF13OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF13OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 2" ID="RAISEHF13OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF13OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel13" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Others Etiology of HF 2 Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 2" ID="RespondedHF13OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF13OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF13OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF13OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF13OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF13OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF13OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF13OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 2" ID="CLOSEHF13OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF13OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF13OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Others Etiology of HF 2 Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 2" ID="CloseHF13OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF13OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF13OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF13OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF13OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF13OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF13OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF13OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 2" ID="LockHF13OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF13OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF13OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF13OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF13OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF13OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF13OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF13OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF13OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Others Etiology of HF 3-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 3" ID="RAISEHF14OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF14OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF14OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF14OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF14OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF14OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF14OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF14OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 3" ID="RAISEHF14OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF14OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel14" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Others Etiology of HF 3 Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 3" ID="RespondedHF14OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF14OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF14OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF14OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF14OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF14OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF14OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF14OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 3" ID="CLOSEHF14OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF14OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF14OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Others Etiology of HF 3 Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 3" ID="CloseHF14OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF14OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF14OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF14OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF14OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF14OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF14OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF14OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 3" ID="LockHF14OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF14OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF14OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF14OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF14OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF14OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF14OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF14OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF14OPTText" runat="server" BorderStyle="Solid">
                            Query Cannot be Raised as Page is Locked
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Others Etiology of HF 4-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 4" ID="RAISEHF15OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF15OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHF15OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHF15OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF15OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHF15OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRaiseHF15OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHF15OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 4" ID="RAISEHF15OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHF15OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel15" runat="server" BorderStyle="Solid">
                            Query has been Raised to the Others Etiology of HF 4 Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 4" ID="RespondedHF15OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedHF15OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRespondedHF15OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRespondedHF15OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF15OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRespondedHF15OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelRespondedHF15OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRespondedHF15OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 4" ID="CLOSEHF15OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEHF15OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="PanelCLOSEHF15OPTMSG" runat="server" BorderStyle="Solid">
                            Query is Closed of the Others Etiology of HF 4 Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 4" ID="CloseHF15OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseHF15OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelCloseHF15OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelCloseHF15OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF15OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelCloseHF15OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelCloseHF15OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelCloseHF15OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Raise Query: Others Etiology of HF 4" ID="LockHF15OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockHF15OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelLockHF15OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelLockHF15OPT" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF15OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelLockHF15OPT2" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF15OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelLockHF15OPT3" runat="server"> </asp:Label>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="PanelLockHF15OPTText" runat="server" BorderStyle="Solid">
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
