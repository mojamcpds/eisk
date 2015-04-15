<%@ Page Language="C#" AutoEventWireup="true" CodeFile="print-page.aspx.cs" Inherits="Code_Sample_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Print View</title>
    <link href="../App_Themes/brown/css/more.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:FormView SkinID="FormView" ID="formViewEmployee" runat="server" DataSourceID="odsOrderDetails"
            DataKeyNames="EmployeeID" EnableViewState="False">
            <ItemTemplate>
                <table style="margin-left: 20px; width: 600px">
                    <tr>
                        <td colspan="3" style="text-align:right"> 
                            <a href="javascript:window.print();">Print</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <h1>
                                Employee Details</h1>
                        </td>
                    </tr>
                    <tr>
                        <td class="captionTBL">
                            Employee Name
                        </td>
                        <td class="spacerTBL">
                            :
                        </td>
                        <td class="datafieldTBL">
                            <%# Eval("FirstName") %>
                        </td>
                    </tr>
                    <tr>
                        <td class="captionTBL">
                            Employee Country
                        </td>
                        <td class="spacerTBL">
                            :
                        </td>
                        <td class="datafieldTBL">
                            <%#Eval("Country")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="captionTBL">
                            Title
                        </td>
                        <td class="spacerTBL">
                            :
                        </td>
                        <td class="datafieldTBL">
                            <%#Eval("Title")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="captionTBL">
                            Title of Courtesy
                        </td>
                        <td class="spacerTBL">
                            :
                        </td>
                        <td class="datafieldTBL">
                            <%#Eval("TitleOfCourtesy")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="captionTBL">
                            Birth Date
                        </td>
                        <td class="spacerTBL">
                            :
                        </td>
                        <td class="datafieldTBL">
                            <%#Eval("BirthDate")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="captionTBL">
                            Hire Date
                        </td>
                        <td class="spacerTBL">
                            :
                        </td>
                        <td class="datafieldTBL">
                            <%#Eval("HireDate")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="captionTBL">
                            Address
                        </td>
                        <td class="spacerTBL">
                            :
                        </td>
                        <td class="datafieldTBL">
                            <%#Eval("Address")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="captionTBL">
                            City
                        </td>
                        <td class="spacerTBL">
                            :
                        </td>
                        <td class="datafieldTBL">
                            <%#Eval("City")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="captionTBL">
                            Region
                        </td>
                        <td class="spacerTBL">
                            :
                        </td>
                        <td class="datafieldTBL">
                            <%#Eval("Region")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="captionTBL">
                            Postal Code
                        </td>
                        <td class="spacerTBL">
                            :
                        </td>
                        <td class="datafieldTBL">
                            <%#Eval("PostalCode")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="captionTBL">
                            Home Phone
                        </td>
                        <td class="spacerTBL">
                            :
                        </td>
                        <td class="datafieldTBL">
                            <%#Eval("HomePhone")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="captionTBL">
                            Extension
                        </td>
                        <td class="spacerTBL">
                            :
                        </td>
                        <td class="datafieldTBL">
                            <%#Eval("Extension")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="captionTBLTop">
                            Notes
                        </td>
                        <td class="spacerTBLTop">
                            :
                        </td>
                        <td class="datafieldTBL">
                            <%#Eval("Notes")%>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right" colspan="3">
                            <br />
                             <a href="javascript:window.close();">
                                Close</a>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="odsOrderDetails" runat="server" TypeName="Entity.Employee"
            SelectMethod="GetEmployeeByEmployeeID" OnSelecting="OdsOrderDetails_Selecting">
            <SelectParameters>
                <asp:SessionParameter Name="employeeID" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
