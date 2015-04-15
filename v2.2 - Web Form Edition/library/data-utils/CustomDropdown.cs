using System;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("Utils", "CustomControl")]
namespace Utilities
{
    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    [SupportsEventValidation, ValidationProperty("SelectedItem")]
    [ToolboxData("<{0}:CountryDropDown runat=server></{0}:CountryDropDown>")]
    public class CountryDropDown : DropDownList
    {
        /// <summary>
        /// Bind dropdownlist.
        /// </summary>
        public override void DataBind()
        {
            EnableViewState = false;
            
            //inserting data items
            Items.Add(new ListItem("USA", "USA"));
            Items.Add(new ListItem("Bangladesh", "Bangladesh"));

            //inserting 'top' item
            if (!String.IsNullOrEmpty(FirstItem))
            { 
                this.Items.Insert(0, new ListItem (FirstItem, ""));
            }
            
            base.DataBind();
        }

        string _firstItem = "None";

        /// <summary>
        /// Get/Set the FirstItem property
        /// </summary>
        public string FirstItem
        {
            get { return _firstItem; }
            set { _firstItem = value; }
        }
        
    }

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    [SupportsEventValidation, ValidationProperty("SelectedItem")]
    [ToolboxData("<{0}:StateDropDown runat=server></{0}:StateDropDown>")]
    public class StateDropDown : DropDownList
    {
        /// <summary>
        /// Bind dropdownlist.
        /// </summary>
        public override void DataBind()
        {
            EnableViewState = false;

            //inserting data items
            Items.Add(new ListItem("IL", "IL"));
            Items.Add(new ListItem("CA", "CA"));

            //inserting 'top' item
            if (!String.IsNullOrEmpty(FirstItem))
            {
                this.Items.Insert(0, new ListItem(FirstItem, ""));
            }

            base.DataBind();
        }

        string _firstItem = "None";

        /// <summary>
        /// Get/Set the FirstItem property
        /// </summary>
        public string FirstItem
        {
            get { return _firstItem; }
            set { _firstItem = value; }
        }

    }

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    [SupportsEventValidation, ValidationProperty("SelectedItem")]
    [ToolboxData("<{0}:CompanyDropDown runat=server></{0}:CompanyDropDown>")]
    public class CompanyDropDown : DropDownList
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //EnableViewState = false;
            Items.Clear();

            //inserting data items
            Items.Add(new ListItem("ABC", "ABC"));
            Items.Add(new ListItem("Desme", "Desme"));
            Items.Add(new ListItem("Intel", "Intel"));

            //inserting 'top' item
            if (!String.IsNullOrEmpty(FirstItem))
            {
                this.Items.Insert(0, new ListItem(FirstItem, "-1"));
            }

        }

        /// <summary>
        /// Bind dropdownlist.
        /// </summary>
        public override void DataBind()
        {
            //EnableViewState = false;
            Items.Clear();

            //inserting data items
            Items.Add(new ListItem("ABC", "ABC"));
            Items.Add(new ListItem("Desme", "Desme"));
            Items.Add(new ListItem("Intel", "Intel"));

            //inserting 'top' item
            if (!String.IsNullOrEmpty(FirstItem))
            {
                this.Items.Insert(0, new ListItem(FirstItem, ""));
            }

            base.DataBind();
        }

        string _firstItem = "None";

        /// <summary>
        /// Get/Set the FirstItem property
        /// </summary>
        public string FirstItem
        {
            get { return _firstItem; }
            set { _firstItem = value; }
        }

    }

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    [SupportsEventValidation, ValidationProperty("SelectedItem")]
    [ToolboxData("<{0}:EmployeeDropdown runat=server></{0}:EmployeeDropdown>")]
    public class EmployeeDropDown : DropDownList
    {
        protected override void OnInit(EventArgs e)
        {
            //base.OnInit(e);

            if (FirstItem == "All")
            {
                this.DataBind();
            }
            
        }

        /// <summary>
        /// Bind dropdownlist.
        /// </summary>
        public override void DataBind()
        {
            //EnableViewState = false;
            EnableViewState = true;

            //inserting data items
            CustomCollection<Entity.Employee> collEmployee = Entity.Employee.SelectAllEmployees();
            DataSource = collEmployee;
            DataTextField = "FirstName";
            DataValueField = "EmployeeId";
            
            base.DataBind();

            //inserting 'top' item
            if (FirstItem == "Select")
                this.Items.Insert(0, new ListItem(FirstItem, ""));
            else
                if (!String.IsNullOrEmpty(FirstItem))
                    this.Items.Insert(0, new ListItem(FirstItem, "-1"));
            
        }

        string _firstItem = "None";

        /// <summary>
        /// Get/Set the FirstItem property
        /// </summary>
        public string FirstItem
        {
            get { return _firstItem; }
            set {_firstItem = value; }
        }

    }
}