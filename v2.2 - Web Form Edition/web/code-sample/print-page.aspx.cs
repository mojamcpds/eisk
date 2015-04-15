using System;
using System.Web.UI.WebControls;

public partial class Code_Sample_Print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void OdsOrderDetails_Selecting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["employeeID"] = Int32.Parse(Session["Id"].ToString(),System.Globalization.CultureInfo.CurrentCulture);
    }
}
