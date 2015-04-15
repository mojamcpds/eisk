<%@ Page Language="C#" MasterPageFile="~/master/default.master" AutoEventWireup="true"
    CodeFile="log-on.aspx.cs" Inherits="Public_Log_On" Title="log-in please" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" runat="Server">
    <table id="tblOuter" class="contentcontainerTBL" summary="table1 summary info" width="100%">
        <tr>
            <td>
                <a id="maincontent"></a>
                <h1>
                    Login</h1>
                <fieldset>
                    <legend>log in</legend>
                    <label for="name">
                        your user name
                    </label>
                    <input runat="server" onfocus="this.select()" onblur="if (this.value==''){this.value='enter your name'}"
                        name="name" id="txtUserName" type="text" value="enter your user name" size="20" />
                    <label for="password">
                        your password</label>
                    <input runat="server" onfocus="this.select()" name="password" id="txtPassword" type="password"
                        size="20" />
                    <label for="check1">
                        <input runat="server" title="remember" type="checkbox" name="checkboxRemember" id="checkBoxRemember"
                            value="" />
                        Remember me in this computer</label>
                    <asp:Button ID="buttonLogOn" CssClass="button-big" runat="server" Text="log in" OnClick="ButtonLogOn_Click" />
                    <asp:Button ID="buttonAdminLogOn" CssClass="button-big" runat="server" Text="admin log in"
                        OnClick="ButtonAdminLogOn_Click" />
                    <asp:Label runat="server" EnableViewState="False" ID="labelMessage" ForeColor="Red"></asp:Label>
                    <br/><br/>
                    Use user name and password as 'any' to test log-in.
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
