<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssignSite2User.aspx.cs" Inherits="Admin_AssignSite2User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link rel="stylesheet" type="text/css" href="../../css/main.css" />
     <title>Clinsoft | Assign site to user</title>
      <script type = "text/javascript">
         function Confirm() {
             var validated = Page_ClientValidate('ASTU');
             if (validated) {
                 var confirm_value = document.createElement("INPUT");

                 confirm_value.type = "hidden";
                 confirm_value.name = "confirm_value";
                 if (confirm("Do you want to Assign site to User?")) {
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
    <div class="wrapper">

        <div class="content-wrapper">
            <div class="page-title">
                <div>
                    <h1><i class="fa fa-building-o "> Assign Site To User</i></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Admin</li>
                        <li>Assign site to user</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="row">
                            <div class="form-horizontal">



                                <div class="form-group">
                                    <label class="control-label col-md-3">Center Number
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  InitialValue="0"  runat="server" ControlToValidate="DropDownList2" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="ASTU"></asp:RequiredFieldValidator>

                                    </label>

                                    <div class="col-md-8">
                                        <asp:DropDownList ID="DropDownList2" runat="server"
                                            class="form-control"  ValidationGroup="ASTU" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>

                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3">Center Address</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="TextBox2" runat="server" class="form-control col-md-8"  ValidationGroup="ASTU" Height="73px" ReadOnly="True" TextMode="MultiLine" BackColor="#CCCCCC" Font-Bold="True"></asp:TextBox>
                                    </div>
                                </div>

                                


                                <div class="form-group">
                                    <label class="control-label col-md-3">Name of Principal Investigator</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="TextBox4" runat="server" class="form-control col-md-8"  ValidationGroup="ASTU" ReadOnly="True" BackColor="#CCCCCC" Font-Bold="True"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3">Name of User<asp:RequiredFieldValidator ID="RequiredFieldValidator7"  InitialValue="0"  runat="server" ControlToValidate="DropDownList1" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="ASTU"></asp:RequiredFieldValidator>
</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="DropDownList1" runat="server"
                                            class="form-control"  ValidationGroup="ASTU">
                                            <asp:ListItem Value="0">Choose User Name...</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="card-footer">
                                    <div class="row">
                                        <div class="col-md-8 col-md-offset-3">
                                            <asp:Button class="btn btn-success icon-btn" ID="Button1" runat="server" Text="Submit" ValidationGroup="ASTU"  OnClick = "OnConfirm"  OnClientClick = "Confirm()" />
                                         
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