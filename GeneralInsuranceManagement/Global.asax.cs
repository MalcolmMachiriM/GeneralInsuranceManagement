using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace GeneralInsuranceManagement
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Session_Start(object sender, EventArgs e)
        {
            //Code that runs when a new session is started

            Session.Timeout = 30;
            if (Session["UserID"] == null)
            {
                //Redirect to Welcome Page if Session is not null    
                Response.Redirect("~/UserManagement/userlogin.aspx");
            }


        }
    }
}