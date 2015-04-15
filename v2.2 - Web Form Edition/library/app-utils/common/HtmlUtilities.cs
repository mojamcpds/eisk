namespace HelperUtilities
{
    using System;
    /// <summary>
	/// This class is used to provide pre-defined html formats and texts that are required to implement on simple mail and print functionalities.
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// Date Created: 12-Dec-2005
	/// </summary>
	public class HtmlUtilities
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HTMLUtils"/> class.
		/// </summary>
        public HtmlUtilities()
		{
			sb = new System.Text.StringBuilder();
		}
		
		#region Data
		
		System.Text.StringBuilder sb;
		
		const string tableStartText = "<Table cellSpacing=0 cellPadding=3 width=100% border=0>";
		const string tableEndText = "</Table>";
		
		/// <summary>
		/// Gets the formatted HTML text.
		/// </summary>
		/// <value>The formatted HTML text.</value>
		public string FormattedHtmlText
		{
			get
			{
				sb.Insert(0, tableStartText);
				sb.Append(tableEndText);
				return sb.ToString();
			}
		}
		
		#endregion
				
		#region Predefined Text Size Area

		/// <summary>
		/// Formats to a html row with the text with 4 size text
		/// </summary>
		/// <param name="text">The text.</param>
		public void AppendHeader (string text)
		{
			FormatToRow(text, 4, true); 
		}
		
		/// <summary>
		/// Formats to a html row with the text with 3 size text
		/// </summary>
		/// <param name="text">The text.</param>
		public void AppendSubHeader (string text)
		{
			FormatToRow(text, 3, true); 
		}
		
		/// <summary>
		/// Formats to a html row with the text with 2 size text
		/// </summary>
		/// <param name="text">The text.</param>
		public void AppendPara (string text)
		{
			FormatToRow(text, 2, false); 				
		}
		
		/// <summary>
		/// Appends the blank row.
		/// </summary>
		public void AppendBlankRow ()
		{
			FormatToBlankRow();
		}
		
		#endregion
		
		#region Format Area

		/// <summary>
		/// Formats a blank HTML row.
		/// </summary>
		public void FormatToBlankRow()
		{
			sb.Append("<TR> <TD height=20> </TD> </TR>");		
		}

		/// <summary>
		/// Formats to row.
		/// </summary>
		/// <param name="text">The text.</param>
		public void FormatToRow(string text)
		{
			FormatToRow(text, 2, false);
		}

		/// <summary>
		/// Formats to row.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="fontSize">Size of the font.</param>
		public void FormatToRow(string text, int fontSize)
		{
			FormatToRow(text, fontSize, false);
		}

		/// <summary>
		/// Formats to row.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="fontSize">Size of the font.</param>
		/// <param name="bold">if set to <c>true</c> [bold].</param>
		public void FormatToRow(string text, int fontSize, bool bold)
		{
			string boldMarker = ( bold? "bold": "normal");
			string fontFace = "verdana";
			sb.Append("<TR> <TD align=left><font size=" + fontSize.ToString(System.Globalization.CultureInfo.CurrentCulture.NumberFormat) + " face=" + fontFace + " style=\"FONT-WEIGHT: " + boldMarker + "\"  > " + text + "</font></TD> </TR>");
		}
		
		/// <summary>
		/// Formats the provided key/values by separating them thru a colon, and considers the smallest text size '2'.
		/// </summary>
		/// <param name="strLabel"></param>
		/// <param name="strValue"></param>
		public void FormatToRowInColonSeparatedText(string label, string value)
		{
			FormatToRowInColonSeparatedText ( label, value, false);	
		}

		/// <summary>
		/// Formats the provided key/values by separating them thru a colon, and considers the smallest text size '2'.
		/// </summary>
		/// <param name="strLabel"></param>
		/// <param name="strValue"></param>
		/// <param name="bold"></param>
		public void FormatToRowInColonSeparatedText(string label, string value, bool bold)
		{
			label = "<b>" + label + " : </b>";
			if(bold) value = "<b>" + value + "</b>";
			FormatToRow(label +  " " + value, 2, bold);
		}
		
		#endregion		
		
	}
}
