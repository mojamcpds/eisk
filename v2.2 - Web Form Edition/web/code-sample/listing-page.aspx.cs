using System;
using System.Web.UI.WebControls;
using Utilities;
using System.Collections.ObjectModel;

public partial class Code_Sample_Listing_Page : System.Web.UI.Page
{
    #region "Click/Command Handlers"

    protected void GridViewEmployees_RowCommand(object sender, System.Web.UI.WebControls.CommandEventArgs e)
    {
        if (e.CommandName == "cmdView")
            WebManager.RedirectToDetailsPage("details-page.aspx", e.CommandArgument.ToString(), FormViewMode.ReadOnly);
        else if (e.CommandName == "cmdEdit")
            WebManager.RedirectToDetailsPage("details-page.aspx", e.CommandArgument.ToString(), FormViewMode.Edit);
        else if (e.CommandName == "cmdDelete")
        {
            //implicit delete method call: the code below will invoke the delete method is the corresponding object data source implicitly
            gridViewEmployees.DeleteRow(Convert.ToInt32(e.CommandArgument,System.Globalization.CultureInfo.CurrentCulture.NumberFormat)); //command argument contains row index
        }
    }

    protected void ButtonDeleteSelected_Click(object sender, System.EventArgs e)
    {
        try
        {
            // Create a List to hold the EmployeeID values to delete
            Collection<Int32> employeeIDsToDelete = new Collection<Int32>();
            // Iterate through the Employees.Rows property

            foreach (GridViewRow row in gridViewEmployees.Rows)
            {

                // Access the CheckBox
                CheckBox cb = (CheckBox)(row.FindControl("chkEmployeeSelector"));
                if (cb != null && cb.Checked)
                {
                    // Save the EmployeeID value for deletion
                    // First, get the EmployeeID for the selected row
                    Int32 employeeId = (Int32)gridViewEmployees.DataKeys[row.RowIndex].Value;

                    // Add it to the List...
                    employeeIDsToDelete.Add(employeeId);

                    // Add a confirmation message
                    labelMessage.Text += String.Format(System.Globalization.CultureInfo.CurrentCulture, "Delete successful. EmployeeId {0} has been deleted<br />", employeeId);
                    labelMessage.ForeColor = System.Drawing.Color.Green;
                }
            }

            //perform the actual delete
            if (Entity.Employee.DeleteEmployees(employeeIDsToDelete) == false)
                labelMessage.Text = "There is a problem deleting all items. One or more items have not been deleted due to problem.";
        }
        catch (Exception ex)
        {
            labelMessage.Text = "Problem while deleting. " + ex.Message;
            labelMessage.ForeColor = System.Drawing.Color.Red;
        }

        //binding the grid
        gridViewEmployees.PageIndex = 0;
        gridViewEmployees.DataBind();
    }

    protected void ButtonAdd_Click(object sender, System.EventArgs e)
    {
        WebManager.RedirectToDetailsPage("details-page.aspx", "0", FormViewMode.Insert);
    }

    #endregion

    protected void GridViewEmployees_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {

        if ((e.Row.RowType == DataControlRowType.Header))
        {
            //adding an attribut for onclick event on the check box in the hearder and passing the ClientID of the Select All checkbox
            ((CheckBox)e.Row.FindControl("chkSelectAll")).Attributes.Add("onclick", "SelectAll('" + gridViewEmployees.ClientID + "','" + ((CheckBox)e.Row.FindControl("chkSelectAll")).ClientID + "')");

        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Int32 employeeId = (Int32)gridViewEmployees.DataKeys[e.Row.RowIndex].Value;

            ImageButton imbtnView;
            imbtnView = (ImageButton)e.Row.FindControl("lnbView");
            //assigning alternate text for w3c validation
            imbtnView.AlternateText = "view";
            imbtnView.CommandArgument = employeeId.ToString(System.Globalization.CultureInfo.CurrentCulture.NumberFormat);

            ImageButton imbtnEdit;
            imbtnEdit = (ImageButton)e.Row.FindControl("lnbEdit");
            //assigning alternate text for w3c validation
            imbtnEdit.AlternateText = "edit";
            imbtnEdit.CommandArgument = employeeId.ToString(System.Globalization.CultureInfo.CurrentCulture.NumberFormat);

            ImageButton imbtnDelete = (ImageButton)e.Row.FindControl("lnbDelete");
            //assigning alternate text for w3c validation
            imbtnDelete.AlternateText = "delete";
            imbtnDelete.CommandArgument = e.Row.RowIndex.ToString(System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            imbtnDelete.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete?');");

        }
    }

    protected void odsOrderDetails_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //getting the result
        bool result = Convert.ToBoolean(e.ReturnValue, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);

        if (result)
        {
            labelMessage.Text = "Delete successful.";
            labelMessage.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            e.ExceptionHandled = true;
            labelMessage.Text = "Delete Not successful. ";
            if (e.Exception != null) labelMessage.Text += e.Exception.Message;
            labelMessage.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void buttonFilter_Click(object sender, EventArgs e)
    {
        gridViewEmployees.DataBind();
    }
}
