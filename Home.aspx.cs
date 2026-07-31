using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Web.Services;

public partial class _Default : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    SqlConnection conn = new SqlConnection
(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            BindSiteDetails();
            BindChart1();
            BindChart2();
            BindChart3();
            BindChart4();
        }

    }
    private void BindSiteDetails()
    {
        try
        {
            var userName = Convert.ToString(Session["UserName"]);

            if (string.IsNullOrWhiteSpace(userName))
            {
                pnlSiteSummary.Visible = false;
                return;
            }

            var info = GetSiteDetailsForCRC(userName);

            if (info == null)
            {
                // Not CRC OR no mapping found => hide the whole view
                pnlSiteSummary.Visible = false;
                return;
            }

            pnlSiteSummary.Visible = true;
            lblSiteNumber.Text = string.IsNullOrWhiteSpace(info.SiteNumber) ? "-" : info.SiteNumber;
            lblPIName.Text = string.IsNullOrWhiteSpace(info.PIName) ? "-" : info.PIName;
            lblSiteAddress.Text = string.IsNullOrWhiteSpace(info.SiteAddress) ? "-" : info.SiteAddress;
        }
        catch
        {
            pnlSiteSummary.Visible = false;
        }
    }
    private SiteInfo GetSiteDetailsForCRC(string userName)
    {
        const string sql = @"
SELECT TOP (1)
    CAST(s.CenterNumber AS VARCHAR(50))  AS SiteNumber,
    CAST(s.PIName AS VARCHAR(200))       AS PIName,
    CAST(s.CenterAddress AS VARCHAR(500)) AS SiteAddress
FROM dbo.tbl_UserLogin ul
INNER JOIN dbo.tblEnrollUsersWithSite eu
    ON ul.UserName = eu.UserName
INNER JOIN dbo.Site s
    ON LTRIM(RTRIM(s.CenterNumber)) = LTRIM(RTRIM(eu.CenterNumber))
WHERE ul.UserName = @UserName
  AND ul.UserRole = 'Clinical Research Coordinator'
  AND ISNULL(ul.IsActive, 0) = 1
  AND ISNULL(ul.IsDelete, 0) = 0
ORDER BY s.Id DESC;";

        using (var cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 200).Value = userName ?? "";

            if (conn.State != ConnectionState.Open)
                conn.Open();

            using (var rdr = cmd.ExecuteReader(CommandBehavior.SingleRow))
            {
                if (!rdr.Read())
                    return null;

                return new SiteInfo
                {
                    SiteNumber = rdr["SiteNumber"] as string,
                    PIName = rdr["PIName"] as string,
                    SiteAddress = rdr["SiteAddress"] as string
                };
            }
        }
    }
    private class SiteInfo
    {
        public string SiteNumber { get; set; }
        public string PIName { get; set; }
        public string SiteAddress { get; set; }
    }
    private DataTable GetData1()
    {
        DataTable dt = new DataTable();
        //string cmd = "SELECT t3.[CenterNumber] as 'Site Number',count(t2.RANDCRT) as 'Enrolled Subjects',Count(t4.SUBNUM) as 'Subject Withdrawal' ,Count(t1.SUBNUM) as 'Screened Subjects' FROM [dbo].[Subject] t1 LEFT OUTER JOIN [dbo].[tblEnrollUsersWithSite] t3 ON t1.SITENUM =t3.CenterNumber LEFT OUTER JOIN [Visit2].[SubjectEnrolment] t2 ON t2.SUBNUM=t1.SUBNUM and t2.RANDCRT='Yes' Left Outer Join [Add].[StudyCompletionForm] t4 on t4.SUBNUM=t1.SUBNUM and SCFYN='No' WHERE t3.UserName='" + Session["UserName"] + "' group by t3.[CenterNumber]";
        string cmd = "SELECT t3.[CenterNumber] as 'Site Number' ,Count(t1.SUBNUM) as 'Screened Subjects' ,Count(t4.SUBNUM) as 'Subject Withdrawal' ,Count(t5.SUBNUM) as 'Complate Study' FROM [dbo].[Subject] t1 LEFT OUTER JOIN [dbo].[tblEnrollUsersWithSite] t3 ON t1.SITENUM =t3.CenterNumber Left Outer Join [Add].[EndOfStudyLog] t4 on t4.SUBNUM=t1.SUBNUM and t4.EOSPER='No' Left Outer Join [Add].[EndOfStudyLog] t5 on t5.SUBNUM=t1.SUBNUM and t5.EOSPER='Yes' WHERE t3.UserName='" + Session["UserName"] + "' group by t3.[CenterNumber]";
        SqlDataAdapter adp = new SqlDataAdapter(cmd, conn);
        adp.Fill(dt);
        return dt;
    }
    private void BindChart1()
    {
        DataTable dt = new DataTable();
        try
        {
            str.Clear();
            dt = GetData1();

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
                       google.setOnLoadCallback(drawChart);
                       function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Site Number');
        data.addColumn('number', 'Screened');
        data.addColumn('number', 'Withdrawal');
        data.addColumn('number', 'Complete');
        
        data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["Site Number"].ToString() + "');");
                str.Append("data.setValue( " + i + "," + 1 + "," + "'" + dt.Rows[i]["Screened Subjects"].ToString() + "');");
                str.Append("data.setValue( " + i + "," + 2 + "," + "'" + dt.Rows[i]["Subject Withdrawal"].ToString() + "');");
                str.Append("data.setValue( " + i + "," + 3 + "," + "'" + dt.Rows[i]["Complate Study"].ToString() + "');");


            }

            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div1'));");
            str.Append(" chart.draw(data, {width: '100%', height: 300,colors: ['#4671bd', '#199bfc','#DF1212', '#20A006'], legend: {position: 'top', maxLines: 4},bar: { groupWidth: '50%'}, title: 'Status of Recruitment',");
            str.Append("hAxis: {title: 'Sites', titleTextStyle: {color: 'Black'}}");
            str.Append("}); }");
            str.Append("</script>");
            lt1.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        }
        catch
        {
        }
    }
    private DataTable GetData2()
    {
        DataTable dt1 = new DataTable();
        string cmd1 = ";with aa(Site, [Status], counts)as(SELECT o.CenterNumber as 'Site', c.Status as 'Status' , count([Status]) AS counts FROM [tblEnrollUsersWithSite] o, [tblQuery] c WHERE c.Site =o.CenterNumber and o.UserName='" + Session["UserName"] + "' GROUP BY o.CenterNumber,c.Status) SELECT   [Site], [Open] as 'Open Queries', [Close] as 'Close Queries', [Query Responded] as 'Responded Queries' FROM  aa PIVOT(sum(counts)FOR [Status] IN ([Open],   [Close], [Query Responded])) AS P";
        SqlDataAdapter adp = new SqlDataAdapter(cmd1, conn);
        adp.Fill(dt1);
        return dt1;
    }
    private void BindChart2()
    {
        DataTable dt1 = new DataTable();
        try
        {
            str.Clear();
            dt1 = GetData2();

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
                       google.setOnLoadCallback(drawChart);
                       function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Site');
        data.addColumn('number', 'Open'); 
        data.addColumn('number', 'Responded');
        data.addColumn('number', 'Closed');  
        
        data.addRows(" + dt1.Rows.Count + ");");

            for (int i = 0; i <= dt1.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt1.Rows[i]["Site"].ToString() + "');");
                str.Append("data.setValue( " + i + "," + 1 + "," + "'" + dt1.Rows[i]["Open Queries"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 2 + "," + dt1.Rows[i]["Responded Queries"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 3 + "," + dt1.Rows[i]["Close Queries"].ToString() + ") ;");
            }

            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div2'));");
            str.Append(" chart.draw(data, {widt1h: '100%', height: 300,colors: ['#FF0000', '#FFA500','#008000'], legend: {position: 'top', maxLines: 4},bar: { groupWidt1h: '10%'}, title: 'Status of Queries',");
            str.Append("hAxis: {title: 'Sites', titleTextStyle: {color: 'Black'}}");
            str.Append("}); }");
            str.Append("</script>");
            lt2.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        }
        catch
        {
        }
    }
    private DataTable GetData3()
    {
        DataTable dt1 = new DataTable();
        //string cmd1 = "SELECT SITENUM as 'Site', Count(EntryStatus) As TotalPages, count(PISIGN) as UnsignedPages, (SELECT count(PISIGN) FROM [dbo].[tblPISignature] where SITENUM=t1.SITENUM and PISIGN=1) as SignedPages FROM [dbo].[tblPISignature] t1 inner join tblEnrollUsersWithSite t2 on t2.CenterNumber=t1.SITENUM where t1.PISIGN=0 and t2.UserName='" + Session["UserName"] + "' group by t1.SITENUM";

        string cmd1 = "SELECT SITENUM as 'Site' , Count(EntryStatus) As TotalPages , (SELECT count(PISIGN) FROM [dbo].[tblPISignature] where SITENUM=t1.SITENUM and PISIGN=0) as UnsignedPages , (SELECT count(PISIGN) FROM [dbo].[tblPISignature] where SITENUM=t1.SITENUM and PISIGN=1) as SignedPages FROM [dbo].[tblPISignature] t1 inner join tblEnrollUsersWithSite t2 on t2.CenterNumber=t1.SITENUM where t2.UserName='" + Session["UserName"] + "' group by t1.SITENUM";
        SqlDataAdapter adp = new SqlDataAdapter(cmd1, conn);
        adp.Fill(dt1);
        return dt1;
    }
    private void BindChart3()
    {
        DataTable dt1 = new DataTable();
        try
        {
            str.Clear();
            dt1 = GetData3();

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
                       google.setOnLoadCallback(drawChart);
                       function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Site');
        data.addColumn('number', 'Total Pages'); 
        data.addColumn('number', 'Unsigned Pages'); 
        data.addColumn('number', 'Signed Pages');
        
        data.addRows(" + dt1.Rows.Count + ");");

            for (int i = 0; i <= dt1.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt1.Rows[i]["Site"].ToString() + "');");
                str.Append("data.setValue( " + i + "," + 1 + "," + "'" + dt1.Rows[i]["TotalPages"].ToString() + "');");
                str.Append("data.setValue( " + i + "," + 2 + "," + "'" + dt1.Rows[i]["UnsignedPages"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 3 + "," + dt1.Rows[i]["SignedPages"].ToString() + ") ;");
            }

            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div3'));");
            str.Append(" chart.draw(data, {widt1h: '100%', height: 300,colors: ['#D35400','#FF0000', '#FFA500','#008000'], legend: {position: 'top', maxLines: 4},bar: { groupWidt1h: '10%'}, title: 'Status of PI Signature',");
            str.Append("hAxis: {title: 'Sites', titleTextStyle: {color: 'Black'}}");
            str.Append("}); }");
            str.Append("</script>");
            lt3.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        }
        catch
        {
        }
    }
    private DataTable GetData4()
    {
        DataTable dt2 = new DataTable();
        string cmd2 = "Select SITENUM as Site, Count(EntryStatus) As TotalPages, (Select Count(EntryStatus) As TotalPages FROM [dbo].[tblPISignature] Where SITENUM=t1.SITENUM and EntryStatus='Submit') as Submit , (Select Count(EntryStatus) As TotalPages FROM [dbo].[tblPISignature] Where SITENUM=t1.SITENUM and EntryStatus='Save') as [Save] , (Select Count(LockStatus) As TotalPages FROM [dbo].[tblPISignature] Where SITENUM=t1.SITENUM and LockStatus='SDV') as SDV ,(Select Count(LockStatus) As TotalPages FROM [dbo].[tblPISignature] Where SITENUM=t1.SITENUM and LockStatus='Unlocked') as Unlocked ,(Select Count(LockStatus) As TotalPages FROM [dbo].[tblPISignature] Where SITENUM=t1.SITENUM and LockStatus='Locked') as Locked FROM [dbo].[tblPISignature] t1 Inner join tblEnrollUsersWithSite t2 on t2.CenterNumber=t1.SITENUM where t2.UserName='" + Session["UserName"] + "' group by t1.SITENUM";
        SqlDataAdapter adp = new SqlDataAdapter(cmd2, conn);
        adp.Fill(dt2);
        return dt2;
    }
    private void BindChart4()
    {
        DataTable dt2 = new DataTable();
        try
        {
            str.Clear();
            dt2 = GetData4();

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
                       google.setOnLoadCallback(drawChart);
                       function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Site');
        data.addColumn('number', 'Total Pages'); 
        data.addColumn('number', 'Submit'); 
        data.addColumn('number', 'Save'); 
        data.addColumn('number', 'SDV');
        data.addColumn('number', 'Unlocked');
        data.addColumn('number', 'Locked');
        
        data.addRows(" + dt2.Rows.Count + ");");

            for (int i = 0; i <= dt2.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt2.Rows[i]["Site"].ToString() + "');");
                str.Append("data.setValue( " + i + "," + 1 + "," + "'" + dt2.Rows[i]["TotalPages"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 2 + "," + dt2.Rows[i]["Submit"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 3 + "," + dt2.Rows[i]["Save"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 4 + "," + dt2.Rows[i]["SDV"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 5 + "," + dt2.Rows[i]["Unlocked"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 6 + "," + dt2.Rows[i]["Locked"].ToString() + ") ;");
            }

            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div4'));");
            str.Append(" chart.draw(data, {widt1h: '100%', height: 300,colors: ['#D35400', '#1E8449','#F4D03F', '#1ABC9C', '#3498DB', '#CB4335'], legend: {position: 'top', maxLines: 4},bar: { groupWidt1h: '10%'}, title: 'Status of Pages',");
            str.Append("hAxis: {title: 'Sites', titleTextStyle: {color: 'Black'}}");
            str.Append("}); }");
            str.Append("</script>");
            lt4.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        }
        catch
        {
        }
    }
}
