namespace Utilities
{
    using System;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    public sealed class WebManager
    {
        private WebManager() { }

        #region Master details

        public static void RedirectToDetailsPage(string page, string id, FormViewMode mode)
        {
            if (mode == FormViewMode.ReadOnly)
                System.Web.HttpContext.Current.Session["Id"] = "v" + id;
            else if (mode == FormViewMode.Edit)
                System.Web.HttpContext.Current.Session["Id"] = "e" + id;
            else if (mode == FormViewMode.Insert)
                System.Web.HttpContext.Current.Session["Id"] = "i" + id;

            System.Web.HttpContext.Current.Response.Redirect(page);

        }

        public static object ParseItemId(System.Web.UI.Page page, System.Web.UI.WebControls.FormView formView)
        {
            if (!page.IsPostBack)
            {
                if (System.Web.HttpContext.Current.Session["Id"] != null)
                {

                    if (System.Web.HttpContext.Current.Session["Id"].ToString().StartsWith("v", StringComparison.CurrentCulture))
                        formView.ChangeMode(FormViewMode.ReadOnly);
                    else if (System.Web.HttpContext.Current.Session["Id"].ToString().StartsWith("e", StringComparison.CurrentCulture))
                        formView.ChangeMode(FormViewMode.Edit);
                    else if (System.Web.HttpContext.Current.Session["Id"].ToString().StartsWith("i", StringComparison.CurrentCulture))
                        formView.ChangeMode(FormViewMode.Insert);

                    if (
                            (System.Web.HttpContext.Current.Session["Id"].ToString().StartsWith("v", StringComparison.CurrentCulture))||
                            (System.Web.HttpContext.Current.Session["Id"].ToString().StartsWith("e", StringComparison.CurrentCulture))||
                            (System.Web.HttpContext.Current.Session["Id"].ToString().StartsWith("i", StringComparison.CurrentCulture))
                        )
                            System.Web.HttpContext.Current.Session["Id"] = System.Web.HttpContext.Current.Session["Id"].ToString().Substring(1);
                }
            }

            return System.Web.HttpContext.Current.Session["Id"];
        }

        public static void UpdateItemId(object value, System.Web.UI.WebControls.FormView formView)
        {
            System.Web.HttpContext.Current.Session["Id"] = value;
            formView.DefaultMode = FormViewMode.Edit;
        }

        #endregion
    }
}