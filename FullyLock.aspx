<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FullyLock.aspx.cs" Inherits="DataView_Day1_FullyLock" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | DataView | DataBase Lock By Data Manager</title>
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link rel="stylesheet" type="text/css" href="../../../css/main.css" />
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
        /*Calendar Control CSS*/
        .cal_Theme1 .ajax__calendar_container {
            background-color: #DEF1F4;
            border: solid 1px #77D5F7;
        }

        .cal_Theme1 .ajax__calendar_header {
            background-color: #ffffff;
            margin-bottom: 4px;
        }

        .cal_Theme1 .ajax__calendar_title,
        .cal_Theme1 .ajax__calendar_next,
        .cal_Theme1 .ajax__calendar_prev {
            color: #004080;
            padding-top: 3px;
        }

        .cal_Theme1 .ajax__calendar_body {
            background-color: #ffffff;
            border: solid 1px #77D5F7;
            width: auto;
        }

        .cal_Theme1 .ajax__calendar_dayname {
            text-align: center;
            font-weight: bold;
            margin-bottom: 4px;
            margin-top: 2px;
            color: #004080;
        }

        .cal_Theme1 .ajax__calendar_day {
            color: #004080;
            text-align: center;
        }




        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_day,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_month,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_year,
        .cal_Theme1 .ajax__calendar_active {
            color: #004080;
            font-weight: bold;
            background-color: #DEF1F4;
        }

        .cal_Theme1 .ajax__calendar_today {
            font-weight: bold;
        }

        .cal_Theme1 .ajax__calendar_other,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_today,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_title {
            color: #bbbbbb;
        }
    </style>
    <style type="text/css">
        #ct100_PopupWindow {
            position: absolute;
            margin: -10px 0 0 -200px;
            top: 20%;
            left: 50%;
        }

        #ct100_PopupWindow1 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow2 {
            position: absolute;
            margin: -10px 0 0 -200px;
            top: 20%;
            left: 50%;
        }

        #ct100_PopupWindow3 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow4 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow5 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow6 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow7 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow8 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow9 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow10 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow11 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow12 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow13 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow14 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow15 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 37%;
            left: 45%;
        }

        #ct100_PopupWindow16 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 47%;
            left: 45%;
        }

        #ct100_PopupWindow17 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 47%;
            left: 45%;
        }

        #ct100_PopupWindow18 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 47%;
            left: 45%;
        }

        #ct100_PopupWindow19 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 47%;
            left: 45%;
        }

        #ct100_PopupWindow20 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 57%;
            left: 45%;
        }

        #ct100_PopupWindow21 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 57%;
            left: 45%;
        }

        #ct100_PopupWindow22 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 57%;
            left: 45%;
        }

        #ct100_PopupWindow23 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 57%;
            left: 45%;
        }

        #ct100_PopupWindow24 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 57%;
            left: 45%;
        }

        #ct100_PopupWindow25 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 57%;
            left: 45%;
        }

        #ct100_PopupWindow26 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 57%;
            left: 45%;
        }

        #ct100_PopupWindow27 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 57%;
            left: 45%;
        }

        #ct100_PopupWindow28 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 27%;
            left: 45%;
        }

        #ct100_PopupWindow29 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 27%;
            left: 45%;
        }

        #ct100_PopupWindow30 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 77%;
            left: 45%;
        }

        #ct100_PopupWindow31 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 97%;
            left: 45%;
        }

        #ct100_PopupWindow32 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 27%;
            left: 45%;
        }

        #ct100_PopupWindow33 {
            position: absolute;
            margin: -100px 0 0 -200px;
            top: 27%;
            left: 45%;
        }

        .auto-style2 {
            height: 50px;
            text-align: center;
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
                if (confirm("Do you want to Submit DataBase Lock By Data Manager Page?")) {
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
            if (confirm("Do you want to Save DataBase Lock By Data Manager Page?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }


    </script>
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
    <style type="text/css">
        .ErrorControl {
            background-color: #FBE3E4;
            border: solid 1px Red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>


    <div class="wrapper">

        <div class="content-wrapper">
            <div class="page-title">
                <div>
                    <h1><i class="fa fa-edit"></i>
                        <asp:Label runat="server" ID="lblPage">DataBase Lock</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>DataView</li>
                        <li>DataBase Lock</li>
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
                                            <col width="50%" />
                                            <col width="40%" />
                                            <col width="10%" />
                                        </colgroup>
                                        
                                        
                                        <tr>
                                            <td colspan="3">
                                                <asp:RadioButtonList ID="RadioButtonListPI" ValidationGroup="IC" runat="server">
                                                    <asp:ListItem><%--I declare that I have reviewed all subject visit data and found them accurate and complete to the best of my knowledge.--%>Database fully lock by the Data Manager</asp:ListItem>
                                                </asp:RadioButtonList>
                                               
                                              <br />
                                               

                                               
                                            </td>
                                        </tr>
                                        
                                    
                                    </table>
                                    <div class="text-center">
                                    </div>
                                    <div class="text-center">
                                    </div>
                                    <div class="text-center">
                                    </div>
                                    <div class="card-footer">
                                        <div class="row">
                                            <div class="col-md-5 col-md-offset-3">
                                                <asp:ValidationSummary runat="server" ShowMessageBox="true" ValidationGroup="IC" ShowSummary="false" />
                                                  <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
                                              
                                                <input type = "button" id="btnShowLogin" class="btn btn-primary" value = "Database lock by the Data Manager" />
                                            </div>
                                        </div>
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
    <script type="text/javascript">
        $(function () {
            $("#btnShowLogin").click(function () {
                $('#LoginModal').modal('show');
            });
        });
</script>

<div class="modal fade" id="LoginModal"  tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
    aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    &times;</button>
                <h4 class="modal-title" id="ModalTitle">
                    Login</h4>
            </div>
            <div class="modal-body">
                 <label for="txtUsername">
                    Username</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter User Id"
                    required />
                <br />
                <label for="txtPassword">
                    Password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"
                    placeholder="Enter Password" required />
              
                <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
                    <strong>Error!</strong>
                    <asp:Label ID="lblMessage" runat="server" />
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="ValidateUser" Class="btn btn-primary"  />
                <button type="button" class="btn btn-default" data-dismiss="modal">
                    Close</button>
            </div>
        </div>
    </div>

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
