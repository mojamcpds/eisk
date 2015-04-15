<%@ Page Language="C#" MasterPageFile="~/master/default.master" AutoEventWireup="true"
    CodeFile="install.aspx.cs" Inherits="public_install" Title="Database Installation Required!" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" runat="Server">
    <table id="tblOuter" class="contentcontainerTBL" summary="table1 summary info" width="100%">
        <tr>
            <td>
                <a id="maincontent"></a>
                <h1>
                    Database Installation Required!</h1>
                <p>
                    Hmm..seems like you have not install the database yet. Provide the database server
                    information as below to create database for your employee info starter kit, which
                    will be used thruout the web site and test cases in this project.
                    <br />
                    Once the database install is successful, you will be redirected to the default page
                    of employee info starter kit.
                </p>
                <asp:Label runat="server" EnableViewState="False" ID="labelMessage" ForeColor="Red"></asp:Label>
                <fieldset>
                    <legend>Install Database</legend>
                    <label for="name">
                        your server address</label><asp:TextBox runat="server" ID="txtServerAddress" Text=".\SQLEXPRESS"
                            Width="300px"></asp:TextBox>
                    <br />
                    <asp:CheckBox runat="server" ID="chkUseIntegratedSecurity" AutoPostBack="true" Checked="true"
                        Text="Use Windows Integrated Security" OnCheckedChanged="chkUseIntegratedSecurity_CheckedChanged" />
                    <asp:Panel runat="server" ID="pnlUserCredential" Visible="true">
                        <label for="name">
                            your database user name</label><asp:TextBox runat="server" ID="txtUsername" Width="300px"></asp:TextBox>
                        <label for="name">
                            your database password</label><asp:TextBox runat="server" ID="txtPassword" Width="300px"></asp:TextBox>
                    </asp:Panel>
                    <asp:Button ID="buttonTestConnection" CssClass="button-big" runat="server" Text="Test Connection"
                        OnClick="buttonTestConnection_Click" />
                    <asp:Button Enabled="false" ID="buttonCreateDatabase" CssClass="button-big" runat="server"
                        Text="Create Database" OnClick="buttonCreateDatabase_Click" />
                    <asp:Button Enabled="false" ID="buttonInstall" CssClass="button-big" runat="server"
                        Text="Install" OnClick="buttonInstall_Click" />
                    <br />
                    <asp:Panel runat="server" ID="pnlDbName" Visible="false">
                        <label for="name">
                            your database name</label><asp:TextBox Text="test_EmployeeInfo_SK_v2_2" runat="server"
                                ID="txtDbName" Width="300px"></asp:TextBox>
                        <br />
                    </asp:Panel>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
