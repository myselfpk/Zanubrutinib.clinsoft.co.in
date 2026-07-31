<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="subjectList.aspx.cs" Inherits="MasterPage_subjectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <link href="../css/gridView.css" rel="stylesheet" />
    <title>Clinsoft | Subject List</title>
    <style type="text/css">
        .gvclass table th {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="wrapper">

        <div class="content-wrapper">
            <div class="page-title">
                <div>
                    <h1><i class="fa fa-list"></i>Subject's List</h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Data Entry</li>
                        <li>Subject List</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="card" style="min-height: 100px">
                        <div class="row">
                            <div style="text-align: center;">
                                <table cellpadding="5px;" cellspacing="0" width="100%" style="border: groove">
                                    <colgroup>
                                        <col width="50%" />
                                        <col width="50%" />

                                    </colgroup>

                                    <tr>
                                        <td colspan="2">
                                            <div id="ErroeMess" runat="server" style="text-align: center; width: 100%; background-color: cadetblue; color:Cornsilk; border: ridge; min-height: 40px; padding-top: 5px">
                                                <asp:Label ID="Label1" runat="server" Text="" ForeColor="Cornsilk" Font-Bold="true"></asp:Label>
                                            </div>

                                            <div class="gvclass">
                                                <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" CssClass="table table-striped table-bordered table-hover">
                                                    <PagerStyle CssClass="gridview"></PagerStyle>

                                                    <HeaderStyle VerticalAlign="Middle" BorderStyle="None" Height="40" HorizontalAlign="Center" Wrap="true" />

                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" Visible="false" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbCenterNumber" runat="server" Text='<%#Eval("CenterNumber") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" Visible="false" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbScreeningId" runat="server" Text='<%#Eval("ScreeningId") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" Visible="false" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbSubInitial" runat="server" Text='<%#Eval("SubInitial") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="CenterNumber" HeaderText="Site Number" HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                                            <ItemStyle HorizontalAlign="Center" Font-Bold="true"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="SubInitial" HeaderText="Subject Initial">
                                                            <ItemStyle HorizontalAlign="Center" Font-Bold="true"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:TemplateField HeaderText="Subject Number" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <div style="text-align: center;">
                                                                    <asp:LinkButton ForeColor="#003300" Font-Bold="true" ID="lblScreeningId" Font-Underline="True" runat="server" Text='<%#Eval("ScreeningId") %>' CommandName="dvview" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' ToolTip="Click Here to go Subject's Data Entry Activity List"></asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                          
                                                        </asp:TemplateField>
                                                         

                                                        <%-- <asp:TemplateField HeaderText="PI Electronic Signature">
                                                            <ItemTemplate>
                                                                    <asp:Literal ID="litActual" runat="server"></asp:Literal>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    </Columns>
                                                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                                    <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="6" />
                                                    <PagerStyle BackColor="#2F4F4F" ForeColor="White" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                </asp:GridView>
                                            </div>
                                        </td>
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

