<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ECG.aspx.cs" Inherits="Data_Entry_Visit3_ECG" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | Data Entry | Visit 3 | ECG</title>
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
                if (confirm("Do you want to Submit ECG page?")) {
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
            if (confirm("Do you want to Save ECG page?")) {

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
                        <asp:Label runat="server" ID="lblPage">ECG</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Data Entry</li>
                        <li>
                            <asp:LinkButton ID="lblVisit" runat="server" OnClick="lblVisit_Click">Visit 3</asp:LinkButton></li>
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
                                                <asp:Label runat="server" ID="lblECGPER">Was ECG performed?</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorECGPER" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Was ECG performed?"
                                                    ControlToValidate="RadioButtonListECGPER"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListECGPER" class="form-control" Height="45px" Width="90%" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListECGPER_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryECGPER" Height="25px" Width="25px" runat="server" OnClick="ImageQueryECGPER_Click" />
                                            </td>
                                        </tr>

                                        <tr class="auto-style2" id="hideECGRSN" runat="server" visible="false">
                                            <td>
                                                <asp:Label runat="server" ID="lblECGRSN">Reason</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Reason." ControlToValidate="TextBoxECGRSN"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>

                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxECGRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryECGRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryECGRSN_Click" /></td>
                                        </tr>
                                        <asp:Panel ID="hideECGPER" runat="server" Visible="false">
                                            <tr class="auto-style2">
                                                <td>
                                                    <asp:Label runat="server" ID="lblECGDT">Date of ECG</asp:Label>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="Please mention Date of ECG." ControlToValidate="TextBoxECGDT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>

                                                <td>

                                                    <asp:TextBox ID="TextBoxECGDT" runat="server" class="form-control" onkeydown="return false" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11"></asp:TextBox>
                                                    <asp:CalendarExtender ID="TextBoxECGDT_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                        TargetControlID="TextBoxECGDT">
                                                    </asp:CalendarExtender>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryECGDT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryECGDT_Click" /></td>

                                            </tr>
                                            <tr class="auto-style2">
                                                <td align="center" class="auto-style2">
                                                    <asp:Label runat="server" ID="lblECGTM">Time of ECG</asp:Label><br />

                                                    <asp:MaskedEditExtender ID="MaskedEditExtender3" TargetControlID="TextBoxECGTM"
                                                        Mask="99:99"
                                                        MaskType="Time"
                                                        CultureName="en-us"
                                                        MessageValidatorTip="true"
                                                        AcceptAMPM="false"
                                                        runat="server">
                                                    </asp:MaskedEditExtender>

                                                </td>

                                                <td align="center" class="auto-style2">

                                                    <asp:TextBox ID="TextBoxECGTM" runat="server" class="form-control" Height="45px" Width="90%" placeholder="[HH]:[MM]" ValidationGroup="IC" MaxLength="5"></asp:TextBox>

                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryECGTM" Height="25px" Width="25px" runat="server" OnClick="ImageQueryECGTM_Click" />
                                                </td>

                                            </tr>
                                            <tr class="auto-style2">
                                                <td>
                                                    <asp:Label runat="server" ID="lblECGNAB">Observation/ Other finding</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorECGNAB" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Observation/ Other finding"
                                                        ControlToValidate="RadioButtonListECGNAB"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListECGNAB" class="form-control" Height="45px" Width="90%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>Normal</asp:ListItem>
                                                        <asp:ListItem>Abnormal</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryECGNAB" Height="25px" Width="25px" runat="server" OnClick="ImageQueryECGNAB_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>
                                                    <asp:Label runat="server" ID="lblECG1OPT">QTc interval</asp:Label>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="Please mention QTc interval." ControlToValidate="TextBoxECG1OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>

                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxECG1OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryECG1OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryECG1OPT_Click" /></td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>
                                                    <asp:Label runat="server" ID="lblECG2OPT">PR interval</asp:Label>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="Please mention PR interval." ControlToValidate="TextBoxECG2OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>

                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxECG2OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryECG2OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryECG2OPT_Click" /></td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>
                                                    <asp:Label runat="server" ID="lblECG3OPT">QRS interval</asp:Label>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="Please mention QRS interval." ControlToValidate="TextBoxECG3OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>

                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxECG3OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryECG3OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryECG3OPT_Click" /></td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>
                                                    <asp:Label runat="server" ID="lblECG4OPT">QT/QTc</asp:Label>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="Please mention QT/QTc." ControlToValidate="TextBoxECG4OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>

                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxECG4OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryECG4OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryECG4OPT_Click" /></td>
                                            </tr>
                                        </asp:Panel>
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

    <!-- Query Was ECG performed?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Was ECG performed?:" ID="RAISEECGPER" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECGPER" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseECGPER" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseECGPER" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECGPER2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseECGPER2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECGPER3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseECGPER3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideECGPER" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondECGPER" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseECGPER" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseECGPER" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseECGPER" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseECGPER_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Was ECG performed?:" ID="RAISEECGPERMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECGPERMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Was ECG performed? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Reason: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Reason:" ID="RAISEECGRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECGRSN" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseECGRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseECGRSN" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECGRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseECGRSN2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECGRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseECGRSN3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideECGRSN" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondECGRSN" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseECGRSN" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseECGRSN" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseECGRSN" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseECGRSN_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Reason:" ID="RAISEECGRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECGRSNMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Reason Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Date of ECG: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Date of ECG:" ID="RAISEECGDT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECGDT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseECGDT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseECGDT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECGDT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseECGDT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECGDT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseECGDT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideECGDT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondECGDT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseECGDT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseECGDT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseECGDT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseECGDT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Date of ECG:" ID="RAISEECGDTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECGDTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Date of ECG Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Time of ECG: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Time of ECG:" ID="RAISEECGTM" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECGTM" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseECGTM" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseECGTM" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECGTM2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseECGTM2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECGTM3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseECGTM3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideECGTM" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondECGTM" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseECGTM" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseECGTM" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseECGTM" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseECGTM_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Time of ECG:" ID="RAISEECGTMMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECGTMMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Time of ECG Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Observation/ Other finding: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Observation/ Other finding:" ID="RAISEECGNAB" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECGNAB" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseECGNAB" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseECGNAB" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECGNAB2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseECGNAB2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECGNAB3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseECGNAB3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideECGNAB" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondECGNAB" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseECGNAB" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseECGNAB" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseECGNAB" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseECGNAB_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Observation/ Other finding:" ID="RAISEECGNABMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECGNABMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Observation/ Other finding Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query QTc interval: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: QTc interval:" ID="RAISEECG1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECG1OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseECG1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseECG1OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECG1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseECG1OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECG1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseECG1OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideECG1OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondECG1OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseECG1OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseECG1OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseECG1OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseECG1OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: QTc interval:" ID="RAISEECG1OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECG1OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid">
                            Query has been Responded of the QTc interval Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query PR interval: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: PR interval:" ID="RAISEECG2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECG2OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseECG2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseECG2OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECG2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseECG2OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECG2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseECG2OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideECG2OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondECG2OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseECG2OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseECG2OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseECG2OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseECG2OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: PR interval:" ID="RAISEECG2OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECG2OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid">
                            Query has been Responded of the PR interval Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query QRS interval: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: QRS interval:" ID="RAISEECG3OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECG3OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseECG3OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseECG3OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECG3OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseECG3OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECG3OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseECG3OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideECG3OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondECG3OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseECG3OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseECG3OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseECG3OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseECG3OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: QRS interval:" ID="RAISEECG3OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECG3OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid">
                            Query has been Responded of the QRS interval Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query QT/QTc: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: QT/QTc:" ID="RAISEECG4OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECG4OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseECG4OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseECG4OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECG4OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseECG4OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseECG4OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseECG4OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideECG4OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondECG4OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseECG4OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseECG4OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseECG4OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseECG4OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: QT/QTc:" ID="RAISEECG4OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEECG4OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel9" runat="server" BorderStyle="Solid">
                            Query has been Responded of the QT/QTc Field
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
