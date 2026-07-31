using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Net.Mail;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public partial class MasterPage2 : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection
(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd;
    DataTable dt = new DataTable();
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd1;
    SqlDataAdapter da = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserSession"] != null)
        {
            LabelUserName.Text = Session["UserName"].ToString();
            
        }
        else
        {
            LabelUserName.Text = "";
            Response.Redirect("~/Login.aspx");
        }
        if (Session["ActiveFlag"].ToString() == Convert.ToString(false))
        {

        }
        else
        {
            DataLock();
            #region Admin Login Right
            if (Session["UserRoles"].ToString() == "System Administrator")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;
                    Images.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    MDataExtraction.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;

                    MSDoc.Visible = true;
                    MDDoc.Visible = true;
                    Images.Visible = true;
                    MAdmin.Visible = true;
                    MCNUser.Visible = true;
                    MAUSite.Visible = true;
                    MENSite.Visible = true;
                    MATrail.Visible = true;

                    MMUsers.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else
                {
                    MHome.Visible = true;

                    MSDoc.Visible = true;
                    MDDoc.Visible = true;
                    Images.Visible = true;
                    MAdmin.Visible = true;
                    MCNUser.Visible = true;
                    MAUSite.Visible = true;
                    MENSite.Visible = true;
                    MATrail.Visible = true;

                    MMUsers.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }

            }
            if (Session["UserRoles"].ToString() == "Administrator")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;
                    Images.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    MDataExtraction.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;
                    Images.Visible = true;

                    MAdmin.Visible = true;
                    MENSite.Visible = true;
                    MCNUser.Visible = true;
                    MAUSite.Visible = true;
                    MATrail.Visible = true;
                    MMUsers.Visible = true;


                    MDEnty.Visible = true;
                    MESubject.Visible = true;
                    MSList.Visible = true;

                    MQuery.Visible = true;
                    MOQueries.Visible = true;
                    MQResponded.Visible = true;
                    MCQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;



                    MDataExtraction.Visible = true;
                }
                else
                {
                    MHome.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;
                    Images.Visible = true;

                    MAdmin.Visible = true;
                    MENSite.Visible = true;
                    MCNUser.Visible = true;
                    MAUSite.Visible = true;
                    MATrail.Visible = true;
                    MMUsers.Visible = true;


                    MDEnty.Visible = true;
                    MESubject.Visible = true;
                    MSList.Visible = true;

                    MQuery.Visible = true;
                    MOQueries.Visible = true;
                    MQResponded.Visible = true;
                    MCQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;



                    MDataExtraction.Visible = true;
                }

            }
            #endregion

            #region CRC And CRA Role Right

            if (Session["UserRoles"].ToString() == "Clinical Research Coordinator")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;
                    

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;
                    


                    MDEnty.Visible = true;
                    MESubject.Visible = true;
                    MSList.Visible = true;

                    MQuery.Visible = true;
                    MOQueries.Visible = true;
                    MQResponded.Visible = true;
                    MCQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else
                {
                    MHome.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;
                    

                    MDEnty.Visible = true;
                    MESubject.Visible = true;
                    MSList.Visible = true;

                    MQuery.Visible = true;
                    MOQueries.Visible = true;
                    MQResponded.Visible = true;
                    MCQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }



            }
            if (Session["UserRoles"].ToString() == "Clinical Research Associate" || Session["UserRoles"].ToString() == "Clinical Data Coordinator" || Session["UserRoles"].ToString() == "Clinical Data Associate")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    MDataExtraction.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;



                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MDEView.Visible = true;
                    CRADataView.Visible = true;


                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    MDataExtraction.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }
                else
                {
                    MHome.Visible = true;



                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MDEView.Visible = true;
                    CRADataView.Visible = true;


                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    MDataExtraction.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }


            }
            #endregion

            #region Data View Right
            if (Session["UserRoles"].ToString() == "Site Manager")
            {

            }
            #endregion

            #region Biostatistician
            if (Session["UserRoles"].ToString() == "Biostatistician")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    MDataExtraction.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {

                    MHome.Visible = true;
                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;
                    MDataExtraction.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else
                {

                    MHome.Visible = true;
                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;
                    MDataExtraction.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
            }
            #endregion

            #region Documentation Associate
            if (Session["UserRoles"].ToString() == "Documentation Associate")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;
                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }
                else
                {
                    MHome.Visible = true;
                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }

            }
            #endregion

            #region Project Manager
            if (Session["UserRoles"].ToString() == "Project Manager")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    MDataExtraction.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;
                    MDataExtraction.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;
                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    MDataExtraction.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }

            }

            if (Session["UserRoles"].ToString() == "Data Manager")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    MDataExtraction.Visible = true;
                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = true;
                    MDataExtraction.Visible = true;
                }
                else
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = true;
                    MDataExtraction.Visible = true;
                }
            }
            #endregion

            #region Medical Coder
            if (Session["UserRoles"].ToString() == "Medical Coder")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
            }
            #endregion

            #region HEAD CDM
            if (Session["UserRoles"].ToString() == "HEAD CDM")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    MDataExtraction.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
            }
            #endregion

            #region Sponsor
            if (Session["UserRoles"].ToString() == "Sponsor")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
            }
            #endregion

            #region Validation Associate
            if (Session["UserRoles"].ToString() == "Validation Associate")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
            }
            #endregion

            #region Quality Associate
            if (Session["UserRoles"].ToString() == "Quality Associate")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else
                {
                    MHome.Visible = true;

                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }

            }
            #endregion

            #region Investigator
            if (Session["UserRoles"].ToString() == "Principal Investigator")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;
                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;



                    MDEnty.Visible = true;
                    MESubject.Visible = true;
                    MSList.Visible = true;

                    MQuery.Visible = true;
                    MOQueries.Visible = true;
                    MQResponded.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }
                else
                {
                    MHome.Visible = true;



                    MDEnty.Visible = true;
                    MESubject.Visible = true;
                    MSList.Visible = true;

                    MQuery.Visible = true;
                    MOQueries.Visible = true;
                    MQResponded.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }

            }
            #endregion

            #region CoInvestigator
            if (Session["UserRoles"].ToString() == "CoInvestigator")
            {
                if (Convert.ToString(Session["lockd"]) == "Database Lock")
                {
                    MDEView.Visible = true;
                    MDEViewSList.Visible = true;

                    MSDoc.Visible = true;
                    MUDoc.Visible = true;
                    MDDoc.Visible = true;

                    MQuery.Visible = true;
                    MCRAOpenQueries.Visible = true;
                    MCRAQueriesResponded.Visible = true;
                    MCRAClosedQueries.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }
                else if (Convert.ToString(Session["lockd"]) == "Database Unlock")
                {
                    MHome.Visible = true;



                    MDEnty.Visible = true;
                    MESubject.Visible = true;
                    MSList.Visible = true;

                    MQuery.Visible = true;
                    MOQueries.Visible = true;
                    MQResponded.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }
                else
                {
                    MHome.Visible = true;



                    MDEnty.Visible = true;
                    MESubject.Visible = true;
                    MSList.Visible = true;

                    MQuery.Visible = true;
                    MOQueries.Visible = true;
                    MQResponded.Visible = true;
                    MTQueries.Visible = true;
                    fullLock.Visible = false;
                    fullUnlock.Visible = false;

                }


            }
            #endregion
            
        }


    }
    protected void Logout_Click(Object sender, EventArgs e)
    {

        #region Audit Log Manage
        AuditLog objAuditLog = new AuditLog();
        objAuditLog.UserName = Session["UserName"].ToString();
        objAuditLog.Role = Session["UserRoles"].ToString();
        objAuditLog.Action = "Logout";
        objAuditLog.PageName = "Login";
        objAuditLog.PageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
        objAuditLog.Description = "User Logout Successfully";
        objAuditLog.AuditLogManage();
        #endregion

        Session["UserSession"] = "";
        Session.Abandon();
        Response.Redirect("~/login.aspx");
    }

    protected void DataLock()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT Top (1) Action FROM AuditLog where PageName='FullyLock.aspx' ORDER BY DateTime DESC ", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {

            string lockd = dt.Rows[0]["Action"].ToString();
            Session["lockd"] = lockd;
            if (lockd == "Database Lock")
            {
                fullLock.Visible = false;
                fullUnlock.Visible = true;
            }
            else if (lockd == "Database Unlock")
            {
                fullLock.Visible = true;
                fullUnlock.Visible = false;
            }
            else
            {
                fullLock.Visible = false;
                fullUnlock.Visible = false;
            }


        }
        con.Close();
    }
}
