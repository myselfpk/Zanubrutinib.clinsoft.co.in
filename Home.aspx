<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/tabIcon.png" />
    <link rel="stylesheet" type="text/css" href="~/css/main.css" runat="server" />
    <link rel="stylesheet" type="text/css" href="~/css/dashboard.css?v=20260731.3" runat="server" />
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        if (window.google && window.google.charts) {
            window.google.charts.load('current', { packages: ['corechart'] });
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="content-wrapper">
        <div class="page-title dashboard-page-title">
            <div>
                <h1><i class="fa fa-dashboard" aria-hidden="true"></i>Clinical Dashboard</h1>
                <p>Study operations and site performance overview</p>
            </div>
            <div class="dashboard-title-meta">
                <ul class="breadcrumb">
                    <li><i class="fa fa-home fa-lg" aria-hidden="true"></i></li>
                    <li class="active">Dashboard</li>
                </ul>
                <span><i class="fa fa-user" aria-hidden="true"></i><asp:Label ID="lblDashboardUser" runat="server" Text="Study user" /></span>
                <small><i class="fa fa-clock-o" aria-hidden="true"></i>Updated <asp:Label ID="lblLastUpdated" runat="server" /></small>
            </div>
        </div>

        <asp:Panel ID="pnlDashboardNotice" runat="server" Visible="false" CssClass="alert alert-warning dashboard-alert" role="alert">
            <i class="fa fa-info-circle" aria-hidden="true"></i>
            <asp:Label ID="lblDashboardNotice" runat="server" />
        </asp:Panel>

        <section aria-labelledby="keyMetricsTitle">
            <h2 id="keyMetricsTitle" class="sr-only">Key study metrics</h2>
            <div class="row dashboard-kpi-row">
                <div class="col-xs-12 col-sm-6 col-lg-3">
                    <div class="widget-small primary coloured-icon dashboard-kpi">
                        <i class="icon fa fa-users fa-3x" aria-hidden="true"></i>
                        <div class="info">
                            <h4>Screened subjects</h4>
                            <p><b><asp:Label ID="lblScreenedSubjects" runat="server" Text="0" /></b></p>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6 col-lg-3">
                    <div class="widget-small info coloured-icon dashboard-kpi">
                        <i class="icon fa fa-check-circle fa-3x" aria-hidden="true"></i>
                        <div class="info">
                            <h4>Completed study</h4>
                            <p><b><asp:Label ID="lblCompletedSubjects" runat="server" Text="0" /></b></p>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6 col-lg-3">
                    <div class="widget-small danger coloured-icon dashboard-kpi">
                        <i class="icon fa fa-question-circle fa-3x" aria-hidden="true"></i>
                        <div class="info">
                            <h4>Open queries</h4>
                            <p><b><asp:Label ID="lblOpenQueries" runat="server" Text="0" /></b></p>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6 col-lg-3">
                    <div class="widget-small warning coloured-icon dashboard-kpi">
                        <i class="icon fa fa-pencil-square-o fa-3x" aria-hidden="true"></i>
                        <div class="info">
                            <h4>PI signed pages</h4>
                            <p><b><asp:Label ID="lblSignedPages" runat="server" Text="0" /></b></p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section id="pnlSiteSummary" runat="server" visible="false" class="dashboard-site-section" aria-labelledby="siteDetailsTitle">
            <div class="row">
                <div class="col-xs-12">
                    <div class="card dashboard-site-card">
                        <h2 id="siteDetailsTitle" class="card-title"><i class="fa fa-hospital-o" aria-hidden="true"></i>Assigned site details</h2>
                        <div class="row">
                            <div class="col-xs-12 col-sm-4 col-lg-3">
                                <div class="dashboard-site-item">
                                    <span class="dashboard-site-icon"><i class="fa fa-hospital-o" aria-hidden="true"></i></span>
                                    <span class="dashboard-site-label">Site number</span>
                                    <strong><asp:Label ID="lblSiteNumber" runat="server" Text="-" /></strong>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-8 col-lg-4">
                                <div class="dashboard-site-item">
                                    <span class="dashboard-site-icon dashboard-site-icon--blue"><i class="fa fa-user-md" aria-hidden="true"></i></span>
                                    <span class="dashboard-site-label">Principal investigator</span>
                                    <strong><asp:Label ID="lblPIName" runat="server" Text="-" /></strong>
                                </div>
                            </div>
                            <div class="col-xs-12 col-lg-5">
                                <div class="dashboard-site-item dashboard-site-address">
                                    <span class="dashboard-site-icon dashboard-site-icon--amber"><i class="fa fa-map-marker" aria-hidden="true"></i></span>
                                    <span class="dashboard-site-label">Site address</span>
                                    <strong><asp:Label ID="lblSiteAddress" runat="server" Text="-" /></strong>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section aria-labelledby="analyticsTitle">
            <h2 id="analyticsTitle" class="sr-only">Study performance charts</h2>

            <noscript>
                <div class="alert alert-info dashboard-alert"><i class="fa fa-info-circle" aria-hidden="true"></i>Enable JavaScript to view dashboard charts.</div>
            </noscript>

            <div class="row">
                <div class="col-xs-12 col-lg-7">
                    <div class="card dashboard-chart-card">
                        <div class="dashboard-card-header">
                            <h3 id="recruitmentChartTitle" class="card-title"><i class="fa fa-users text-teal" aria-hidden="true"></i>Recruitment overview</h3>
                            <p id="recruitmentChartDescription">Screened, withdrawn and completed subjects</p>
                        </div>
                        <div class="dashboard-chart-body">
                            <div id="chart_div1" class="chart-box" role="img" aria-label="Recruitment overview chart" aria-describedby="recruitmentChartDescription">
                                <div class="chart-placeholder"><i class="fa fa-bar-chart" aria-hidden="true"></i><strong>No recruitment data yet</strong><span>Data will appear when subjects are recorded.</span></div>
                            </div>
                            <asp:Literal ID="lt1" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-lg-5">
                    <div class="card dashboard-chart-card">
                        <div class="dashboard-card-header">
                            <h3 id="queryChartTitle" class="card-title"><i class="fa fa-question-circle text-red" aria-hidden="true"></i>Query management</h3>
                            <p id="queryChartDescription">Open, responded and closed data queries</p>
                        </div>
                        <div class="dashboard-chart-body">
                            <div id="chart_div2" class="chart-box" role="img" aria-label="Query management chart" aria-describedby="queryChartDescription">
                                <div class="chart-placeholder"><i class="fa fa-bar-chart" aria-hidden="true"></i><strong>No query data yet</strong><span>Query totals will appear when available.</span></div>
                            </div>
                            <asp:Literal ID="lt2" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-lg-5">
                    <div class="card dashboard-chart-card">
                        <div class="dashboard-card-header">
                            <h3 id="signatureChartTitle" class="card-title"><i class="fa fa-pencil-square-o text-blue" aria-hidden="true"></i>PI signature status</h3>
                            <p id="signatureChartDescription">Total, unsigned and electronically signed pages</p>
                        </div>
                        <div class="dashboard-chart-body">
                            <div id="chart_div3" class="chart-box" role="img" aria-label="PI signature status chart" aria-describedby="signatureChartDescription">
                                <div class="chart-placeholder"><i class="fa fa-bar-chart" aria-hidden="true"></i><strong>No signature data yet</strong><span>Signature progress will appear when available.</span></div>
                            </div>
                            <asp:Literal ID="lt3" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-lg-7">
                    <div class="card dashboard-chart-card">
                        <div class="dashboard-card-header">
                            <h3 id="pageStatusChartTitle" class="card-title"><i class="fa fa-file-text-o text-amber" aria-hidden="true"></i>eCRF page status</h3>
                            <p id="pageStatusChartDescription">Saved, submitted, SDV and locking progress</p>
                        </div>
                        <div class="dashboard-chart-body">
                            <div id="chart_div4" class="chart-box" role="img" aria-label="eCRF page status chart" aria-describedby="pageStatusChartDescription">
                                <div class="chart-placeholder"><i class="fa fa-bar-chart" aria-hidden="true"></i><strong>No page-status data yet</strong><span>Page progress will appear when available.</span></div>
                            </div>
                            <asp:Literal ID="lt4" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/essential-plugins.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
    <script type="text/javascript">
        (function (window, document) {
            var resizeTimer;

            function redrawDashboardCharts() {
                var charts = window.clinsoftDashboardCharts || [];
                for (var index = 0; index < charts.length; index++) {
                    try {
                        charts[index]();
                    } catch (error) {
                        if (window.console && window.console.warn) {
                            window.console.warn('Dashboard chart redraw failed.', error);
                        }
                    }
                }
            }

            function queueDashboardRedraw() {
                window.clearTimeout(resizeTimer);
                resizeTimer = window.setTimeout(redrawDashboardCharts, 180);
            }

            if (window.addEventListener) {
                window.addEventListener('resize', queueDashboardRedraw);
            }

            var wrapper = document.querySelector('.content-wrapper');
            if (wrapper && wrapper.addEventListener) {
                wrapper.addEventListener('transitionend', function (event) {
                    if (event.target === wrapper && (event.propertyName === 'margin-left' || event.propertyName === 'transform' || event.propertyName === 'width')) {
                        queueDashboardRedraw();
                    }
                });
            }

            if (window.jQuery) {
                window.jQuery(document).on('shown.bs.tab shown.bs.collapse', queueDashboardRedraw);
            }
        })(window, document);
    </script>
</asp:Content>
