<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link rel="stylesheet" type="text/css" href="css/main.css" />
    <link rel="stylesheet" type="text/css" href="css/dashboard.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="wrapper dashboard-page">
        <div class="content-wrapper">
            <div class="dashboard-header">
                <div><span class="page-eyebrow">Study overview</span><h1>Clinical dashboard</h1></div>
                <span class="dashboard-status"><i class="fa fa-circle" aria-hidden="true"></i> Database connected</span>
            </div>
            <div class="row summary-row" id="pnlSiteSummary" runat="server" visible="false">

                <div class="col-md-2">
                    <div class="summary-card summary-site">
                        <span class="summary-icon"><i class="fa fa-hospital-o"></i></span>
                        <div class="summary-label">Site Number</div>
                        <div class="summary-value">
                            <asp:Label ID="lblSiteNumber" runat="server" Text="-" />
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="summary-card summary-investigator">
                        <span class="summary-icon"><i class="fa fa-user-md"></i></span>
                        <div class="summary-label">PI Name</div>
                        <div class="summary-value">
                            <asp:Label ID="lblPIName" runat="server" Text="-" />
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="summary-card summary-address">
                        <span class="summary-icon"><i class="fa fa-map-marker"></i></span>
                        <div class="summary-label">Site Address</div>
                        <div class="summary-value">
                            <asp:Label ID="lblSiteAddress" runat="server" Text="-" />
                        </div>
                    </div>
                </div>

            </div>
            <div class="row chart-grid">
                <div class="col-md-12">
                    <section class="dash-card">
                        <div class="dash-card-body"><asp:Literal ID="lt1" runat="server"></asp:Literal><div id="chart_div1" class="chart-box"></div></div>
                    </section>
                </div>
                <div class="col-md-12">
                    <section class="dash-card">
                        <div class="dash-card-body"><asp:Literal ID="lt2" runat="server"></asp:Literal><div id="chart_div2" class="chart-box"></div></div>
                    </section>
                </div>
                <div class="col-md-12">
                    <section class="dash-card">
                        <div class="dash-card-body"><asp:Literal ID="lt3" runat="server"></asp:Literal><div id="chart_div3" class="chart-box"></div></div>
                    </section>
                </div>
                <div class="col-md-12">
                    <section class="dash-card">
                        <div class="dash-card-body"><asp:Literal ID="lt4" runat="server"></asp:Literal><div id="chart_div4" class="chart-box"></div></div>
                    </section>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/essential-plugins.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
</asp:Content>

