<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EnrolledSite.aspx.cs" Inherits="Admin_EnrolledSite" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
     <title>Clinsoft | Enroll Site</title>
      <script type="text/javascript">
        function isNumberKey(evt) {
            //var e = evt || window.event;
            var charCode = (evt.which) ? evt.which: evt.keyCode
            if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function ValidaTealpha(evt) {
            var keyCode = (evt.which) ? evt.which: evt.keyCode
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
             var validated = Page_ClientValidate('EnrollSite');
             if (validated) {
                 var confirm_value = document.createElement("INPUT");

                 confirm_value.type = "hidden";
                 confirm_value.name = "confirm_value";
                 if (confirm("Do you want to Enroll New Site?")) {
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
    <div class="wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="content-wrapper">
            <div class="page-title">
                <div>
                    <h1><i class="fa fa-edit"></i> Site Enrollment</h1>
                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Admin</li>
                        <li>Enroll New Site</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="well bs-component">
                                    <div class="form-horizontal">
                                        <fieldset>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProtocolNumber"  CssClass="Validators" Display="None" ErrorMessage="Enter Protocol Number" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="EnrollSite"></asp:RequiredFieldValidator><div class="form-group">
                                                <label class="col-lg-2 control-label" for="inputCenterName">Protocol Number</label>
                                                <div class="col-lg-10">
                                                    <asp:TextBox class="form-control" ID="txtProtocolNumber" MaxLength="50" ValidationGroup="EnrollSite" Text="GPL ZANU-401" ReadOnly="true"  runat="server" placeholder="Protocol Number"></asp:TextBox>
                                                </div>
                                            </div>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtOfficialtitle"   CssClass="Validators" Display="None" ErrorMessage="Enter Title of Study" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="EnrollSite">

                                        </asp:RequiredFieldValidator>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label" for="inputPassword">Study Title</label>
                                            <div class="col-lg-10">
                                                <asp:TextBox class="form-control" ID="txtOfficialtitle" MaxLength="1000" ValidationGroup="EnrollSite"
                                                    ReadOnly="true"
                                                    Text="An Open Label, Phase IV, Single Arm, Multicentric, Prospective Study To Evaluate The Safety And Effectiveness Of Zanubrutinib In Patients With B-Cell Lymphomas (ZAP-BCL)." runat="server"
                                                     TextMode="MultiLine" Height="100" placeholder="Study Title">

                                                </asp:TextBox>
                                            </div>
                                        </div>
                                             
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPInvestigator"   CssClass="Validators" Display="None" ErrorMessage="Enter Prinicipal Investigator Name" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="EnrollSite"></asp:RequiredFieldValidator><div class="form-group">
 
                                                <label class="col-lg-2 control-label" for="textArea">PI Name</label>
                                                <div class="col-lg-10">
                                                    <asp:TextBox class="form-control" ID="txtPInvestigator" ValidationGroup="EnrollSite"  runat="server" placeholder="Principal Investigator Name"></asp:TextBox>
                                                </div>
                                            </div>
                                        
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                            <div class="well bs-component">
                                <div class="form-horizontal">
                                    <fieldset>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCenterid" ErrorMessage="Enter Center Number"   CssClass="Validators" Display="None" 
                                                  ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="EnrollSite"></asp:RequiredFieldValidator>
                                            <div class="form-group">

                                                <label class="col-lg-2 control-label" for="inputPassword">Center Number</label>
                                                <div class="col-lg-10">
                                                    <asp:TextBox class="form-control" ID="txtCenterid"  onkeypress="return isNumberKey(event)" MaxLength="2" MinLength="2" ValidationGroup="EnrollSite"  runat="server" 
                                                        placeholder="Center Number"></asp:TextBox>
                                                   
                                                </div>
                                               
                                                  <div>
                                                  <center><asp:Label ID="lblStatus" runat="server"></asp:Label></center>
                                                    </div>
                                            </div>
                                                                
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCenterAddress"  CssClass="Validators" Display="None"  ErrorMessage="Enter Center Address" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="EnrollSite">

                                             </asp:RequiredFieldValidator>
                                            <div class="form-group">

                                                <label class="col-lg-2 control-label">Center Address</label>
                                                <div class="col-lg-10">

                                                    <asp:TextBox class="form-control" ID="txtCenterAddress" MaxLength="2000" ValidationGroup="EnrollSite"  TextMode="MultiLine" Height="100"   runat="server" placeholder="Center Address"></asp:TextBox>


                                                </div>
                                            </div>

                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCNo"  CssClass="Validators" Display="None"  ErrorMessage="Enter Contact Number" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="EnrollSite"></asp:RequiredFieldValidator><div class="form-group">

                                                <label class="col-lg-2 control-label">Contact </label>
                                                <div class="col-lg-10">
                                                    <asp:TextBox class="form-control" ID="txtCNo" ValidationGroup="EnrollSite" onkeypress="return isNumberKey(event)" MaxLength="12"  runat="server" placeholder="Contact Number"></asp:TextBox>
                                                <asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" controltovalidate="txtCNo" errormessage="*" forecolor="#FF3300" validationexpression="[0-9]{10}" setfocusonerror="True" validationgroup="EnrollSite"></asp:regularexpressionvalidator>
                                                </div>
                                            </div>
                                                                              
                                    </fieldset>
                                </div>
                            </div>
                            <br />
                            <div class="card-footer" >
                                            <div class="row">
                                                <div class="col-md-8 col-md-offset-3" >
                                                     <asp:ValidationSummary runat="server" ShowMessageBox="true" ValidationGroup="EnrollSite" ShowSummary="false" />
                                                     &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                                    <asp:Button class="btn btn-success icon-btn" ID="btnSubmit" ValidationGroup="EnrollSite" runat="server" Text="Submit" OnClick = "OnConfirm"  OnClientClick = "Confirm()" />
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
    
    <script src="../../Scripts/jquery-1.7.1.min.js"></script>

    <script type="text/javascript">

        function UserOrEmailAvailability() { //This function call on text change.           
            $.ajax({
                type: "POST",
                url: "EnrolledSite.aspx/CheckEmail", // this for calling the web method function in cs code.
                data: '{useroremail: "' + $("#<%=txtCenterid.ClientID%>")[0].value + '" }',// user name or email value
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
                    msg.innerHTML = "Center ID already exists.";
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
    <script type="text/javascript">
         function WebForm_OnSubmit() {
             if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false)
             {
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

