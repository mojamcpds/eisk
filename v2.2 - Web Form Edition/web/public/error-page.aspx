<%@ Page Language="C#" MasterPageFile="~/master/default.master" AutoEventWireup="true"
    CodeFile="error-page.aspx.cs" Inherits="Public_Error_Page" Title="Error occured!" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" runat="Server">
    <table id="tblOuter" class="contentcontainerTBL" summary="table1 summary info" width="100%">
        <tr>
            <td>
                <p class="errorMessageTitle">
                    <b>Oops an error occured !</b>
                </p>
                <p class="errorMessage">
                    Sorry an error occured during processing your information. Please use browser's
                    BACK button, and put the valid information to continue.
                    <br />
                    If the problem still exists, please close the browser & enter other data. This error
                    has been automatically reported to the developer, which will be fixed with in few
                    hours.
                    <br />
                    Alternatively, the system is updating. Please try again later. We apologize for
                    any inconvenience.
                </p>
            </td>
        </tr>
    </table>
</asp:Content>
