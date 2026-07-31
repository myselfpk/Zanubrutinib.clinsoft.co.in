<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Upload.aspx.cs" Inherits="documents_upload_Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link href="../../css/main.css" rel="stylesheet" />
      <title>Clinsoft | Upload Document</title>
    <script type = "text/javascript">
         function Confirm() {
             var validated = Page_ClientValidate('Upload');
             if (validated) {
                 var confirm_value = document.createElement("INPUT");

                 confirm_value.type = "hidden";
                 confirm_value.name = "confirm_value";
                 if (confirm("Do you want to Upload Document?")) {
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
    <div class="content-wrapper">
        <div class="page-title">
            <div>
                <h1><i class="fa fa-edit"></i> Upload Study Documents</h1>
            </div>

        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">

                        <div class="form-group">
                            <label class="control-label">Document Title</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="Upload"></asp:RequiredFieldValidator>

                            <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Document Title"></asp:TextBox>
                        </div>
                        <div class="form-group">

                            <label class="control-label">Browse Documents
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload1" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="Upload"></asp:RequiredFieldValidator>

                            </label>
                            <asp:FileUpload class="form-control" ID="FileUpload1" runat="server" />
                        </div>


                    </div>
                    <div class="card-footer">
                        <asp:Button CssClass="btn btn-success"  ValidationGroup="Upload" ID="btnUpload" runat="server" Text="Upload"   OnClick = "OnConfirm"  OnClientClick = "Confirm()"  />
                      
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="ID" BackColor="White"
                         BorderColor="#CCCCCC" Style="text-align: center" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="true" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <Columns>
                            <asp:BoundField DataField="id"  HeaderStyle-HorizontalAlign="Center" HeaderText="Serial Number" HeaderStyle-Width="25%" />
                            <asp:BoundField DataField="FileName"  HeaderStyle-HorizontalAlign="Center" HeaderText="File Name" HeaderStyle-Width="25%" />

                        </Columns>
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <HeaderStyle  HorizontalAlign="Center"/>
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
            </div>
            <div class="clearix"></div>

        </div>
    <!-- Javascripts-->
        <script src="../../js/jquery-2.1.4.min.js"></script>
        <script src="../../js/essential-plugins.js"></script>
        <script src="../../js/bootstrap.min.js"></script>
        <%--<script src="../../js/plugins/pace.min.js"></script>--%>
        <script src="../../js/main.js"></script>
         </div>
</asp:Content>
