<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateNewUser.aspx.cs" Inherits="Admin_EnrolledSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <title>Clinsoft | Create User</title>
    <script type = "text/javascript">
         function Confirm() {
             var validated = Page_ClientValidate('CNU');
             if (validated) {
                 var confirm_value = document.createElement("INPUT");

                 confirm_value.type = "hidden";
                 confirm_value.name = "confirm_value";
                 if (confirm("Do you want to Create new User?")) {
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
                    <h1><i class="fa fa-user"> Create New User</i></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Admin</li>
                        <li>Create New User</li>
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
                                        User Name:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="CNU"></asp:RequiredFieldValidator>
                                    </label>

                                    &nbsp;<div class="col-md-8">
                                        <asp:TextBox ID="TextBox1" runat="server" onKeyPress="return ValidaTealpha(event);" class="form-control" ValidationGroup="CNU" placeholder="User Name"></asp:TextBox>
                                    </div>
                                </div>
                                    <div>
                                                  <center><asp:Label ID="lblStatus" runat="server"></asp:Label></center>
                                                    </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Login ID<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox5" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="CNU"></asp:RequiredFieldValidator>
</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="TextBox5" runat="server" onchange="UserOrEmailAvailability()" class="form-control col-md-8" ValidationGroup="CNU" placeholder="Login ID"></asp:TextBox>

                                    </div>
                                  
                                </div>
                              
                                <div class="form-group">
                                    <label class="control-label col-md-3">Password<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="CNU"></asp:RequiredFieldValidator>
</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="TextBox2" runat="server" class="form-control col-md-8" ValidationGroup="CNU" TextMode="Password" placeholder="Password"></asp:TextBox>
                                    <asp:RegularExpressionValidator ValidationGroup="CNU" ID="Regex5" runat="server" ControlToValidate="TextBox2"
                                    ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"
                                    ErrorMessage="Minimum 6 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character"
                                    ForeColor="Red" BorderColor="Black" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <label class="control-label col-md-3">Confirm Password<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox3" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="CNU"></asp:RequiredFieldValidator>
</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="TextBox3" runat="server" class="form-control col-md-8" ValidationGroup="CNU" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="The password and confirmation password do not match." ValidationGroup="CNU" ForeColor="#FF3300"></asp:CompareValidator>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3">E-mail<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox4" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="CNU"></asp:RequiredFieldValidator>
</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="TextBox4" class="form-control col-md-8" runat="server" ValidationGroup="CNU" placeholder="Enter email address"></asp:TextBox>
                                    <asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" controltovalidate="TextBox4" errormessage="Enter correct Email" validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" validationgroup="CNU" forecolor="#FF3300"></asp:regularexpressionvalidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Mobile<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="CNU"></asp:RequiredFieldValidator>
</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="TextBox6" class="form-control col-md-8" runat="server" ValidationGroup="CNU" placeholder="Enter Mobile Number"></asp:TextBox>
                                    <asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" controltovalidate="TextBox6" errormessage="Enter correct Mobile Number" validationexpression="[0-9]{10}" validationgroup="CNU" forecolor="#FF3300"></asp:regularexpressionvalidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Role<asp:RequiredFieldValidator ID="RequiredFieldValidator7"  InitialValue="0"  runat="server" ControlToValidate="DropDownList1" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="CNU"></asp:RequiredFieldValidator>
</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="DropDownList1" runat="server"
                                            class="form-control" ValidationGroup="CNU">
                                            <asp:ListItem Value="0">Choose Role...</asp:ListItem>
                                            <asp:ListItem>Administrator</asp:ListItem>
                                            <asp:ListItem>Clinical Research Associate</asp:ListItem>
                                            <asp:ListItem>Clinical Research Coordinator</asp:ListItem>
                                            <asp:ListItem>Data Manager</asp:ListItem>
                                            <asp:ListItem>Clinical Data Coordinator</asp:ListItem>
                                            <asp:ListItem>Clinical Data Associate</asp:ListItem>
                                            <asp:ListItem>Project Manager</asp:ListItem>
                                            <asp:ListItem>HEAD CDM</asp:ListItem>
                                            <asp:ListItem>Sponsor</asp:ListItem>
                                            <asp:ListItem>Validation Associate</asp:ListItem>
                                            <asp:ListItem>Quality Associate</asp:ListItem>
                                            <asp:ListItem>Principal Investigator</asp:ListItem>
                                            <asp:ListItem>CoInvestigator</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="card-footer">
                                    <div class="row">
                                        <div class="col-md-8 col-md-offset-3">
                                            <asp:Button class="btn btn-success icon-btn" ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="CNU"  OnClick = "OnConfirm"  OnClientClick = "Confirm()"  />
                                            
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

     <script src="../../Scripts/jquery-1.7.1.min.js"></script>

    <script type="text/javascript">

        function UserOrEmailAvailability() { //This function call on text change.           
            $.ajax({
                type: "POST",
                url: "CreateNewUser.aspx/CheckEmail", // this for calling the web method function in cs code.
                data: '{useroremail: "' + $("#<%=TextBox5.ClientID%>")[0].value + '" }',// user name or email value
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response);
                }
            });
        }

        // function OnSuccess
        function OnSuccess(response) {
            var msg = $("#<%=lblStatus.ClientID%>")[0];
            switch (response.d) {
                case "true":
                    msg.style.display = "block";
                    msg.style.color = "red";
                    msg.innerHTML = "Login ID already exists.";
                    break;
                case "false":
                    msg.style.display = "block";
                    msg.style.color = "green";
                    msg.innerHTML = "";
                    break;
            }
        }

    </script>

    <!-- Javascripts-->
    <script src="../../js/jquery-2.1.4.min.js"></script>
    <script src="../../js/essential-plugins.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <%--<script src="js/plugins/pace.min.js"></script>--%>
    <script src="../../js/main.js"></script>
</asp:Content>

