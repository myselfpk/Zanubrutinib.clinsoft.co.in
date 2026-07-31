<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DataExtraction.aspx.cs" Inherits="DataExtraction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/main.css" />

    <title>Clinsoft | Data Extraction</title>
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
            height: 40px;
            text-align: center;
        }

        .auto-style2 {
            height: 40px;
            text-align: center;
            font-family: "Segoe UI";
            font-size: large;
        }

        .auto-style3 {
            font-weight: normal;
        }

        .auto-style4 {
            background-color:;
            height: 50px;
        }

        .auto-style5 {
            background-color:;
            height: 50px;
            padding-right: 150px;
            font-weight: bold;
            text-align: center;
            color: #003300;
        }
    </style>

    <script type="text/javascript">
        function Confirm1() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Download Visit 1 ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>

    <script type="text/javascript">
        function Confirm2() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Download Visit 2 ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>

    <script type="text/javascript">
        function Confirm3() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Download Visit 3 ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

    <script type="text/javascript">
        function Confirm4() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Download Visit Unscheduled ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>

    <script type="text/javascript">
        function ConfirmConMed() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Download Prior/Concomitant Medication Form ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>

    <script type="text/javascript">
        function ConfirmAE() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Download Adverse Event Record Form ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>

    <script type="text/javascript">
        function ConfirmSTUDY() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Download Study Completion/Early Termination Form ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>

    <script type="text/javascript">
        function ConfirmQRIS() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Download QUERIES ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>

    <script type="text/javascript">
        function ConfirmREASON() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Download REASON FOR CHANGES ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>

    <script type="text/javascript">
        function ConfirmSTATUS() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Download Page Status And PI Signature ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>

    <script type="text/javascript">
        function ConfirmMHR() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Download Medical History Record Form?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>

    <script type="text/javascript">
        function ConfirmALL() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Download ALL VISITS ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>

    <script type="text/javascript">
        function ConfirmREPORT() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Download Activity Report ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
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

        <div class="content-wrapper">
            <div class="page-title">
                <div>
                    <h1><i class="fa fa-folder-open-o"></i>Data Extraction</h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>User</li>
                        <li>Data Extraction</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="row">
                            <div class="form-horizontal">

                                <table cellpadding="5px;" cellspacing="0" width="100%" class="CSSTableGenerator table table-hover table-responsive table-bordered">
                                    <colgroup>


                                        <col width="50%" />
                                        <col width="50%" />


                                    </colgroup>
                                    <tr class="auto-style2" style="background-color: Teal; color: white; font-weight: bold">
                                        <td class="auto-style2"><strong class="auto-style3">Visit</strong></td>
                                        <td class="auto-style1"><strong class="auto-style3">Download</strong></td>
                                    </tr>
                                    <%-- All Visit --%>
                                    <tr>
                                        <td class="auto-style5">All Visit</td>
                                        <td class="auto-style4 auto-style2">
                                            <asp:ImageButton ID="ImageButtonALL" runat="server" Width="40px" Height="40px" ImageUrl="~/images/Download.png" OnClick="OnConfirmALL" OnClientClick="ConfirmALL()" /></td>
                                    </tr>
                                    <%-- Visit 1 --%>
                                    <tr>
                                        <td class="auto-style5">Visit 1 - (Screening/ Baseline/ Enrolment) (Day 1 to 10)</td>
                                        <td class="auto-style4 auto-style2">
                                            <asp:ImageButton ID="ImageButton1" runat="server" Width="40px" Height="40px" ImageUrl="~/images/Download.png" OnClick="OnConfirm1" OnClientClick="Confirm1()" /></td>
                                    </tr>
                                    <%-- Visit 2 --%>
                                    <tr>
                                        <td class="auto-style5">Visit 2 - (Day 30 ± 10)</td>
                                        <td class="auto-style4 auto-style2">
                                            <asp:ImageButton ID="ImageButton2" runat="server" Width="40px" Height="40px" ImageUrl="~/images/Download.png" OnClick="OnConfirm2" OnClientClick="Confirm2()" /></td>
                                    </tr>
                                    <%-- Visit 3 --%>
                                    <tr>
                                        <td class="auto-style5">Visit 3 - (Day 90 ± 10)</td>
                                        <td class="auto-style4 auto-style2">
                                            <asp:ImageButton ID="ImageButton3" runat="server" Width="40px" Height="40px" ImageUrl="~/images/Download.png" OnClick="OnConfirm3" OnClientClick="Confirm3()" /></td>
                                    </tr>
                                    <%-- Visit 4 --%>
                                    <tr>
                                        <td class="auto-style5">Visit Unscheduled</td>
                                        <td class="auto-style4 auto-style2">
                                            <asp:ImageButton ID="ImageButton4" runat="server" Width="40px" Height="40px" ImageUrl="~/images/Download.png" OnClick="OnConfirm4" OnClientClick="Confirm4()" /></td>
                                    </tr>

                                    <%-- Medical History --%>
                                    <tr>
                                        <td class="auto-style5">Medical History Record</td>
                                        <td class="auto-style4 auto-style2">
                                            <asp:ImageButton ID="ImageButtonMHR" runat="server" Width="40px" Height="40px" ImageUrl="~/images/Download.png" OnClick="OnConfirmMHR" OnClientClick="ConfirmMHR()" /></td>
                                    </tr>
                                    <%-- Concomitant Medication Record --%>
                                    <tr>
                                        <td class="auto-style5">Concomitant Medication Record</td>
                                        <td class="auto-style4 auto-style2">
                                            <asp:ImageButton ID="ImageButtonConMed" runat="server" Width="40px" Height="40px" ImageUrl="~/images/Download.png" OnClick="OnConfirmConMed" OnClientClick="ConfirmConMed()" /></td>
                                    </tr>
                                    <%-- Adverse Event Record --%>
                                    <tr>
                                        <td class="auto-style5">Adverse Event Record</td>
                                        <td class="auto-style4 auto-style2">
                                            <asp:ImageButton ID="ImageButtonAE" runat="server" Width="40px" Height="40px" ImageUrl="~/images/Download.png" OnClick="OnConfirmAE" OnClientClick="ConfirmAE()" /></td>
                                    </tr>

                                    <%-- Study Completion/Early Termination Form --%>
                                    <tr>
                                        <td class="auto-style5">Study Completion/Early Termination Form</td>
                                        <td class="auto-style4 auto-style2">
                                            <asp:ImageButton ID="ImageButtonSTUDY" runat="server" Width="40px" Height="40px" ImageUrl="~/images/Download.png" OnClick="OnConfirmSTUDY" OnClientClick="ConfirmSTUDY()" /></td>
                                    </tr>

                                    <%-- Reason for changes --%>
                                    <tr>
                                        <td class="auto-style5">Reason for changes</td>
                                        <td class="auto-style4 auto-style2">
                                            <asp:ImageButton ID="ImageButtonREASON" runat="server" Width="40px" Height="40px" ImageUrl="~/images/Download.png" OnClick="OnConfirmREASON" OnClientClick="ConfirmREASON()" /></td>
                                    </tr>
                                    <%-- Queries --%>
                                    <tr>
                                        <td class="auto-style5">Queries</td>
                                        <td class="auto-style4 auto-style2">
                                            <asp:ImageButton ID="ImageButtonQRIS" runat="server" Width="40px" Height="40px" ImageUrl="~/images/Download.png" OnClick="OnConfirmQRIS" OnClientClick="ConfirmQRIS()" /></td>
                                    </tr>
                                    <%-- Page Status & PI Sign --%>
                                    <tr>
                                        <td class="auto-style5">Page Status & PI Sign</td>
                                        <td class="auto-style4 auto-style2">
                                            <asp:ImageButton ID="ImageButtonSTATUS" runat="server" Width="40px" Height="40px" ImageUrl="~/images/Download.png" OnClick="OnConfirmSTATUS" OnClientClick="ConfirmSTATUS()" /></td>
                                    </tr>

                                    <%-- Activity Report --%>
                                    <tr>
                                        <td class="auto-style5">Activity Report</td>
                                        <td class="auto-style4 auto-style2">
                                            <asp:ImageButton ID="ImageButtonREPORT" runat="server" Width="40px" Height="40px" ImageUrl="~/images/Download.png" OnClick="OnConfirmREPORT" OnClientClick="ConfirmREPORT()" /></td>
                                    </tr>
                                </table>

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

