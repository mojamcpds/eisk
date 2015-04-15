using System;
using System.Web.UI.WebControls;
using Utilities;

public partial class Code_Sample_Details_Page : System.Web.UI.Page
{
    #region "Data Operation and Navigation Command Handlers"
    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        if (formViewEmployee.CurrentMode == FormViewMode.Insert)
        {
            formViewEmployee.InsertItem(true);
        }
        else
        {
            formViewEmployee.UpdateItem(true);
        }
    }


    protected void ButtonEdit_Click(object sender, EventArgs e)
    {
        formViewEmployee.ChangeMode(FormViewMode.Edit);
    }

    protected void ButtonGoToListPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("listing-page.aspx");
    }

    protected void ButtonGoToPrintPage_Click(object sender, EventArgs e)
    {
        if (formViewEmployee.CurrentMode != FormViewMode.Insert)
        {
            string script = "window.open('print-page.aspx','')";
            if (!ClientScript.IsClientScriptBlockRegistered("NewWindow"))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "NewWindow", script, true);
            }
        }
    }
    #endregion

    #region "Select handlers"
    protected void OdsOrderDetails_Selecting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //since the select parameter contains a special type of parameter, rather than the primitive type
        //we can't use the built-in asp:paramter in object data-source, as it supports only primitive data types
        //for this purpose we have performed the required casting and assignment (if necessary) in this event handler method
        //however alternatively we can use 'control-parameter' in object-data-source for this type of special data type, which performs the casting automatically
        //e.InputParameters("employeeID") = CType(1,Int32)

        //saving page-mode and item id
        //int empId = (int)uint.MinValue;
        //if(e.InputParameters["employeeId"]!=null)         
        //    empId =Int32.Parse(e.InputParameters["employeeId"].ToString());
      
        //empId = WebManager.StoreValue(this, ViewState, empId, formViewEmployee);

        // [ Added: Jalal On 03/17/2008 ]
        //e.InputParameters["employeeId"] = Int32.Parse(ViewState["Id"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
        e.InputParameters["employeeId"] = WebManager.ParseItemId(this,formViewEmployee);
        //e.InputParameters["employeeId"] = Convert.ToInt32(WebManager.ParseItemId(this, formViewEmployee));
        //if the form view mode is in insert model, then we'll cancel the selection by object data source
        if (formViewEmployee.CurrentMode == FormViewMode.Insert)
            e.Cancel = true;
    }
    #endregion

    #region "Update handlers"

    protected void FormViewEmployee_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        if (!String.IsNullOrEmpty(((FileUpload)this.formViewEmployee.FindControl("fuPhotoUpload")).FileName))
            e.NewValues["photo"] = ((FileUpload)this.formViewEmployee.FindControl("fuPhotoUpload")).FileBytes;
        else
            e.NewValues["photo"] = null;
    }

    protected void OdsOrderDetails_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {

        //getting the result
        bool result = Convert.ToBoolean(e.ReturnValue, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);

        if (result)
        {
            Message = "Update successful.";
            //'We can ignore the line below, if we need to return just after the updation operation
            formViewEmployee.DefaultMode = FormViewMode.Edit;
        }
        else
        {
            Message = "Error while updating.";
        }
    }

    #endregion

    #region "Insert handlers"

    protected void FormViewEmployee_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (!String.IsNullOrEmpty(((FileUpload)this.formViewEmployee.FindControl("fuPhotoUpload")).FileName))
        {
            e.Values["photo"] = ((FileUpload)this.formViewEmployee.FindControl("fuPhotoUpload")).FileBytes;
        }
        else
        {            
            e.Values["photo"] = null;
        }
    }
    
    protected void OdsOrderDetails_Inserted(object sender, System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs e)
    {
        //getting the result
        int result = Convert.ToInt32(e.ReturnValue,System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
        if (result != 0)
        {
            Message = "Insert successful.";
            //We can ignore the line below, if we need to return just after the insertion operation
            WebManager.UpdateItemId(result.ToString(System.Globalization.CultureInfo.CurrentCulture.NumberFormat), formViewEmployee);
        }
        else
            Message = "Error while inserting.";
    }

    #endregion

    #region "Populating and binding special controls"

    //customzed data operations over databound controls in form view
    protected void FormViewEmployee_DataBound(object sender, System.EventArgs e)
    {
        TextBox txtFirstName = (TextBox)formViewEmployee.FindControl("txtFirstName");
        TextBox txtLastName = (TextBox)formViewEmployee.FindControl("txtLastName");
        TextBox txtHireDate = (TextBox)formViewEmployee.FindControl("txtHireDate");
        TextBox txtAddress = (TextBox)formViewEmployee.FindControl("txtAddress");
        TextBox txtHomePhone = (TextBox)formViewEmployee.FindControl("txtHomePhone");
        DropDownList ddlCountry = (DropDownList)formViewEmployee.FindControl("ddlCountry");

        //since in read-only mode there is no text box control
        if (formViewEmployee.CurrentMode != FormViewMode.ReadOnly)
        {

            //using data value in form in custom way
            if (formViewEmployee.CurrentMode == FormViewMode.Edit)
            {
                Entity.Employee employee = (Entity.Employee)formViewEmployee.DataItem;
            }
              
            //populating per-fill data
            if (formViewEmployee.CurrentMode == FormViewMode.Insert)
            {
                txtFirstName.Text = "Ashraful";
                txtLastName.Text = "Alam";
                txtHireDate.Text = DateTime.Now.ToString();
                txtAddress.Text = "One Microsoft Way";
                txtHomePhone.Text = "912200022";
                ddlCountry.Items.FindByText("USA").Selected = true;
            }
        }

        //binding last data operation message
        Label lblMessage = (Label)formViewEmployee.FindControl("lblMessage");
        if (lblMessage != null)
        {
            lblMessage.Text = Message;
        }
    }
    #endregion

    string _message = String.Empty;
    public string Message
    {
        get { return _message; }
        set { _message = value; }
    }

   
}
