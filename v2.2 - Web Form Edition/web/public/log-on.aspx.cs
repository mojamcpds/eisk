using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Utilities;

public partial class Public_Log_On : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            MyLogOn.RedirectToDefaultPage();
        }
    }
    
    protected void ButtonLogOn_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtUserName.Value) || String.IsNullOrEmpty(txtPassword.Value)) 
            labelMessage.Text = "please enter user name and password!";
        else
        {
            if (txtUserName.Value == "any" && txtPassword.Value == "any")//if the log-in is successful
            {
                MyLogOn.PerformAuthentication("member1", checkBoxRemember.Checked);
            }
            else
            {
                labelMessage.Text = "can't log-in!";
            }
        }
    }
    protected void ButtonAdminLogOn_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtUserName.Value) || String.IsNullOrEmpty(txtPassword.Value)) 
            labelMessage.Text = "please enter user name and password!";
        else
        {

            if (txtUserName.Value == "any" && txtPassword.Value == "any")//if the log-in is successful
            {
                MyLogOn.PerformAdminAuthentication("admin1", checkBoxRemember.Checked);
            }
            else
            {
                labelMessage.Text = "can't log-in!";
            }
        }
    }
}
