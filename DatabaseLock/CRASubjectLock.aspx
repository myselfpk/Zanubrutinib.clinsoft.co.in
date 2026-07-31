<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CRASubjectLock.aspx.cs" Inherits="DatabaseLock_PIUndertaking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <title>Clinsoft | Database Lock | PI Undertaking</title>
      <style type="text/css">
        .rbl input[type="radio"]
{
   margin-left: 10px;
   margin-right: 30px;
}
  </style>
     <script type = "text/javascript">
         function Confirm() {
             var validated = Page_ClientValidate('SUN');
             if (validated) {
                 var confirm_value = document.createElement("INPUT");

                 confirm_value.type = "hidden";
                 confirm_value.name = "confirm_value";
                 if (confirm("Do you want to Lock Site?")) {
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
       <style type="text/css">
       
        .ErrorControl
        {
            background-color: #FBE3E4;
            border: solid 1px Red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="alert_container" class="messagealert" runat="server">
    </div>
    

    <div class="wrapper">

        <div class="content-wrapper">
            <div class="page-title">
                <div>
                    <h1><i class="fa fa-pencil"> PI Undertaking</i></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Database lock</li>
                        <li>PI Undertaking</li>
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                            CssClass="Validators" Display="None" runat="server" ErrorMessage="Please mention Age Group" ControlToValidate="RadioButtonList1" ValidationGroup="ENS" ForeColor="#FF3300" Font-Size="Large" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-md-8">
                                        <asp:RadioButtonList ID="RadioButtonList1" Width="500px" ValidationGroup="ENS" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" >
                                            <asp:ListItem>19 Years to 49 Years of age</asp:ListItem>
                                            <asp:ListItem>12 Years up to 19 Years of age</asp:ListItem>
                                        </asp:RadioButtonList> 
                                    </div>
                                </div>

                                 <div class="form-group">
                                    <label class="control-label col-md-3">
                                        Center Number:
                                    </label>
                                    &nbsp;<div class="col-md-8">
                                        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" AutoPostBack="true"
                                            DataTextField="CenterName" DataValueField="Centerid" class="form-control" ValidationGroup="ENS" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                            <asp:ListItem Text="Choose..." Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3">
                                        Screening Id:
                                    </label>
                                    &nbsp;<div class="col-md-8">
                                        <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            DataTextField="ScreeningId" DataValueField="ScreeningId" class="form-control" ValidationGroup="ENS" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                            <asp:ListItem Text="Choose..." Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3">
                                        Subject Initial:
                                    </label>
                                    &nbsp;<div class="col-md-8">
                                        <asp:TextBox ID="TextBox2" class="form-control col-md-8" ReadOnly="true"  onkeyup="upper(this)" validationgroup="ENS" MaxLength="3" runat="server" placeholder="Subject Initial"></asp:TextBox>
                                    </div>
                                </div>
                                
                              
                                <div class="card-footer">
                                    <div class="row">
                                         <asp:ValidationSummary runat="server" ShowMessageBox="true" ValidationGroup="SUN" ShowSummary="false" />
                                        <div><center><asp:Label ID="LabelSublock" runat="server" Visible="false" ForeColor="Red"></asp:Label> 
                                            <br />
                                            <asp:Label ID="lblQuery" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                             </center></div>
                                        <div><center><asp:Button class="btn btn-primary icon-btn"  ID="Button1"  OnClick = "OnConfirm"  OnClientClick = "Confirm()"  runat="server" Text="Lock" Visible="false"  /></center></div>
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


