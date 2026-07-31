<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SubjectUnlock.aspx.cs" Inherits="DatabaseLock_SubjectUnlock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <title>Clinsoft | Database Lock | Unlock Subject Data</title>
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
                 if (confirm("Do you want to Unlock Page?")) {
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
                    <h1><i class="fa fa-unlock"> Unlock Subject Data</i></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Database lock</li>
                        <li>Unlock Subject Data</li>
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
                                        Center Number:  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                       CssClass="Validators" Display="None" ErrorMessage="Please mention Center Number" ControlToValidate="DropDownList1"  
                                      ValidationGroup="SUN"></asp:RequiredFieldValidator>
                                    </label>
                                    &nbsp;<div class="col-md-8">
                                        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" AutoPostBack="true"
                                            DataTextField="CenterName" DataValueField="Centerid" class="form-control" ValidationGroup="SUN" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                            <asp:ListItem Text="Choose Center Number" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3">
                                        Screening Id:
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                       CssClass="Validators" Display="None" ErrorMessage="Please mention Screening Id" ControlToValidate="DropDownList2"  
                                      ValidationGroup="SUN"></asp:RequiredFieldValidator>
                                    </label>
                                    &nbsp;<div class="col-md-8">
                                     <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                          class="form-control" ValidationGroup="SUN" >
                                            <asp:ListItem Text="Choose Screening Id" Value=""></asp:ListItem>
                                           
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3">
                                        Subject Initial:
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                       CssClass="Validators" Display="None" ErrorMessage="please mention Subject Initial" ControlToValidate="TextBox2"  
                                      ValidationGroup="SUN"></asp:RequiredFieldValidator>
                                    </label>
                                    &nbsp;<div class="col-md-8">
                                        <asp:TextBox ID="TextBox2" class="form-control col-md-8" ReadOnly="true"  onkeyup="upper(this)" validationgroup="SUN" MaxLength="3" runat="server" placeholder="Subject Initial"></asp:TextBox>
                                    </div>
                                </div>
                                
                              
                                 <div class="form-group">
                                    <label class="control-label col-md-3">
                                        Visit:
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                       CssClass="Validators" Display="None" ErrorMessage="Please mention Visit" ControlToValidate="DropDownList3"  
                                      ValidationGroup="SUN"></asp:RequiredFieldValidator>
                                    </label>
                                    &nbsp;<div class="col-md-8">
                                        <asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                          class="form-control" ValidationGroup="SUN" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" >
                                            <asp:ListItem Text="Choose Visit" Value=""></asp:ListItem>
                                            <asp:ListItem>Day 1</asp:ListItem>
                                                <asp:ListItem>Visit 2</asp:ListItem>
                                              
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <label class="control-label col-md-3">
                                        Page:
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                       CssClass="Validators" Display="None" ErrorMessage="Please mention Page" ControlToValidate="DropDownList4"  
                                      ValidationGroup="SUN"></asp:RequiredFieldValidator>
                                    </label>
                                    &nbsp;<div class="col-md-8">
                                         <asp:DropDownList ID="DropDownList4" runat="server" AppendDataBoundItems="True"
                                         class="form-control" ValidationGroup="SUN" >
                                            <asp:ListItem Text="Choose Page" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                
                                
                                <div class="card-footer">
                                    <div class="row">
                                        <asp:ValidationSummary runat="server" ShowMessageBox="true" ValidationGroup="SUN" ShowSummary="false" />
                                        <div><center><asp:Label ID="LabelSublock" runat="server" Visible="false" ForeColor="Red"></asp:Label> </center></div>
                                        <div><center><asp:Button class="btn btn-primary icon-btn"  ID="Button1" ValidationGroup="SUN"   OnClick = "OnConfirm"  OnClientClick = "Confirm()" runat="server" Text="Unlock"   /></center></div>
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


