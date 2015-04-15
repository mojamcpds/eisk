using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using Utilities;
using HelperUtilities;

public partial class public_install : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlUserCredential.Visible = !chkUseIntegratedSecurity.Checked;
    }
    
    protected void chkUseIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
    {
        pnlUserCredential.Visible = !chkUseIntegratedSecurity.Checked;
    }

    protected void buttonTestConnection_Click(object sender, EventArgs e)
    {
        if (ConnectionStringManager.IsConnectionStringOk(connectionString))
        {
            labelMessage.Text = "Connection passed. Click the Create Database button to create database.";
            labelMessage.ForeColor = System.Drawing.Color.Green;
            buttonCreateDatabase.Enabled = true;
            pnlDbName.Visible = true;
            txtDbName.ReadOnly = false;
        }
        else
        {
            labelMessage.Text = "Connection failed. Please provide a appropriate info to connect with database.";
            labelMessage.ForeColor = System.Drawing.Color.Red;
            buttonCreateDatabase.Enabled = false;
            buttonInstall.Enabled = false;
            pnlDbName.Visible = false;
        }
    }

    protected void buttonCreateDatabase_Click(object sender, EventArgs e)
    {
        if (Utilities.SqlScriptUtility.CreateDatabase(txtDbName.Text, connectionString))
        {
            string newConnectionString = connectionString + "Initial Catalog=" + txtDbName.Text + ";";

            //run the schema generation script in new database
            Utilities.SqlScriptUtility.CreateDatabase(txtDbName.Text, newConnectionString);

            //save the new db connectionstring to config files
            ConfigHelper.SaveConnectionStringKey(Server.MapPath("~/web.config"), Keys.ConstConnectionStringKey, newConnectionString);
            ConfigHelper.SaveConnectionStringKey(Server.MapPath("~") + @"\..\tests\app.config", Keys.ConstConnectionStringKey, newConnectionString);

            //show the proper message
            labelMessage.Text = "Database created successfully. Click the Install button to install database.";
            labelMessage.ForeColor = System.Drawing.Color.Green;
            buttonInstall.Enabled = true;
            txtDbName.ReadOnly = true;
        }
        else
        {
            labelMessage.Text = "Database creation failed. Please provide a appropriate creadential that has permission to create database.";
            labelMessage.ForeColor = System.Drawing.Color.Red;
            buttonInstall.Enabled = false;
        }
    }

    protected void buttonInstall_Click(object sender, EventArgs e)
    {
        try
        {
            Utilities.SqlScriptUtility.RunScript(Server.MapPath("~") + @".\..\database\primary-scripts\CreateSchema.sql");
            Utilities.SqlScriptUtility.RunScript(Server.MapPath("~") + @".\..\database\primary-scripts\CreateSetupData.sql");
            labelMessage.Text = "Congratulations! Database installation successful. Click <a href=../default.aspx>here</a> to go to default page.";
            labelMessage.ForeColor = System.Drawing.Color.Green;
        }
        catch (Exception ex)
        {
            labelMessage.Text = "Database installation failed. Please provide a appropriate creadential that has permission to install database. <br>" + ex.ToString();
            labelMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
    string connectionString
    {
        get
        {
            if (chkUseIntegratedSecurity.Checked)
                return @"Data source=" + txtServerAddress.Text + ";Integrated Security=yes;";
            else
                return @"Data source=" + txtServerAddress.Text + ";User ID=" + txtUsername.Text + "; Password=" + txtPassword.Text + ";";
        }
    }
}
