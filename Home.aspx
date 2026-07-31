<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/tabIcon.png" />
    <link rel="stylesheet" type="text/css" href="~/css/main.css" runat="server" />
    <link rel="stylesheet" type="text/css" href="~/css/dashboard.css?v=20260731.2" runat="server" />
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        if (window.google && window.google.charts) {
            window.google.charts.load('current', { packages: ['corechart'] });
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="content-wrapper">
        <div class="dashboard-page">
            <header class="dashboard-header" aria-labelledby="dashboardTitle">
                <div class="row">
                    <div class="col-xs-12 col-sm-8">
                        <span class="dashboard-eyebrow">Study overview</span>
                        <h1 id="dashboardTitle">Clinical dashboard</h1>
                        <p>Recruitment, queries, signatures and eCRF activity for your assigned sites.</p>
                    </div>
                    <div class="col-xs-12 col-sm-4 dashboard-header-meta">
                        <span class="dashboard-user"><i class="fa fa-user" aria-hidden="true"></i><asp:Label ID="lblDashboardUser" runat="server" Text="Study user" /></span>
                        <span class="dashboard-updated"><i class="fa fa-clock-o" aria-hidden="true"></i>Updated <asp:Label ID="lblLastUpdated" runat="server" /></span>
                    </div>
                </div>
            </header>

            <asp:Panel ID="pnlDashboardNotice" runat="server" Visible="false" CssClass="alert alert-warning dashboard-alert" role="alert">
                <i class="fa fa-info-circle" aria-hidden="true"></i>
                <asp:Label ID="lblDashboardNotice" runat="server" />
            </asp:Panel>

            <section class="dashboard-section" aria-labelledby="keyMetricsTitle">
                <div class="dashboard-section-heading clearfix">
                    <h2 id="keyMetricsTitle">Key study metrics</h2>
                    <p>Current totals across assigned sites</p>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-lg-3">
                        <div class="dashboard-stat">
                            <span class="dashboard-stat-icon"><i class="fa fa-users" aria-hidden="true"></i></span>
                            <span class="dashboard-stat-label">Screened subjects</span>
                            <strong><asp:Label ID="lblScreenedSubjects" runat="server" Text="0" /></strong>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-lg-3">
                        <div class="dashboard-stat dashboard-stat--green">
                            <span class="dashboard-stat-icon"><i class="fa fa-check-circle" aria-hidden="true"></i></span>
                            <span class="dashboard-stat-label">Completed study</span>
                            <strong><asp:Label ID="lblCompletedSubjects" runat="server" Text="0" /></strong>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-lg-3">
                        <div class="dashboard-stat dashboard-stat--red">
                            <span class="dashboard-stat-icon"><i class="fa fa-question-circle" aria-hidden="true"></i></span>
                            <span class="dashboard-stat-label">Open queries</span>
                            <strong><asp:Label ID="lblOpenQueries" runat="server" Text="0" /></strong>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-lg-3">
                        <div class="dashboard-stat dashboard-stat--blue">
                            <span class="dashboard-stat-icon"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></span>
                            <span class="dashboard-stat-label">PI signed pages</span>
                            <strong><asp:Label ID="lblSignedPages" runat="server" Text="0" /></strong>
                        </div>
                    </div>
                </div>
            </section>

            <section id="pnlSiteSummary" runat="server" visible="false" class="dashboard-section" aria-labelledby="siteDetailsTitle">
                <div class="dashboard-section-heading clearfix">
                    <h2 id="siteDetailsTitle">Assigned site details</h2>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-lg-3">
                        <div class="dashboard-info-card">
                            <span class="dashboard-info-icon"><i class="fa fa-hospital-o" aria-hidden="true"></i></span>
                            <span class="dashboard-info-label">Site number</span>
                            <strong><asp:Label ID="lblSiteNumber" runat="server" Text="-" /></strong>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-lg-4">
                        <div class="dashboard-info-card dashboard-info-card--blue">
                            <span class="dashboard-info-icon"><i class="fa fa-user-md" aria-hidden="true"></i></span>
                            <span class="dashboard-info-label">Principal investigator</span>
                            <strong><asp:Label ID="lblPIName" runat="server" Text="-" /></strong>
                        </div>
                    </div>
                    <div class="col-xs-12 col-lg-5">
                        <div class="dashboard-info-card dashboard-info-card--amber">
                            <span class="dashboard-info-icon"><i class="fa fa-map-marker" aria-hidden="true"></i></span>
                            <span class="dashboard-info-label">Site address</span>
                            <strong class="dashboard-info-address"><asp:Label ID="lblSiteAddress" runat="server" Text="-" /></strong>
                        </div>
                    </div>
                </div>
            </section>

            <section class="dashboard-section" aria-labelledby="analyticsTitle">
                <div class="dashboard-section-heading clearfix">
                    <h2 id="analyticsTitle">Study performance</h2>
                    <p>Charts reflect data available for your assigned sites</p>
                </div>

                <noscript>
                    <div class="alert alert-info dashboard-alert"><i class="fa fa-info-circle" aria-hidden="true"></i>Enable JavaScript to view dashboard charts.</div>
                </noscript>

                <div class="row">
                    <div class="col-xs-12 col-lg-6">
                        <section class="panel panel-default dashboard-panel" aria-labelledby="recruitmentChartTitle">
                            <div class="panel-heading">
                                <h3 id="recruitmentChartTitle" class="panel-title"><i class="fa fa-users text-teal" aria-hidden="true"></i>Recruitment overview</h3>
                                <p id="recruitmentChartDescription">Screened, withdrawn and completed subjects</p>
                            </div>
                            <div class="panel-body">
                                <div id="chart_div1" class="chart-box" role="img" aria-label="Recruitment overview chart" aria-describedby="recruitmentChartDescription chart_div1_data">
                                    <div class="chart-placeholder"><i class="fa fa-bar-chart" aria-hidden="true"></i><strong>No recruitment data yet</strong><span>Data will appear when subjects are recorded.</span></div>
                                </div>
                                <asp:Literal ID="lt1" runat="server"></asp:Literal>
                            </div>
                        </section>
                    </div>
                    <div class="col-xs-12 col-lg-6">
                        <section class="panel panel-default dashboard-panel" aria-labelledby="queryChartTitle">
                            <div class="panel-heading">
                                <h3 id="queryChartTitle" class="panel-title"><i class="fa fa-question-circle text-red" aria-hidden="true"></i>Query management</h3>
                                <p id="queryChartDescription">Open, responded and closed data queries</p>
                            </div>
                            <div class="panel-body">
                                <div id="chart_div2" class="chart-box" role="img" aria-label="Query management chart" aria-describedby="queryChartDescription chart_div2_data">
                                    <div class="chart-placeholder"><i class="fa fa-bar-chart" aria-hidden="true"></i><strong>No query data yet</strong><span>Query totals will appear when available.</span></div>
                                </div>
                                <asp:Literal ID="lt2" runat="server"></asp:Literal>
                            </div>
                        </section>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-12">
                        <section class="panel panel-default dashboard-panel" aria-labelledby="signatureChartTitle">
                            <div class="panel-heading">
                                <h3 id="signatureChartTitle" class="panel-title"><i class="fa fa-pencil-square-o text-blue" aria-hidden="true"></i>PI signature status</h3>
                                <p id="signatureChartDescription">Total, unsigned and electronically signed pages</p>
                            </div>
                            <div class="panel-body">
                                <div id="chart_div3" class="chart-box" role="img" aria-label="PI signature status chart" aria-describedby="signatureChartDescription chart_div3_data">
                                    <div class="chart-placeholder"><i class="fa fa-bar-chart" aria-hidden="true"></i><strong>No signature data yet</strong><span>Signature progress will appear when available.</span></div>
                                </div>
                                <asp:Literal ID="lt3" runat="server"></asp:Literal>
                            </div>
                        </section>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-12">
                        <section class="panel panel-default dashboard-panel" aria-labelledby="pageStatusChartTitle">
                            <div class="panel-heading">
                                <h3 id="pageStatusChartTitle" class="panel-title"><i class="fa fa-file-text-o text-amber" aria-hidden="true"></i>eCRF page status</h3>
                                <p id="pageStatusChartDescription">Saved, submitted, SDV and locking progress</p>
                            </div>
                            <div class="panel-body">
                                <div id="chart_div4" class="chart-box" role="img" aria-label="eCRF page status chart" aria-describedby="pageStatusChartDescription chart_div4_data">
                                    <div class="chart-placeholder"><i class="fa fa-bar-chart" aria-hidden="true"></i><strong>No page-status data yet</strong><span>Page progress will appear when available.</span></div>
                                </div>
                                <asp:Literal ID="lt4" runat="server"></asp:Literal>
                            </div>
                        </section>
                    </div>
                </div>
            </section>
        </div>
    </div>

    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/essential-plugins.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
</asp:Content>
