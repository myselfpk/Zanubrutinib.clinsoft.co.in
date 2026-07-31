using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    private const string DashboardDataErrorMessage =
        "Some dashboard data could not be loaded. Please refresh the page or contact the study administrator.";

    private string ConnectionString
    {
        get
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["constr"];
            return settings == null ? String.Empty : settings.ConnectionString;
        }
    }

    private string CurrentUserName
    {
        get { return Convert.ToString(Session["UserName"], CultureInfo.InvariantCulture); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        BindDashboardHeader();

        string userName = CurrentUserName;
        if (String.IsNullOrWhiteSpace(userName))
        {
            pnlSiteSummary.Visible = false;
            ShowDashboardNotice("Your session details are unavailable. Please sign in again to load dashboard data.");
            MarkDashboardUnavailable();
            return;
        }

        BindSiteDetails(userName);

        if (IsPostBack)
            return;

        ResetMetricLabels();
        BindChart1(userName);
        BindChart2(userName);
        BindChart3(userName);
        BindChart4(userName);
    }

    private void BindDashboardHeader()
    {
        string userName = CurrentUserName;
        lblDashboardUser.Text = HttpUtility.HtmlEncode(
            String.IsNullOrWhiteSpace(userName) ? "Study team" : userName.Trim());

        DateTime updatedAt = DateTime.Now;
        try
        {
            TimeZoneInfo indiaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            updatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, indiaTimeZone);
        }
        catch (TimeZoneNotFoundException)
        {
            // The server's local time is used when the configured study time zone is unavailable.
        }
        catch (InvalidTimeZoneException)
        {
            // The server's local time is used when the configured study time zone is invalid.
        }

        lblLastUpdated.Text = HttpUtility.HtmlEncode(
            updatedAt.ToString("dd MMM yyyy, hh:mm tt", CultureInfo.InvariantCulture));
    }

    private void ResetMetricLabels()
    {
        lblScreenedSubjects.Text = "0";
        lblCompletedSubjects.Text = "0";
        lblOpenQueries.Text = "0";
        lblSignedPages.Text = "0";
    }

    private void BindSiteDetails(string userName)
    {
        try
        {
            SiteInfo info = GetSiteDetailsForCRC(userName);
            if (info == null)
            {
                pnlSiteSummary.Visible = false;
                return;
            }

            pnlSiteSummary.Visible = true;
            lblSiteNumber.Text = EncodeDisplayValue(info.SiteNumber);
            lblPIName.Text = EncodeDisplayValue(info.PIName);
            lblSiteAddress.Text = EncodeDisplayValue(info.SiteAddress);
        }
        catch (Exception exception)
        {
            pnlSiteSummary.Visible = false;
            HandleDashboardError("Site details", exception);
        }
    }

    private SiteInfo GetSiteDetailsForCRC(string userName)
    {
        const string sql = @"
SELECT TOP (1)
    s.CenterNumber AS SiteNumber,
    s.PIName AS PIName,
    s.CenterAddress AS SiteAddress
FROM dbo.tbl_UserLogin AS ul
INNER JOIN dbo.tblEnrollUsersWithSite AS eu
    ON ul.UserName = eu.UserName
INNER JOIN dbo.Site AS s
    ON LTRIM(RTRIM(s.CenterNumber)) = LTRIM(RTRIM(eu.CenterNumber))
WHERE ul.UserName = @UserName
  AND ul.UserRole = 'Clinical Research Coordinator'
  AND ISNULL(ul.IsActive, 0) = 1
  AND ISNULL(ul.IsDelete, 0) = 0
ORDER BY s.Id DESC;";

        using (SqlConnection connection = CreateConnection())
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            command.Parameters.Add("@UserName", SqlDbType.NVarChar, 250).Value = userName;
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
            {
                if (!reader.Read())
                    return null;

                return new SiteInfo
                {
                    SiteNumber = Convert.ToString(reader["SiteNumber"], CultureInfo.InvariantCulture),
                    PIName = Convert.ToString(reader["PIName"], CultureInfo.InvariantCulture),
                    SiteAddress = Convert.ToString(reader["SiteAddress"], CultureInfo.InvariantCulture)
                };
            }
        }
    }

    private DataTable GetData1(string userName)
    {
        const string sql = @"
SELECT
    enrollment.CenterNumber AS [Site Number],
    COUNT(subject.SUBNUM) AS [Screened Subjects],
    COUNT(withdrawal.SUBNUM) AS [Subject Withdrawal],
    COUNT(completion.SUBNUM) AS [Completed Subjects]
FROM dbo.Subject AS subject
LEFT JOIN dbo.tblEnrollUsersWithSite AS enrollment
    ON subject.SITENUM = enrollment.CenterNumber
LEFT JOIN [Add].[EndOfStudyLog] AS withdrawal
    ON withdrawal.SUBNUM = subject.SUBNUM
   AND withdrawal.SITENUM = subject.SITENUM
   AND withdrawal.EOSPER = 'No'
LEFT JOIN [Add].[EndOfStudyLog] AS completion
    ON completion.SUBNUM = subject.SUBNUM
   AND completion.SITENUM = subject.SITENUM
   AND completion.EOSPER = 'Yes'
WHERE enrollment.UserName = @UserName
GROUP BY enrollment.CenterNumber
ORDER BY enrollment.CenterNumber;";

        return ExecuteDashboardQuery(sql, userName);
    }

    private void BindChart1(string userName)
    {
        lt1.Text = String.Empty;

        try
        {
            DataTable data = GetData1(userName);
            lblScreenedSubjects.Text = FormatCount(SumColumn(data, "Screened Subjects"));
            lblCompletedSubjects.Text = FormatCount(SumColumn(data, "Completed Subjects"));

            RenderColumnChart(
                lt1,
                "chart_div1",
                data,
                "Site Number",
                "Site",
                new[] { "Screened Subjects", "Subject Withdrawal", "Completed Subjects" },
                new[] { "Screened", "Withdrawn", "Completed" },
                new[] { "#0f766e", "#c2413b", "#2f855a" },
                "Recruitment totals by assigned study site");
        }
        catch (Exception exception)
        {
            lblScreenedSubjects.Text = "—";
            lblCompletedSubjects.Text = "—";
            MarkChartUnavailable(lt1, "chart_div1");
            HandleDashboardError("Recruitment chart", exception);
        }
    }

    private DataTable GetData2(string userName)
    {
        const string sql = @"
;WITH QueryCounts (Site, [Status], Total) AS
(
    SELECT
        enrollment.CenterNumber,
        studyQuery.[Status],
        COUNT(studyQuery.[Status])
    FROM dbo.tblEnrollUsersWithSite AS enrollment
    INNER JOIN dbo.tblQuery AS studyQuery
        ON studyQuery.Site = enrollment.CenterNumber
    WHERE enrollment.UserName = @UserName
    GROUP BY enrollment.CenterNumber, studyQuery.[Status]
)
SELECT
    Site,
    ISNULL([Open], 0) AS [Open Queries],
    ISNULL([Query Responded], 0) AS [Responded Queries],
    ISNULL([Close], 0) AS [Close Queries]
FROM QueryCounts
PIVOT
(
    SUM(Total) FOR [Status] IN ([Open], [Close], [Query Responded])
) AS PivotedQueries
ORDER BY Site;";

        return ExecuteDashboardQuery(sql, userName);
    }

    private void BindChart2(string userName)
    {
        lt2.Text = String.Empty;

        try
        {
            DataTable data = GetData2(userName);
            lblOpenQueries.Text = FormatCount(SumColumn(data, "Open Queries"));

            RenderColumnChart(
                lt2,
                "chart_div2",
                data,
                "Site",
                "Site",
                new[] { "Open Queries", "Responded Queries", "Close Queries" },
                new[] { "Open", "Responded", "Closed" },
                new[] { "#c2413b", "#d97706", "#2f855a" },
                "Query status totals by assigned study site");
        }
        catch (Exception exception)
        {
            lblOpenQueries.Text = "—";
            MarkChartUnavailable(lt2, "chart_div2");
            HandleDashboardError("Query chart", exception);
        }
    }

    private DataTable GetData3(string userName)
    {
        const string sql = @"
SELECT
    signature.SITENUM AS [Site],
    COUNT(signature.EntryStatus) AS [TotalPages],
    (SELECT COUNT(PISIGN) FROM dbo.tblPISignature WHERE SITENUM = signature.SITENUM AND PISIGN = 0) AS [UnsignedPages],
    (SELECT COUNT(PISIGN) FROM dbo.tblPISignature WHERE SITENUM = signature.SITENUM AND PISIGN = 1) AS [SignedPages]
FROM dbo.tblPISignature AS signature
INNER JOIN
(
    SELECT DISTINCT CenterNumber
    FROM dbo.tblEnrollUsersWithSite
    WHERE UserName = @UserName
) AS assigned
    ON assigned.CenterNumber = signature.SITENUM
GROUP BY signature.SITENUM
ORDER BY signature.SITENUM;";

        return ExecuteDashboardQuery(sql, userName);
    }

    private void BindChart3(string userName)
    {
        lt3.Text = String.Empty;

        try
        {
            DataTable data = GetData3(userName);
            lblSignedPages.Text = FormatCount(SumColumn(data, "SignedPages"));

            RenderColumnChart(
                lt3,
                "chart_div3",
                data,
                "Site",
                "Site",
                new[] { "TotalPages", "UnsignedPages", "SignedPages" },
                new[] { "Total pages", "Unsigned", "Signed" },
                new[] { "#526d82", "#d97706", "#2f855a" },
                "PI signature totals by assigned study site");
        }
        catch (Exception exception)
        {
            lblSignedPages.Text = "—";
            MarkChartUnavailable(lt3, "chart_div3");
            HandleDashboardError("PI signature chart", exception);
        }
    }

    private DataTable GetData4(string userName)
    {
        const string sql = @"
SELECT
    signature.SITENUM AS [Site],
    COUNT(signature.EntryStatus) AS [TotalPages],
    (SELECT COUNT(EntryStatus) FROM dbo.tblPISignature WHERE SITENUM = signature.SITENUM AND EntryStatus = 'Submit') AS [Submit],
    (SELECT COUNT(EntryStatus) FROM dbo.tblPISignature WHERE SITENUM = signature.SITENUM AND EntryStatus = 'Save') AS [Save],
    (SELECT COUNT(LockStatus) FROM dbo.tblPISignature WHERE SITENUM = signature.SITENUM AND LockStatus = 'SDV') AS [SDV],
    (SELECT COUNT(LockStatus) FROM dbo.tblPISignature WHERE SITENUM = signature.SITENUM AND LockStatus = 'Unlocked') AS [Unlocked],
    (SELECT COUNT(LockStatus) FROM dbo.tblPISignature WHERE SITENUM = signature.SITENUM AND LockStatus = 'Locked') AS [Locked]
FROM dbo.tblPISignature AS signature
INNER JOIN
(
    SELECT DISTINCT CenterNumber
    FROM dbo.tblEnrollUsersWithSite
    WHERE UserName = @UserName
) AS assigned
    ON assigned.CenterNumber = signature.SITENUM
GROUP BY signature.SITENUM
ORDER BY signature.SITENUM;";

        return ExecuteDashboardQuery(sql, userName);
    }

    private void BindChart4(string userName)
    {
        lt4.Text = String.Empty;

        try
        {
            DataTable data = GetData4(userName);

            RenderColumnChart(
                lt4,
                "chart_div4",
                data,
                "Site",
                "Site",
                new[] { "TotalPages", "Submit", "Save", "SDV", "Unlocked", "Locked" },
                new[] { "Total pages", "Submitted", "Saved", "SDV", "Unlocked", "Locked" },
                new[] { "#526d82", "#0f766e", "#d97706", "#2563a8", "#7c3aed", "#c2413b" },
                "eCRF page status totals by assigned study site");
        }
        catch (Exception exception)
        {
            MarkChartUnavailable(lt4, "chart_div4");
            HandleDashboardError("eCRF page chart", exception);
        }
    }

    private DataTable ExecuteDashboardQuery(string commandText, string userName)
    {
        DataTable table = new DataTable();

        using (SqlConnection connection = CreateConnection())
        using (SqlCommand command = new SqlCommand(commandText, connection))
        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        {
            command.Parameters.Add("@UserName", SqlDbType.NVarChar, 250).Value = userName;
            adapter.Fill(table);
        }

        return table;
    }

    private SqlConnection CreateConnection()
    {
        if (String.IsNullOrWhiteSpace(ConnectionString))
            throw new ConfigurationErrorsException("The 'constr' database connection string is missing.");

        return new SqlConnection(ConnectionString);
    }

    private void RenderColumnChart(
        Literal target,
        string elementId,
        DataTable table,
        string categoryColumn,
        string categoryHeader,
        string[] valueColumns,
        string[] valueHeaders,
        string[] colors,
        string accessibleCaption)
    {
        if (table == null || table.Rows.Count == 0)
        {
            target.Text = String.Empty;
            return;
        }

        if (valueColumns == null || valueHeaders == null || valueColumns.Length != valueHeaders.Length)
            throw new ArgumentException("Chart columns and headings must have matching lengths.");

        List<object[]> chartRows = new List<object[]>();
        object[] headerRow = new object[valueHeaders.Length + 1];
        headerRow[0] = categoryHeader;

        for (int columnIndex = 0; columnIndex < valueHeaders.Length; columnIndex++)
            headerRow[columnIndex + 1] = valueHeaders[columnIndex];

        chartRows.Add(headerRow);

        foreach (DataRow row in table.Rows)
        {
            object[] chartRow = new object[valueColumns.Length + 1];
            chartRow[0] = Convert.ToString(row[categoryColumn], CultureInfo.InvariantCulture);

            for (int columnIndex = 0; columnIndex < valueColumns.Length; columnIndex++)
                chartRow[columnIndex + 1] = ToLong(row[valueColumns[columnIndex]]);

            chartRows.Add(chartRow);
        }

        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string rowsJson = SerializeForInlineScript(serializer, chartRows);
        string colorsJson = SerializeForInlineScript(serializer, colors ?? new string[0]);
        string elementIdJson = SerializeForInlineScript(serializer, elementId);
        string accessibleTable = BuildAccessibleChartTable(
            elementId + "_data",
            accessibleCaption,
            chartRows);

        StringBuilder script = new StringBuilder();
        script.Append("<script type=\"text/javascript\">(function(){");
        script.Append("var chartRows=").Append(rowsJson).Append(";");
        script.Append("var chartColors=").Append(colorsJson).Append(";");
        script.Append("function drawDashboardChart(){");
        script.Append("var element=document.getElementById(").Append(elementIdJson).Append(");");
        script.Append("if(!element||!window.google||!google.visualization){return;}");
        script.Append("var chartWidth=Math.floor(element.clientWidth||0);");
        script.Append("if(chartWidth<=0){return;}");
        script.Append("var compact=window.innerWidth<768||chartWidth<520;");
        script.Append("var data=google.visualization.arrayToDataTable(chartRows);");
        script.Append("var options={");
        script.Append("backgroundColor:'transparent',");
        script.Append("width:chartWidth,");
        script.Append("height:compact?280:320,");
        script.Append("colors:chartColors,");
        script.Append("fontName:'Segoe UI',");
        script.Append("legend:{position:'top',alignment:'center',maxLines:3,textStyle:{color:'#334e68',fontSize:compact?10:11}},");
        script.Append("chartArea:{left:compact?48:58,top:64,width:compact?'76%':'80%',height:compact?'60%':'64%'},");
        script.Append("bar:{groupWidth:compact?'68%':'58%'},");
        script.Append("hAxis:{textStyle:{color:'#526d82',fontSize:compact?10:11},slantedText:compact,slantedTextAngle:35,baselineColor:'#d5dfdf'},");
        script.Append("vAxis:{minValue:0,format:'0',textStyle:{color:'#526d82',fontSize:10},gridlines:{color:'#edf2f2'},minorGridlines:{color:'transparent'},baselineColor:'#d5dfdf'},");
        script.Append("tooltip:{textStyle:{color:'#243b53',fontSize:12}}");
        script.Append("};");
        script.Append("new google.visualization.ColumnChart(element).draw(data,options);");
        script.Append("}");
        script.Append("function markDashboardChartUnavailable(){");
        script.Append("var element=document.getElementById(").Append(elementIdJson).Append(");");
        script.Append("if(!element){return;}");
        script.Append("var title=element.querySelector('.chart-placeholder strong');");
        script.Append("var message=element.querySelector('.chart-placeholder span');");
        script.Append("if(title){title.textContent='Chart service unavailable';}");
        script.Append("if(message){message.textContent='Refresh the page to try loading this chart again.';}");
        script.Append("}");
        script.Append("window.clinsoftDashboardCharts=window.clinsoftDashboardCharts||[];");
        script.Append("window.clinsoftDashboardCharts.push(drawDashboardChart);");
        script.Append("if(window.google&&window.google.charts){google.charts.setOnLoadCallback(drawDashboardChart);}else{markDashboardChartUnavailable();}");
        script.Append("})();</script>");

        target.Text = accessibleTable + script.ToString();
    }

    private static string BuildAccessibleChartTable(
        string tableId,
        string caption,
        IList<object[]> chartRows)
    {
        if (chartRows == null || chartRows.Count < 2)
            return String.Empty;

        StringBuilder table = new StringBuilder();
        table.Append("<table id=\"")
            .Append(HttpUtility.HtmlAttributeEncode(tableId))
            .Append("\" class=\"sr-only\">");
        table.Append("<caption>")
            .Append(HttpUtility.HtmlEncode(caption))
            .Append("</caption><thead><tr>");

        object[] headers = chartRows[0];
        foreach (object header in headers)
        {
            table.Append("<th scope=\"col\">")
                .Append(HttpUtility.HtmlEncode(Convert.ToString(header, CultureInfo.InvariantCulture)))
                .Append("</th>");
        }

        table.Append("</tr></thead><tbody>");
        for (int rowIndex = 1; rowIndex < chartRows.Count; rowIndex++)
        {
            object[] row = chartRows[rowIndex];
            table.Append("<tr>");

            for (int columnIndex = 0; columnIndex < row.Length; columnIndex++)
            {
                string cellTag = columnIndex == 0 ? "th" : "td";
                table.Append("<").Append(cellTag);
                if (columnIndex == 0)
                    table.Append(" scope=\"row\"");

                table.Append(">")
                    .Append(HttpUtility.HtmlEncode(Convert.ToString(row[columnIndex], CultureInfo.InvariantCulture)))
                    .Append("</").Append(cellTag).Append(">");
            }

            table.Append("</tr>");
        }

        table.Append("</tbody></table>");
        return table.ToString();
    }

    private void MarkDashboardUnavailable()
    {
        lblScreenedSubjects.Text = "—";
        lblCompletedSubjects.Text = "—";
        lblOpenQueries.Text = "—";
        lblSignedPages.Text = "—";

        MarkChartUnavailable(lt1, "chart_div1");
        MarkChartUnavailable(lt2, "chart_div2");
        MarkChartUnavailable(lt3, "chart_div3");
        MarkChartUnavailable(lt4, "chart_div4");
    }

    private static void MarkChartUnavailable(Literal target, string elementId)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string elementIdJson = SerializeForInlineScript(serializer, elementId);

        target.Text =
            "<script type=\"text/javascript\">(function(){" +
            "var element=document.getElementById(" + elementIdJson + ");" +
            "if(!element){return;}" +
            "var title=element.querySelector('.chart-placeholder strong');" +
            "var message=element.querySelector('.chart-placeholder span');" +
            "if(title){title.textContent='Dashboard data unavailable';}" +
            "if(message){message.textContent='Refresh the page or contact the study administrator.';}" +
            "})();</script>";
    }

    private static string SerializeForInlineScript(JavaScriptSerializer serializer, object value)
    {
        return serializer.Serialize(value)
            .Replace("<", "\\u003c")
            .Replace(">", "\\u003e")
            .Replace("&", "\\u0026")
            .Replace("\u2028", "\\u2028")
            .Replace("\u2029", "\\u2029");
    }

    private static long SumColumn(DataTable table, string columnName)
    {
        if (table == null || !table.Columns.Contains(columnName))
            return 0;

        long total = 0;
        foreach (DataRow row in table.Rows)
            total += ToLong(row[columnName]);

        return total;
    }

    private static long ToLong(object value)
    {
        if (value == null || value == DBNull.Value)
            return 0;

        long result;
        return Int64.TryParse(
            Convert.ToString(value, CultureInfo.InvariantCulture),
            NumberStyles.Integer,
            CultureInfo.InvariantCulture,
            out result)
            ? result
            : 0;
    }

    private static string FormatCount(long value)
    {
        return value.ToString("N0", CultureInfo.InvariantCulture);
    }

    private static string EncodeDisplayValue(string value)
    {
        return HttpUtility.HtmlEncode(String.IsNullOrWhiteSpace(value) ? "-" : value.Trim());
    }

    private void HandleDashboardError(string area, Exception exception)
    {
        Trace.Warn("Dashboard", area + " could not be loaded.", exception);
        ShowDashboardNotice(DashboardDataErrorMessage);
    }

    private void ShowDashboardNotice(string message)
    {
        pnlDashboardNotice.Visible = true;
        lblDashboardNotice.Text = HttpUtility.HtmlEncode(message);
    }

    private sealed class SiteInfo
    {
        public string SiteNumber { get; set; }
        public string PIName { get; set; }
        public string SiteAddress { get; set; }
    }
}
