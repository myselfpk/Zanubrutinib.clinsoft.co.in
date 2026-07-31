<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Admin_EnrolledSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" /><link rel="stylesheet" type="text/css" href="../css/main.css" />

     <title>Clinsoft | Change Password</title>
    <script type="text/javascript">
        function isNumberKey(evt) {
            //var e = evt || window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function ValidaTealpha(evt) {
            var keyCode = (evt.which) ? evt.which : evt.keyCode
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)

                return false;
            return true;
        }
    </script>


    <style type="text/css">
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
     <script type = "text/javascript">
         function Confirm() {
             var validated = Page_ClientValidate('CNU');
             if (validated) {
                 var confirm_value = document.createElement("INPUT");

                 confirm_value.type = "hidden";
                 confirm_value.name = "confirm_value";
                 if (confirm("Do you want to Change Password?")) {
                     confirm_value.value = "Yes";
                 } else {
                     confirm_value.value = "No";
                 }
                 document.forms[0].appendChild(confirm_value);
             }
             else
             {

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="alert_container" class="messagealert" runat="server">
    </div>
    <div class="wrapper" >

        <div class="content-wrapper">
            <div class="page-title">
                <div>
                    <h1>Change Password</h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>User</li>
                        <li>Change Password</li>
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
                                        Old Password:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox3" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="CNU"></asp:RequiredFieldValidator>
                                    </label>

                                    &nbsp;<div class="col-md-8">
                                        <asp:TextBox ID="TextBox3" runat="server"  TextMode="Password"  class="form-control" ValidationGroup="CNU" placeholder="Old Password"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3">New Password:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="CNU"></asp:RequiredFieldValidator>
                                   </label> <div class="col-md-8">
                                        <asp:TextBox ID="TextBox4" runat="server"  TextMode="Password" class="form-control col-md-8" ValidationGroup="CNU" placeholder="New Password"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationGroup="CNU" ID="Regex5" runat="server" ControlToValidate="TextBox4"
                                    ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"
                                    ErrorMessage="Minimum 6 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character"
                                    ForeColor="Red" BorderColor="Black" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                


                                <div class="form-group">
                                    <label class="control-label col-md-3">Confirm New Password:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox5" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="CNU"></asp:RequiredFieldValidator>
                                  </label>  <div class="col-md-8">
                                        <asp:TextBox ID="TextBox5" runat="server" class="form-control col-md-8" ValidationGroup="CNU" TextMode="Password" placeholder="Confirm New Password"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox4" ControlToValidate="TextBox5" ErrorMessage="The password and confirmation password do not match." ValidationGroup="ChangePassword" ForeColor="#FF3300"></asp:CompareValidator>

                                    </div>
                                </div>

                                

                                <div class="card-footer">
                                    <div class="row">
                                        <div class="col-md-8 col-md-offset-3">
                                              &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Button class="btn btn-success icon-btn" ID="btnSubmit" runat="server" Text="Save" ValidationGroup="CNU" OnClick = "OnConfirm"  OnClientClick = "Confirm()"/>
                                         
                                           
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
</asp:Content>

