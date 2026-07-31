<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ImageDownload.aspx.cs" Inherits="documents_download_ImageDownload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link href="../../css/main.css" rel="stylesheet" />
    <link href="../css/gridView.css" rel="stylesheet" />
     <title>Clinsoft | Download Image</title>
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
    <style type="text/css">
        .gvclass table th {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="content-wrapper">
        <div class="page-title">
            <div>
                <h1><i class="fa fa-download"></i> Download Study Image</h1>

            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <div class="gvclass">
                        <asp:GridView ID="GridView1" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" EnableModelValidation="true" GridLines="None"
                                RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" Width="100%" AlternatingRowStyle-ForeColor="#000" AutoGenerateColumns="false" CssClass="table table-responsive table-bordered table-hover" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="100">
                            <PagerStyle CssClass="gridview"></PagerStyle>
                            <HeaderStyle BackColor="#000084" Font-Bold="true" ForeColor="White" Wrap="true" BorderStyle="None" Height="40" />
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="Serial Number" HeaderStyle-Width="10%"/>
                                <asp:BoundField DataField="Site" HeaderText="Site" HeaderStyle-Width="10%"/>
                                <asp:BoundField DataField="ScreenID" HeaderText="Subject Number" HeaderStyle-Width="15%"/>
                                <asp:BoundField DataField="SubInitial" HeaderText="Subject Initial" HeaderStyle-Width="10%"/>
                                <asp:BoundField DataField="Visit" HeaderText="Visit" HeaderStyle-Width="10%"/>
                                <asp:BoundField DataField="Page" HeaderText="Page" HeaderStyle-Width="30%"/>
                                <asp:TemplateField HeaderText="Download File" HeaderStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile"
                                            CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                    </ItemTemplate> 
                                    <ItemStyle></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                            <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="10" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Font-Bold="True" />
                            
                                                    <RowStyle ForeColor="#000066" Font-Bold="True" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                            

                                                </asp:GridView>
                            </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Javascripts-->
        <script src="../../js/jquery-2.1.4.min.js"></script>
        <script src="../../js/essential-plugins.js"></script>
        <script src="../../js/bootstrap.min.js"></script>
        <%--<script src="../../js/plugins/pace.min.js"></script>--%>
        <script src="../../js/main.js"></script>
    </div>

</asp:Content>
