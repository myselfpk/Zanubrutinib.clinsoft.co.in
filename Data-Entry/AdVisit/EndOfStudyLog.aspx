<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EndOfStudyLog.aspx.cs" Inherits="Data_Entry_AdVisit_EndOfStudyLog" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | Data Entry | Withdrawal Form | End of Study Log</title>
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
            height: 50px;
            text-align: center;
            font-weight: normal;
        }

        .auto-style6 {
            height: 40px;
            text-align: left;
            font-weight: normal;
        }

        .auto-style8 {
            height: 35px;
            text-align: left;
            font-weight: normal;
            padding-left: 10px;
            padding-right: 10px;
            background-color: aliceblue;
        }

        .padding-Text {
            padding-left: 8px;
            padding-right: 8px;
            text-align: left;
        }
    </style>
    <script type="text/javascript">
        function Confirm() {
            var validated = Page_ClientValidate('IC');
            if (validated) {
                var confirm_value = document.createElement("INPUT");

                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Do you want to Submit End of Study Log Page?")) {
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
            if (confirm("Do you want to Save End of Study Log Page?")) {
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
                        <asp:Label runat="server" ID="lblPage">End of Study Log</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Data Entry</li>
                        <li>
                            <asp:LinkButton ID="lblVisit" runat="server" OnClick="lblVisit_Click">Withdrawal Form</asp:LinkButton></li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <asp:Panel ID="MainPanel" runat="server">
                            <div class="row">
                                <div class="text-center">

                                    <table style="" cellpadding="5px" cellspacing="0" class="CSSTableGenerator" border="solid" width="100%">
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
                                                <asp:Label runat="server" ID="lblEOSPER">Did the Subject complete the study?</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Did the Subject complete the study?" ControlToValidate="RadioButtonListEOSPER"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:DropDownList ID="RadioButtonListEOSPER" class="form-control" Height="45px" Width="70%" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListEOSPER_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="No"></asp:ListItem>
                                                </asp:DropDownList>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryEOSPER" Height="25px" Width="25px" runat="server" OnClick="ImageQueryEOSPER_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2" id="hideEOSDSC" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblEOSDSC">Date of study completion</asp:Label><br />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Date of study completion" ControlToValidate="TextBoxEOSDSC"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>

                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxEOSDSC" runat="server" class="form-control" Height="45px" Width="70%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>
                                                <asp:CalendarExtender ID="TextBoxEOSDSC_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxEOSDSC">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryEOSDSC" Height="25px" Width="25px" runat="server" OnClick="ImageQueryEOSDSC_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2" id="hideEOSDPMD" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblEOSDPMD">Date of pre-mature discontinuation/withdrawal</asp:Label><br />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Date of pre-mature discontinuation/withdrawal" ControlToValidate="TextBoxEOSDPMD"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>

                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxEOSDPMD" runat="server" class="form-control" Height="45px" Width="70%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>
                                                <asp:CalendarExtender ID="TextBoxEOSDPMD_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxEOSDPMD">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryEOSDPMD" Height="25px" Width="25px" runat="server" OnClick="ImageQueryEOSDPMD_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2" id="hideEOSRSN" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblEOSRSN">Please specify reason for Subject Withdrawal</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Please specify reason for Subject Withdrawal" ControlToValidate="RadioButtonListEOSRSN"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:DropDownList ID="RadioButtonListEOSRSN" class="form-control" Height="45px" Width="70%" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListEOSRSN_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Withdrawal of Consent </asp:ListItem>
                                                    <asp:ListItem>Treating Physician’s discretion</asp:ListItem>
                                                    <asp:ListItem>Pregnancy</asp:ListItem>
                                                    <asp:ListItem>Subject non-compliance as per treating physician’s discretion</asp:ListItem>
                                                    <asp:ListItem>Adverse Event</asp:ListItem>
                                                    <asp:ListItem>Disease Progression</asp:ListItem>
                                                    <asp:ListItem>Lost to Follow Up</asp:ListItem>
                                                    <asp:ListItem>Death</asp:ListItem>
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryEOSRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryEOSRSN_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2" id="hideEOSLFUDT" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblEOSLFUDT">Date of Last Contact</asp:Label><br />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Date of Last Contact" ControlToValidate="TextBoxEOSLFUDT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>

                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxEOSLFUDT" runat="server" class="form-control" Height="45px" Width="70%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>
                                                <asp:CalendarExtender ID="TextBoxEOSLFUDT_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxEOSLFUDT">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryEOSLFUDT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryEOSLFUDT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2" id="hideEOSDOD" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblEOSDOD">Date of Death</asp:Label><br />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Date of Death" ControlToValidate="TextBoxEOSDOD"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>

                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxEOSDOD" runat="server" class="form-control" Height="45px" Width="70%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>
                                                <asp:CalendarExtender ID="TextBoxEOSDOD_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxEOSDOD">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryEOSDOD" Height="25px" Width="25px" runat="server" OnClick="ImageQueryEOSDOD_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2" id="hideEOSSPRS" runat="server" visible="false">
                                                <td>
                                                    <asp:Label runat="server" ID="lblEOSSPRS">Specify Reasons</asp:Label><br />

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" CssClass="Validators" Display="None" ErrorMessage="Please mention Specify Reasons" ControlToValidate="TextBoxEOSSPRS"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>

                                                </td>

                                                <td>

                                                    <asp:TextBox ID="TextBoxEOSSPRS" TextMode="MultiLine" Rows="5" Columns="20" Style="resize: none;" runat="server" class="form-control" Height="60px" Width="70%" placeholder="" ValidationGroup="IC"></asp:TextBox>

                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryEOSSPRS" Height="25px" Width="25px" runat="server" OnClick="ImageQueryEOSSPRS_Click" /></td>

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
                                                <asp:TemplateField HeaderText="Reason for Premature Discontinuation for Change" HeaderStyle-Width="28%">
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

    <!--Query Is Did the Subject complete the study?-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Did the Subject complete the study?" ID="RAISEEOSPER" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSPER" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseEOSPER" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseEOSPER" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSPER2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseEOSPER2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSPER3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseEOSPER3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideEOSPER" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondEOSPER" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseEOSPER" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseEOSPER" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseEOSPER" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseEOSPER_Click" />


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
        <ASPP:PopupPanel HeaderText="Respond Query: Did the Subject complete the study?" ID="RAISEEOSPERMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSPERMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Did the Subject complete the study? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Is Date of study completion-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Date of study completion" ID="RAISEEOSDSC" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSDSC" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseEOSDSC" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseEOSDSC" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSDSC2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseEOSDSC2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSDSC3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseEOSDSC3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideEOSDSC" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondEOSDSC" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseEOSDSC" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseEOSDSC" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseEOSDSC" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseEOSDSC_Click" />


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
        <ASPP:PopupPanel HeaderText="Respond Query: Date of study completion" ID="RAISEEOSDSCMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSDSCMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Date of study completion Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Is Date of pre-mature discontinuation/withdrawal-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Date of pre-mature discontinuation/withdrawal" ID="RAISEEOSDPMD" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSDPMD" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseEOSDPMD" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseEOSDPMD" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSDPMD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseEOSDPMD2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSDPMD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseEOSDPMD3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideEOSDPMD" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondEOSDPMD" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseEOSDPMD" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseEOSDPMD" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseEOSDPMD" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseEOSDPMD_Click" />


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
        <ASPP:PopupPanel HeaderText="Respond Query: Date of pre-mature discontinuation/withdrawal" ID="RAISEEOSDPMDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSDPMDMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Date of pre-mature discontinuation/withdrawal Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Is Please specify reason for Subject Withdrawal-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Please specify reason for Subject Withdrawal" ID="RAISEEOSRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSRSN" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseEOSRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseEOSRSN" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseEOSRSN2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseEOSRSN3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideEOSRSN" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondEOSRSN" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseEOSRSN" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseEOSRSN" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseEOSRSN" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseEOSRSN_Click" />


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
        <ASPP:PopupPanel HeaderText="Respond Query: Please specify reason for Subject Withdrawal" ID="RAISEEOSRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSRSNMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Please specify reason for Subject Withdrawal Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Is Date of Last Contact-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Date of Last Contact" ID="RAISEEOSLFUDT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSLFUDT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseEOSLFUDT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseEOSLFUDT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSLFUDT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseEOSLFUDT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSLFUDT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseEOSLFUDT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideEOSLFUDT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondEOSLFUDT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseEOSLFUDT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseEOSLFUDT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseEOSLFUDT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseEOSLFUDT_Click" />


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
        <ASPP:PopupPanel HeaderText="Respond Query: Date of Last Contact" ID="RAISEEOSLFUDTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSLFUDTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Date of Last Contact Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Is Date of Death-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Date of Death" ID="RAISEEOSDOD" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSDOD" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseEOSDOD" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseEOSDOD" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSDOD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseEOSDOD2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSDOD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseEOSDOD3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideEOSDOD" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondEOSDOD" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseEOSDOD" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseEOSDOD" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseEOSDOD" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseEOSDOD_Click" />


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
        <ASPP:PopupPanel HeaderText="Respond Query: Date of Death" ID="RAISEEOSDODMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSDODMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Date of Death Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Is Specify Reasons-->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Specify Reasons" ID="RAISEEOSSPRS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSSPRS" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseEOSSPRS" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseEOSSPRS" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSSPRS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseEOSSPRS2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseEOSSPRS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseEOSSPRS3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideEOSSPRS" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondEOSSPRS" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseEOSSPRS" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseEOSSPRS" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseEOSSPRS" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseEOSSPRS_Click" />


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
        <ASPP:PopupPanel HeaderText="Respond Query: Specify Reasons" ID="RAISEEOSSPRSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEEOSSPRSMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Specify Reasons Field
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
