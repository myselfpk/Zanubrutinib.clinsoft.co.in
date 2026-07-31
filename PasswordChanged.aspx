<%@ Page Title="" Language="C#" MasterPageFile="~/ChangePassword.master" AutoEventWireup="true" CodeFile="PasswordChanged.aspx.cs" Inherits="PasswordChanged" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
        .auto-style1 {
            font-family: "Segoe UI";
            font-weight: normal;
            font-size: large;
            color: #9D9D9D;
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <div id="alert_container" class="messagealert" runat="server">
    </div>
    <div class="wrapper">

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
                                    
                                    <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Password Changed Successfully</h1>

                                </div>

                                
                                    <div class="form-group">
                                   <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style1">Your password is updated</span></h3>
                                </div>
                                


                                

                                

                                <div class="card-footer">
                                    <div class="row">
                                        <div class="col-md-8 col-md-offset-3">
                                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Button class="btn btn-success icon-btn" ID="btnSubmit" runat="server" Text="Login" OnClick="btnSubmit_Click" Font-Size="Large" Height="45px" Width="270px"/>
                                         
                                           
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

