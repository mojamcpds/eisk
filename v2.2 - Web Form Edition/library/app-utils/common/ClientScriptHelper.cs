namespace HelperUtilities
{
    using System;
    using System.Web.UI.WebControls;

	/// <summary>
	/// This class contains simple utility classes to facilate the control initialyzations for common client side tasks.
	/// Generally to bind a control along with any client side behaviour, this have to do at the Page_Load event.
	/// So when using these methods, YOU MUST HAVE TO CALL THESE IS THE Page_Load EVENT HANDLER METHOD.
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
	public sealed class ClientScriptHelper
	{
        private ClientScriptHelper() { }

		const string OnClick = "OnClick";
		/// <summary>
		/// Shows the 'Print Dialogue' when user clicks on it and after then when they select the button, the current page will be printed. 
		/// To bind this behaviour with the specified control, you must call this from the 'Page_Load' event handler method.
		/// </summary>
		/// <param name="wc">The web control for which attributs will be added for OnClick javascript.</param>
		public static void AddPrint(WebControl wc)
		{
			wc.Attributes.Add(OnClick, ClientScriptHelper.GetScriptFullLine( "window.print()"));
		}

		/// <summary>
		/// Opens the specifiled url page in the new pop-up window when user clicks on it.
		/// To bind this behaviour with the specified control, you must call this from the 'Page_Load' event handler method.
		/// </summary>
		/// <param name="wc">The web control for which attributs will be added for OnClick javascript.</param>
		/// <param name="url"></param>
		/// Last change: 28-12-2005
		public static void AddOpenNewWindow(WebControl wc, Uri urlToOpen)
		{
            //refine the url 
            urlToOpen = new Uri("\"" + urlToOpen.OriginalString + "\"");
            //now add the url appropriately
            wc.Attributes.Add(OnClick, ClientScriptHelper.GetScriptFullLine("window.open(" + urlToOpen.OriginalString + ")"));
		}

		/// <summary>
		/// Opens the specifiled url page in the new pop-up window when user clicks on it.
		/// To bind this behaviour with the specified control, you must call this from the 'Page_Load' event handler method.
		/// </summary>
		/// <param name="wc">The web control for which attributs will be added for OnClick javascript.</param>
		/// <param name="url"></param>
		/// Date created: 28-12-2005
        public static void AddOpenPopupWindow(WebControl wc, Uri urlToOpen)
		{
            wc.Attributes.Add(OnClick, ClientScriptHelper.GetScriptFullLine("window.open(\"" + urlToOpen.OriginalString + "\",null, \"height=400,width=600,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,top=100,left=100\");"));
		}
		
		/// <summary>
		/// Closes the current window when user clicks on it .
		/// To bind this behaviour with the specified control, you must call this from the 'Page_Load' event handler method.
		/// </summary>
		/// <param name="wc">The web control for which attributs will be added for OnClick javascript.</param>
		public static void AddCloseWindow(WebControl wc)
		{
			wc.Attributes.Add(OnClick, ClientScriptHelper.GetScriptFullLine( "window.close()") ) ;
		}
		
		/// <summary>
		/// Get back to the previous page regarding the number of bowser back history when user clicks on it.
		/// To bind this behaviour with the specified control, you must call this from the 'Page_Load' event handler method.
		/// </summary>
		/// <param name="wc">The web control for which attributs will be added for OnClick javascript.</param>
		public static void AddBackWindow(WebControl wc)
		{
			ClientScriptHelper.AddBackWindow(wc, 1);
		}
		
		/// <summary>
		/// Get back to the previous page regarding the number of bowser back history when user clicks on it.
		/// To bind this behaviour with the specified control, you must call this from the 'Page_Load' event handler method.
		/// </summary>
		/// <param name="wc">The web control for which attributs will be added for OnClick javascript.</param>
		/// <param name="noToBack">The number of times to get back regarding browser back</param>
		public static void AddBackWindow(WebControl wc, int noToBack)
		{
			wc.Attributes.Add(OnClick, ClientScriptHelper.GetScriptFullLine("history.back(" + noToBack + ")") );
		}

		/// <summary>
		/// Get forward page regarding the number of bowser forward history when user clicks on it.
		/// To bind this behaviour with the specified control, you must call this from the 'Page_Load' event handler method.
		/// </summary>
		/// <param name="wc">The web control for which attributs will be added for OnClick javascript.</param>
		public static void AddForwardWindow(WebControl wc)
		{
			ClientScriptHelper.AddForwardWindow(wc, 1);
		}
		
		/// <summary>
		/// Get forward page regarding the number of bowser forward history when user clicks on it.
		/// To bind this behaviour with the specified control, you must call this from the 'Page_Load' event handler method.
		/// </summary>
		/// <param name="wc">The web control for which attributs will be added for OnClick javascript.</param>
		/// <param name="noToforward">The number of times to get forward regarding browser forward</param>
		public static void AddForwardWindow(WebControl wc, int noToForward)
		{
			wc.Attributes.Add(OnClick, ClientScriptHelper.GetScriptFullLine("history.forward(" + noToForward + ")") );
		}

		/// <summary>
		/// Formats a client script block along 
		/// </summary>
		/// <param name="ScriptStatementBlock"></param>
		/// <returns></returns>
		static public string FormatClientScriptBlock(string scriptStatementBlock)
		{
			return string.Format(System.Globalization.CultureInfo.CurrentCulture,"\n<script language=\"javascript\" type=\"text/javascript\">\n<!-- \n {0} \n // -->\n</script>\n", scriptStatementBlock) ;
		}
		
		/// <summary>
		/// Formats the passed text along with the common javascript format.
		/// Return Example: javascript: window.close(); return false;
		/// </summary>
		/// <param name="basicText">The text that should be formatted.</param>
		/// <returns>Returns the formatted text.</returns>
		static string GetScriptFullLine(string basicText)
		{
			return "javascript:" + basicText + ";return false;";
		}
	}
}
