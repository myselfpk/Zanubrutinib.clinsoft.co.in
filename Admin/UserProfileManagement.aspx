<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserProfileManagement.aspx.cs" Inherits="Admin_UserProfileManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <link href="../css/gridView.css" rel="stylesheet" />
     <title>Clinsoft | User Profile Management</title>
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
    </script>   <style type="text/css">
.gvclass table th {text-align:center;}
</style>

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
        .auto-style2 {
            margin-left: 55px;
        }
    </style>
      <script type = "text/javascript">
         function Confirm() {
             var validated = Page_ClientValidate('EnrollSite');
             if (validated) {
                 var confirm_value = document.createElement("INPUT");

                 confirm_value.type = "hidden";
                 confirm_value.name = "confirm_value";
                 if (confirm("Do you want to enroll new site?")) {
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

        <div class="content-wrapper">
            <div class="page-title">
                <div>
                    <h1><i class="fa fa-users"> User Profile Management</i></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Admin</li>
                        <li>User profile management</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="row">
                            <div class="form-horizontal">

                                  <div class="form-group">
                                      <asp:label id="Label1" Visible="False" runat="server"></asp:label>
                                </div>


                                <div class="form-group">
                                    <asp:Panel ID="Panel1" runat="server">
                                        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
            <div id="dvGrid" style="padding: 10px;">
                
                    

                           <div class="gvclass">
                        <asp:GridView ID="GridView1" width="94%" DataKeyNames="UserID" runat="server"
                            AutoGenerateColumns="False" Font-Names="Arial"
                             AlternatingRowStyle-BackColor="#C2D69B"
                             AllowPaging="True" ShowFooter="false"
                            OnPageIndexChanging="OnPaging" OnRowEditing="EditCustomer"
                            OnRowUpdating="UpdateCustomer" OnRowCancelingEdit="CancelEdit" text-align="center" 
                             BorderStyle="Solid" BorderWidth="3px"  ForeColor="Black" CssClass="auto-style2 table table-table-hover table-bordered">
                            <pagerstyle cssclass="gridview">
</pagerstyle>
                            <HeaderStyle  Wrap="true" Height="40" CssClass="table table-table-hover table-bordered"/>
                            <EmptyDataTemplate>
                                <div style="text-align: center; border: double; background-color: rgb(254,  202,  5);">
                                    <samp>
                                    Record Not Found !!!</span>
                                </div>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="30px" HeaderText="User ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="User Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubjectID" runat="server" Text='<%# Eval("UserName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtUserName" Width="100px" Text='<%# Eval("UserName")%>' runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Login ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStudyID" runat="server" Text='<%# Eval("LoginID")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLoginID" Width="100px" Text='<%# Eval("LoginID")%>' runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmail" Width="150px" TextMode="MultiLine" Text='<%# Eval("Email")%>' runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="User Role">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserRole" runat="server" Text='<%# Eval("UserRole")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtUserRole" Width="100px" Text='<%# Eval("UserRole")%>' runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="25px" HeaderText="Blocked?">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsLocked" runat="server" Text='<%# Eval("IsLocked")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtIsLocked" Width="15px" Text='<%# Eval("IsLocked")%>' runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="25px" />
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Last Login">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastLogin" runat="server" Text='<%# Eval("LastLogin")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:CommandField ItemStyle-Width="50px" ShowEditButton="True" HeaderText="Action">
                                <ItemStyle Width="50px" />
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle ForeColor="White" BackColor="Teal" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"  />
                           <%-- <FooterStyle BackColor="#CCCCCC" />--%>
                            <PagerStyle BackColor="darkslategray" ForeColor="White" HorizontalAlign="Left"/>
                            <RowStyle HorizontalAlign="Center" BackColor="White" Wrap="true" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                               </div>
                    
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                    </Triggers>
                
            </div>
        </asp:Panel>
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



