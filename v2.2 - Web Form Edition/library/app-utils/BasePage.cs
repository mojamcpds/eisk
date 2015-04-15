using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

    /// <summary>
    /// Parent class for all page
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        #region Nested Master Page Functionality

        private string runtimeMasterPageFile;

        /// <summary>
        /// Runtime master page property.
        /// It is used for dynamically loading nested master page
        /// </summary>
        /// <summary>
        /// Executes am scalar command.
        /// If no connection string is provided, Default database is assumed.
        /// </summary>
        public string RuntimeMasterPageFile
        {
            get { return runtimeMasterPageFile; }
            set { runtimeMasterPageFile = value; }
        }

        /// <summary>
        /// PreInit event of the Page
        /// It is used for assigning runtime master page to the page
        /// </summary>
        protected override void OnPreInit(EventArgs e)
        {
            if (runtimeMasterPageFile != null)
            {
                this.MasterPageFile = runtimeMasterPageFile;
            }
            base.OnPreInit(e);
        }

        #endregion

        //#region Session Expiration Functionalities

        ///// <summary>
        ///// Raises the <see cref="E:System.Web.UI.Control.Init"/>
        ///// event.
        ///// </summary>
        ///// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        //override protected void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);


        //    //It appears from testing that the Request and Response both share the 
        //    // same cookie collection.  If I set a cookie myself in the Reponse, it is 
        //    // also immediately visible to the Request collection.  This just means that 
        //    // since the ASP.Net_SessionID is set in the Session HTTPModule (which 
        //    // has already run), thatwe can't use our own code to see if the cookie was 
        //    // actually sent by the agent with the request using the collection. Check if 
        //    // the given page supports session or not (this tested as reliable indicator 
        //    // if EnableSessionState is true), should not care about a page that does 
        //    // not need session
        //    if (Context.Session != null)
        //    {
        //        //Tested and the IsNewSession is more advanced then simply checking if 
        //        // a cookie is present, it does take into account a session timeout, because 
        //        // I tested a timeout and it did show as a new session
        //        if (Session.IsNewSession)
        //        {
        //            // If it says it is a new session, but an existing cookie exists, then it must 
        //            // have timed out (can't use the cookie collection because even on first 
        //            // request it already contains the cookie (request and response
        //            // seem to share the collection)
        //            string szCookieHeader = Request.Headers["Cookie"];
        //            if ((null != szCookieHeader) && (szCookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
        //            {
        //                //if the application is NOT currently set to in test-mode ( i.e in real mode )
        //                if (!Desme.Codebase.Helper.Utils.AppSettingsReader.CommonValues.IsInTestMode)
        //                    Response.Redirect("~/public/session-expire.aspx");
        //            }
        //        }
        //    }
        //}

        //#endregion
    }
