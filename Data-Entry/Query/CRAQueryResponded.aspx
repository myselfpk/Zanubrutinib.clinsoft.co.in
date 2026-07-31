<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CRAQueryResponded.aspx.cs" Inherits="Admin_EnrolledSite" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | Data Entry | Query | Query Responded</title>
    <link rel="stylesheet" type="text/css" href="../../css/main.css" />
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div class="wrapper">
        <div class="content-wrapper">
            <div class="page-title">
                <div>
                    <h1><i class="fa fa-edit"></i>
                        <asp:Label runat="server" ID="lblPage">Query Responded</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Data Entry</li>
                        <li>Query</li>
                        <li>Query Responded</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div style="min-height: 480px">
       <div id="ErroeMess" runat="server" style="text-align: center; width: 100%; background-color: orange; border: double; min-height:40px; padding-top:5px">
            <asp:Label ID="Label1" runat="server" Text="" ForeColor="#003300" Font-Bold="true"></asp:Label>
        </div>
        <asp:GridView ID="GridView1" class="table table-hover table-bordered dataTable no-footer" runat="server" AutoGenerateColumns="False" GridLines="Vertical" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black">
            

            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lbSiteid" runat="server" Text='<%#Eval("CenterNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lbScreenID" runat="server" Text='<%#Eval("ScreenID") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblSubIni" runat="server" Text='<%#Eval("SubInitial") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblVisit" runat="server" Text='<%#Eval("Visit") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CenterNumber" HeaderText="Center Number">
                   
                </asp:BoundField>
                <asp:BoundField DataField="ScreenID" HeaderText="Sreening ID">
                   
                </asp:BoundField>
               
                <asp:BoundField DataField="SubInitial" HeaderText="Subject Initial">
                   
                </asp:BoundField>
                <asp:BoundField DataField="Visit" HeaderText="Visit">
                   
                </asp:BoundField>
                <asp:BoundField DataField="Page" HeaderText="Page">
                   
                </asp:BoundField>
                <asp:BoundField DataField="Field" HeaderText="Field">
                   
                </asp:BoundField>
                <asp:BoundField DataField="Query" HeaderText="Monitor Comment">
                   
                </asp:BoundField>
                <asp:BoundField DataField="QueryResponse" HeaderText="CRC Comment">
                   
                </asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="Status">
                   
                </asp:BoundField>
                <asp:BoundField DataField="Username" HeaderText="Raised by">
                   
                </asp:BoundField>
                <asp:BoundField DataField="Date" HeaderText="Raised Date">
                   
                </asp:BoundField>
                <asp:BoundField DataField="Username2" HeaderText="Responded by">
                   
                </asp:BoundField>
                <asp:BoundField DataField="Date2" HeaderText="Responded Date">
                   
                </asp:BoundField>
                <asp:TemplateField HeaderText="Page" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <div style="text-align: center">
                            <asp:LinkButton ID="lblPage" runat="server" Text='<%#Eval("Page") %>' CommandName="dvview" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                </asp:TemplateField>
                 <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblSNO" runat="server" Text='<%#Eval("SNO") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
                </div>
            </div>
        </div>
    </div>
   


    <!-- Javascripts-->
    <script src="../../../js/jquery-2.1.4.min.js"></script>
    <script src="../../../js/essential-plugins.js"></script>
    <script src="../../../js/bootstrap.min.js"></script>
    <%--<script src="js/plugins/pace.min.js"></script>--%>
    <script src="../../../js/main.js"></script>
</asp:Content>
