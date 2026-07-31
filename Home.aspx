<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/tabIcon.png" />
    <link rel="stylesheet" type="text/css" href="~/css/main.css" runat="server" />
    <link rel="stylesheet" type="text/css" href="~/css/dashboard.css?v=20260731.1" runat="server" />
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        if (window.google && window.google.charts) {
            window.google.charts.load('current', { packages: ['corechart'] });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="content-wrapper dashboard-page">
        <div class="dashboard-shell">
            <section class="dashboard-hero" aria-labelledby="dashboardTitle">
                <div class="dashboard-hero__copy">
                    <span class="dashboard-eyebrow">Study command center</span>
                    <h1 id="dashboardTitle">Welcome back, <asp:Label ID="lblDashboardUser" runat="server" Text="Study team" /></h1>
                    <p>Track recruitment, queries, signatures and eCRF progress across your assigned study sites.</p>
                </div>
                <div class="dashboard-hero__meta" aria-label="Dashboard context">
                    <span class="dashboard-hero__badge">
                        <i class="fa fa-flask" aria-hidden="true"></i>
                        <span><small>Active protocol</small><strong>GPL ZANU-401</strong></span>
                    </span>
                    <span class="dashboard-updated"><i class="fa fa-clock-o" aria-hidden="true"></i> Updated <asp:Label ID="lblLastUpdated" runat="server" /></span>
                </div>
            </section>

            <asp:Panel ID="pnlDashboardNotice" runat="server" Visible="false" CssClass="dashboard-alert" role="alert">
                <i class="fa fa-info-circle" aria-hidden="true"></i>
                <asp:Label ID="lblDashboardNotice" runat="server" />
            </asp:Panel>

            <section class="dashboard-section dashboard-kpis" aria-labelledby="keyMetricsTitle">
                <header class="dashboard-section-heading">
                    <div class="dashboard-section-heading__icon"><i class="fa fa-line-chart" aria-hidden="true"></i></div>
                    <div class="dashboard-section-heading__copy">
                        <span>At a glance</span>
                        <h2 id="keyMetricsTitle">Key study metrics</h2>
                    </div>
                </header>
                <div class="dashboard-kpi-grid">
                    <div class="dashboard-kpi-card dashboard-kpi-card--teal">
                        <span class="dashboard-kpi-icon"><i class="fa fa-users" aria-hidden="true"></i></span>
                        <div><span class="dashboard-kpi-label">Screened subjects</span><strong><asp:Label ID="lblScreenedSubjects" runat="server" Text="0" /></strong><small>Across assigned sites</small></div>
                    </div>
                    <div class="dashboard-kpi-card dashboard-kpi-card--green">
                        <span class="dashboard-kpi-icon"><i class="fa fa-check-circle" aria-hidden="true"></i></span>
                        <div><span class="dashboard-kpi-label">Completed study</span><strong><asp:Label ID="lblCompletedSubjects" runat="server" Text="0" /></strong><small>Recorded completions</small></div>
                    </div>
                    <div class="dashboard-kpi-card dashboard-kpi-card--red">
                        <span class="dashboard-kpi-icon"><i class="fa fa-question-circle" aria-hidden="true"></i></span>
                        <div><span class="dashboard-kpi-label">Open queries</span><strong><asp:Label ID="lblOpenQueries" runat="server" Text="0" /></strong><small>Awaiting resolution</small></div>
                    </div>
                    <div class="dashboard-kpi-card dashboard-kpi-card--blue">
                        <span class="dashboard-kpi-icon"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></span>
                        <div><span class="dashboard-kpi-label">PI signed pages</span><strong><asp:Label ID="lblSignedPages" runat="server" Text="0" /></strong><small>Electronic signatures</small></div>
                    </div>
                </div>
            </section>

            <section id="pnlSiteSummary" runat="server" visible="false" class="dashboard-section dashboard-site-section" aria-labelledby="siteDetailsTitle">
                <header class="dashboard-section-heading">
                    <div class="dashboard-section-heading__icon dashboard-section-heading__icon--blue"><i class="fa fa-hospital-o" aria-hidden="true"></i></div>
                    <div class="dashboard-section-heading__copy">
                        <span>Your assignment</span>
                        <h2 id="siteDetailsTitle">Site details</h2>
                    </div>
                </header>
                <div class="dashboard-summary-grid">
                    <div class="dashboard-summary-card dashboard-summary-card--site">
                        <span class="dashboard-summary-icon"><i class="fa fa-hospital-o" aria-hidden="true"></i></span>
                        <div><span class="dashboard-summary-label">Site number</span><strong class="dashboard-summary-value"><asp:Label ID="lblSiteNumber" runat="server" Text="-" /></strong></div>
                    </div>
                    <div class="dashboard-summary-card dashboard-summary-card--investigator">
                        <span class="dashboard-summary-icon"><i class="fa fa-user-md" aria-hidden="true"></i></span>
                        <div><span class="dashboard-summary-label">Principal investigator</span><strong class="dashboard-summary-value"><asp:Label ID="lblPIName" runat="server" Text="-" /></strong></div>
                    </div>
                    <div class="dashboard-summary-card dashboard-summary-card--address">
                        <span class="dashboard-summary-icon"><i class="fa fa-map-marker" aria-hidden="true"></i></span>
                        <div><span class="dashboard-summary-label">Site address</span><strong class="dashboard-summary-value"><asp:Label ID="lblSiteAddress" runat="server" Text="-" /></strong></div>
                    </div>
                </div>
            </section>

            <section class="dashboard-section dashboard-analytics" aria-labelledby="analyticsTitle">
                <header class="dashboard-section-heading dashboard-section-heading--with-note">
                    <div class="dashboard-section-heading__icon dashboard-section-heading__icon--amber"><i class="fa fa-bar-chart" aria-hidden="true"></i></div>
                    <div class="dashboard-section-heading__copy">
                        <span>Operational analytics</span>
                        <h2 id="analyticsTitle">Study performance</h2>
                    </div>
                    <p>Charts reflect sites assigned to your account.</p>
                </header>
                <noscript><div class="dashboard-alert"><i class="fa fa-info-circle" aria-hidden="true"></i> Enable JavaScript to view dashboard charts.</div></noscript>
                <div class="dashboard-chart-grid">
                    <article class="dashboard-chart-card">
                        <header class="dashboard-chart-card__header">
                            <span class="dashboard-chart-card__icon dashboard-chart-card__icon--teal"><i class="fa fa-users" aria-hidden="true"></i></span>
                            <div><h3>Recruitment overview</h3><p id="recruitmentChartDescription">Screened, withdrawn and completed subjects</p></div>
                        </header>
                        <div class="dashboard-chart-card__body">
                            <div id="chart_div1" class="chart-box" role="img" aria-label="Recruitment overview chart" aria-describedby="recruitmentChartDescription chart_div1_data"><div class="chart-placeholder"><i class="fa fa-bar-chart" aria-hidden="true"></i><strong>No recruitment data yet</strong><span>Data will appear when subjects are recorded.</span></div></div>
                            <asp:Literal ID="lt1" runat="server"></asp:Literal>
                        </div>
                    </article>
                    <article class="dashboard-chart-card">
                        <header class="dashboard-chart-card__header">
                            <span class="dashboard-chart-card__icon dashboard-chart-card__icon--red"><i class="fa fa-question-circle" aria-hidden="true"></i></span>
                            <div><h3>Query management</h3><p id="queryChartDescription">Open, responded and closed data queries</p></div>
                        </header>
                        <div class="dashboard-chart-card__body">
                            <div id="chart_div2" class="chart-box" role="img" aria-label="Query management chart" aria-describedby="queryChartDescription chart_div2_data"><div class="chart-placeholder"><i class="fa fa-bar-chart" aria-hidden="true"></i><strong>No query data yet</strong><span>Query totals will appear when available.</span></div></div>
                            <asp:Literal ID="lt2" runat="server"></asp:Literal>
                        </div>
                    </article>
                    <article class="dashboard-chart-card">
                        <header class="dashboard-chart-card__header">
                            <span class="dashboard-chart-card__icon dashboard-chart-card__icon--blue"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></span>
                            <div><h3>PI signature status</h3><p id="signatureChartDescription">Total, unsigned and electronically signed pages</p></div>
                        </header>
                        <div class="dashboard-chart-card__body">
                            <div id="chart_div3" class="chart-box" role="img" aria-label="PI signature status chart" aria-describedby="signatureChartDescription chart_div3_data"><div class="chart-placeholder"><i class="fa fa-bar-chart" aria-hidden="true"></i><strong>No signature data yet</strong><span>Signature progress will appear when available.</span></div></div>
                            <asp:Literal ID="lt3" runat="server"></asp:Literal>
                        </div>
                    </article>
                    <article class="dashboard-chart-card">
                        <header class="dashboard-chart-card__header">
                            <span class="dashboard-chart-card__icon dashboard-chart-card__icon--amber"><i class="fa fa-file-text-o" aria-hidden="true"></i></span>
                            <div><h3>eCRF page status</h3><p id="pageStatusChartDescription">Saved, submitted, SDV and locking progress</p></div>
                        </header>
                        <div class="dashboard-chart-card__body">
                            <div id="chart_div4" class="chart-box" role="img" aria-label="eCRF page status chart" aria-describedby="pageStatusChartDescription chart_div4_data"><div class="chart-placeholder"><i class="fa fa-bar-chart" aria-hidden="true"></i><strong>No page-status data yet</strong><span>Page progress will appear when available.</span></div></div>
                            <asp:Literal ID="lt4" runat="server"></asp:Literal>
                        </div>
                    </article>
                </div>
            </section>
        </div>
    </div>
    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/essential-plugins.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
</asp:Content>
