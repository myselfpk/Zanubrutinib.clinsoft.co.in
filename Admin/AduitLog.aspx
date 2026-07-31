<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AduitLog.aspx.cs" Inherits="Admin_UserProfileManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <title>Clinsoft | Activity History</title>
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
     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div class="wrapper">

        <div class="content-wrapper">
            <div class="page-title">
                <div>
                    <h1><i class="fa fa-users">Activity History</i></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Admin</li>
                        <li>Activity History</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="row">
                            <div class="form-horizontal">
                            </div>
                            <table class="" width="100%" cellpadding="5px;" cellspacing="0" border="1">
                                <colgroup>
                                    <col width="25%" />
                                    <col width="25%" />
                                    <col width="25%" />
                                    <col width="25%" />
                                </colgroup>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <h3>Activity History
                                        </h3>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">The following grid lists the user's activity log.
                <br />
                                    </td>

                                </tr>
                                <tr>
                                    <td align="center">

                                        <asp:TextBox ID="TextBox4" placeholder="YYYY-MM-DD" runat="server" class="form-control" style="height:30px;width:250px;"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" Enabled="True"
                                            TargetControlID="TextBox4">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td align="center">Date
                                    </td>
                                    <td align="center">

                                        <asp:TextBox ID="TextBox1" placeholder="YYYY-MM-DD" runat="server" class="form-control" style="height:30px;width:250px;"></asp:TextBox>
                                        <asp:CalendarExtender ID="TextBox47_CalendarExtender" runat="server" Format="yyyy-MM-dd" Enabled="True"
                                            TargetControlID="TextBox1">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td align="center">
                                        <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Search" OnClick="Button1_Click" />
                                    </td>

                                </tr>

                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="GridView1" runat="server" Width="100%" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Groove" BorderWidth="1px" CellPadding="3" GridLines="Vertical" CssClass="table table-bordered table-responsive table-hover">
                                            <AlternatingRowStyle BackColor="#DCDCDC" />
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#000065" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>

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



