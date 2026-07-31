<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EnrollNewSubject.aspx.cs" Inherits="MasterPage_EnrollNewSubject" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" /><link rel="stylesheet" type="text/css" href="../css/main.css" />
    <title>Clinsoft | Enroll Subject</title>
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
    
    <script type="text/javascript">
        function Confirm() {
            var validated = Page_ClientValidate('ENS');
            if (validated) {
                var confirm_value = document.createElement("INPUT");

                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Do you want to enroll new subject?")) {
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
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            //$('#ContentPlaceHolder2_alert_container').append('<div id="alert_div" class="notify-alert alert alert-info animated fadeInDown" class="alert fade in ' + cssclass + '"><a href="#" class="Close" data-dismiss="alert" aria-label="Close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
            $('#ContentPlaceHolder2_alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="Close" data-dismiss="alert" aria-label="Close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
            $(document).ready(function () {
                $('#<%=alert_container.ClientID%>').fadeOut(5000, function () {
                    $(this).html(""); //reset label after fadeout
                });
            });
        }

    </script>
    <script type="text/javascript">
        function upper(ustr) {
            var str = ustr.value;
            ustr.value = str.toUpperCase();
        }

        function lower(ustr) {
            var str = ustr.value;
            ustr.value = str.toLowerCase();
        }
    </script>
    <script type="text/javascript">
    function Validate(event) {
        var regex = new RegExp("^[a-z--]");
        var key = String.fromCharCode(event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    }       
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="alert_container" class="messagealert" runat="server">
    </div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div class="wrapper">

        <div class="content-wrapper">
            <div class="page-title">
                <div>
                    <h1><i class="fa fa-edit"></i>Enroll New Subject</h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Data Entry</li>
                        <li>Enroll New Subject</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="row">
                            <div class="form-horizontal">

                                <div class="form-group">
                                    <label class="control-label col-md-3">
                                        Subject Number:<asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                            CssClass="Validators" Display="None" runat="server" ErrorMessage="Please mention Subject Number" ControlToValidate="TextBoxSUBNUM" ValidationGroup="ENS" ForeColor="#FF3300" Font-Size="Large" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </label>
                                    &nbsp;<div class="col-md-8">
                                        <asp:TextBox ID="TextBoxSUBNUM" class="form-control col-md-8" onkeypress="return isNumberKey(event)" ReadOnly="true"  runat="server" ValidationGroup="ENS" placeholder="Subject Number"></asp:TextBox>
                                    </div>
                                </div>
                               
                                <div class="form-group">
                                    <label class="control-label col-md-3">
                                        Subject Initial:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            CssClass="Validators" Display="None" ErrorMessage="Please mention Subject Initial" ControlToValidate="TextBoxSUBINI" ValidationGroup="ENS" ForeColor="#FF3300" Font-Size="Large" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </label>
                                    &nbsp;<div class="col-md-8">
                                        <asp:TextBox ID="TextBoxSUBINI" class="form-control col-md-8" onkeyup="upper(this)" pks
                                            ValidationGroup="ENS" MaxLength="3" runat="server" placeholder="Subject Initial"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3">
                                        Site Number:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                            CssClass="Validators" Display="None" ControlToValidate="TextBoxSITENUM" ValidationGroup="ENS" InitialValue="0" ForeColor="#FF3300"
                                            Font-Size="Large" SetFocusOnError="True">

                                        </asp:RequiredFieldValidator>
                                    </label>
                                    &nbsp;<div class="col-md-8">
                                        <asp:TextBox ID="TextBoxSITENUM" class="form-control col-md-8" runat="server" ReadOnly="true" ValidationGroup="ENS"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="card-footer">
                                    <div class="row">
                                        <div class="col-md-8 col-md-offset-3">
                                            
                                                <asp:ValidationSummary runat="server" ShowMessageBox="true" ValidationGroup="ENS" ShowSummary="false" />
                                            <asp:Button ID="Button1" class="btn btn-success icon-btn" runat="server" Text="Submit" ValidationGroup="ENS"  OnClick = "OnConfirm"  OnClientClick = "Confirm()" />
                                           <asp:Label ID="LabelSublock" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                               

                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- Javascripts-->
    <script src="../../js/jquery-2.1.4.min.js"></script>
    <script src="../../js/essential-plugins.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <%--<script src="js/plugins/pace.min.js"></script>--%>
    <script src="../../js/main.js"></script>
    <script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                for (var i in Page_Validators) {
                    try {
                        var control = document.getElementById(Page_Validators[i].controltovalidate);
                        if (!Page_Validators[i].isvalid) {
                            control.className = "ErrorControl";
                        } else {
                            control.className = "";
                        }
                    } catch (e) { }
                }
                return false;
            }
            return true;
        }
    </script>
</asp:Content>

