namespace Utilities
{
    using System.Web.Security;

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    public sealed class MyLogOn
    {
        private MyLogOn() { }

        public static void PerformAuthentication(string userName, bool remember)
        {
            FormsAuthentication.RedirectFromLoginPage(userName, remember);

            if (System.Web.HttpContext.Current.Request.QueryString["ReturnUrl"] == null)
                RedirectToDefaultPage();
            else
                System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnUrl"].ToString());

        }

        public static void PerformAdminAuthentication(string userName, bool remember)
        {
            FormsAuthentication.RedirectFromLoginPage(userName, remember);

            if (System.Web.HttpContext.Current.Request.QueryString["ReturnUrl"] == null)
                RedirectToAdminDefaultPage();
            else
                System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnUrl"].ToString());

        }

        /// <summary>
        /// Redirects the current user based on role
        /// </summary>
        public static void RedirectToDefaultPage()
        {
            System.Web.HttpContext.Current.Response.Redirect("~/private/member-default.aspx");
        }

        public static void RedirectToAdminDefaultPage()
        {
            System.Web.HttpContext.Current.Response.Redirect("~/admin/admin-default.aspx");
        }

        public static void LogOff()
        {
            // Put user code to initialize the page here
            FormsAuthentication.SignOut();

            //// Invalidate roles token
            //Response.Cookies[Globals.UserRoles].Value = "";
            //Response.Cookies[Globals.UserRoles].Path = "/";
            //Response.Cookies[Globals.UserRoles].Expires = new System.DateTime(1999, 10, 12);

            //Set the current user as null
            System.Web.HttpContext.Current.User = null;
        }
    }
}