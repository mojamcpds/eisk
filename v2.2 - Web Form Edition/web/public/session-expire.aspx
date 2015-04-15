<%@ Page Language="C#" MasterPageFile="~/master/default.master" AutoEventWireup="true"
    CodeFile="session-expire.aspx.cs" Inherits="Public_Session_Expire" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="tblOuter" class="contentcontainerTBL" summary="table1 summary info" width="100%">
        <tr>
            <td>
                <h1>
                    Session expired</h1>
                <p>
                    Your session has been expired! Please log-in again.
                </p>
            </td>
        </tr>
    </table>
</asp:Content>
