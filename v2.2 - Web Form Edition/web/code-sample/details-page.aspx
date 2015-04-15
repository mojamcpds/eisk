<%@ Page Language="C#" MasterPageFile="~/master/default.master" AutoEventWireup="true"
    CodeFile="details-page.aspx.cs" Inherits="Code_Sample_Details_Page" Title="Employee Details Page" %>

<%@ Register Assembly="EmployeeInfoWebStarterKitLib" Namespace="Utilities" TagPrefix="CustomControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" runat="Server">

    <script src="../client-scripts/date-picker.js" type="text/javascript">
    
    </script>

    <noscript>
    </noscript>
    <asp:FormView SkinID="FormView" ID="formViewEmployee" runat="server" DataSourceID="odsOrderDetails"
        DataKeyNames="EmployeeId" EnableViewState="False" OnItemUpdating="FormViewEmployee_ItemUpdating"
        OnItemInserting="FormViewEmployee_ItemInserting" OnDataBound="FormViewEmployee_DataBound">
        <ItemTemplate>
            <table width="560" id="tblItem">
                <caption>
                </caption>
                <thead>
                    <tr>
                        <th class="invisible" title="Item template">
                        </th>
                    </tr>
                </thead>
                <tr>
                    <td colspan="4" class="printCommandTBL">
                        <asp:LinkButton ID="LinkButton1" OnClick="ButtonGoToPrintPage_Click" runat="server">[ Print Info ]</asp:LinkButton>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <h1>
                            Employee Details</h1>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        Name
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
                        Country
                    </td>
                    <td class="spacerTBL">
                        :
                    </td>
                    <td class="datafieldTBL">
                        <%# Eval("Country") %>
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
                        <%# Eval("Title") %>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        Title Of Courtesy
                    </td>
                    <td class="spacerTBL">
                        :
                    </td>
                    <td class="datafieldTBL">
                        <%# Eval("TitleOfCourtesy") %>
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
                        <%# Eval("BirthDate") %>
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
                        <%# Eval("HireDate") %>
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
                        <%# Eval("Address") %>
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
                        <%# Eval("City") %>
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
                        <%# Eval("Region") %>
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
                        <%# Eval("PostalCode")%>
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
                        <%# Eval("HomePhone")%>
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
                        <%# Eval("Extension")%>
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
                        <%# Eval("Notes") %>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBLTop">
                        Picture
                    </td>
                    <td class="spacerTBLTop">
                        :
                    </td>
                    <td class="datafieldTBL">
                        <img id="Img1" alt="employee image" runat="server" src='<%# "image.aspx?ImageBinary=" +Eval("employeeId").ToString() %>'
                            width="200" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="dataCommandTBL" colspan="4">
                        <asp:Button CausesValidation="false" ID="btnBack" runat="server" Text="Back" OnClick="ButtonGoToListPage_Click"
                            SkinID="AspButton" />
                        <asp:Button ID="Button2" runat="server" Text="Edit" OnClick="ButtonEdit_Click" SkinID="AspButton" />
                    </td>
                </tr>
                <tr>
                    <td class="printCommandTBL" colspan="4">
                        <asp:LinkButton ID="LinkButton4" OnClick="ButtonGoToPrintPage_Click" runat="server">[ Print Info ]</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <EditItemTemplate>
            <table width="560" id="tblEdit">
                <caption>
                </caption>
                <thead>
                    <tr>
                        <th class="invisible" title="Edit template">
                        </th>
                    </tr>
                </thead>
                <tr>
                    <td class="printCommandTBL" colspan="3">
                        <asp:LinkButton ID="lbPrint" OnClick="ButtonGoToPrintPage_Click" runat="server" AccessKey="P">[ Print Info ]</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <h1>
                            Employee Details
                        </h1>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label EnableViewState="False" runat="server" ID="lblMessage" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="requiredLabelTBL" colspan="3" style="height: 18px">
                        <span>* indicates required field.</span>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        <span class="requiredLabelCaptionTBL">* </span>First Name:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="txtFirstName" Text='<%# Bind("FirstName") %>' runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Required"
                            ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        <span class="requiredLabelCaptionTBL">* </span>Last Name:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="txtLastName" Text='<%# Bind("LastName") %>' runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required"
                            ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        <span class="requiredLabelCaptionTBL">* </span>Country:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL">
                        <CustomControl:CountryDropDown SelectedValue='<%# Bind("Country") %>' runat="server"
                            ID="ddlCountry">
                        </CustomControl:CountryDropDown>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                            ControlToValidate="ddlCountry" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        Reports To:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL">
                        <asp:DropDownList ID="ddlReportsTo" runat="server" AppendDataBoundItems="true" DataSourceID="odsEmployeeList"
                            SelectedValue='<%# Bind("ReportsTo") %>' DataTextField="FirstName" DataValueField="EmployeeId">
                            <asp:ListItem Text="None" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsEmployeeList" runat="server" TypeName="Entity.Employee"
                            SelectMethod="SelectAllEmployees" />
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        Title:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="txtTitle" Text='<%# Bind("Title") %>' runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        Title Of Courtesy:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="txtTitleOfCourtesy" Text='<%# Bind("TitleOfCourtesy") %>' runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        Birth Date:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="txtnewBirthDate" runat="server" Text='<%# Bind("BirthDate")%>'></asp:TextBox>
                        <a href="#" onclick="javascript:displayDatePicker('<%=formViewEmployee.FindControl("txtnewBirthDate").ClientID %>');return false;">
                            <img style="border: 0px none;" src="../image/cal.jpg" alt="calculator" />
                        </a>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        <span class="requiredLabelCaptionTBL">* </span>Hire Date:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="txtHireDate" Text='<%# Bind("HireDate") %>' runat="server"></asp:TextBox>
                        <a href="#" onclick="javascript:displayDatePicker('<%=formViewEmployee.FindControl("txtHireDate").ClientID %>');return false;">
                            <img style="border: 0px none;" src="../image/cal.jpg" alt="calculator" />
                        </a>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required"
                            ControlToValidate="txtHireDate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        <span class="requiredLabelCaptionTBL">* </span>Address:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="txtAddress" Text='<%# Bind("Address") %>' runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                            ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        City:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="txtCity" Text='<%# Bind("City") %>' runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        Region:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="txtRegion" Text='<%# Bind("Region") %>' runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        Postal Code:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="txtPostalCode" Text='<%# Bind("PostalCode") %>' runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBLTop">
                        Notes:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="txtNotes" Height="100" Width="400px" Text='<%# Bind("Notes") %>'
                            runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        <span class="requiredLabelCaptionTBL">* </span>Home Phone:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="txtHomePhone" Text='<%# Bind("HomePhone") %>' runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required"
                            ControlToValidate="txtHomePhone"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        Extension:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="txtExtension" Text='<%# Bind("Extension") %>' runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL">
                        Photo Path:
                    </td>
                    <td class="spacerTBL">
                    </td>
                    <td class="datafieldTBL" align="left">
                        <asp:TextBox ID="TextBox2" Text='<%# Bind("PhotoPath") %>' runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="captionTBL" style="height: 24px">
                        Picture
                    </td>
                    <td class="spacerTBL" style="height: 24px">
                    </td>
                    <td class="datafieldTBL" style="height: 24px">
                        <asp:FileUpload ID="fuPhotoUpload" runat="server"></asp:FileUpload>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="dataCommandTBL" colspan="3">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="ButtonSave_Click" SkinID="AspButton"
                            AccessKey="s" />
                        <asp:Button ID="btnBack" CausesValidation="false" runat="server" Text="Back" OnClick="ButtonGoToListPage_Click"
                            SkinID="AspButton" AccessKey="b" />
                    </td>
                </tr>
                <tr>
                    <td class="printCommandTBL" colspan="3">
                        <asp:LinkButton ID="LinkButton5" OnClick="ButtonGoToPrintPage_Click" runat="server">[ Print Info ]</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </EditItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="odsOrderDetails" runat="server" TypeName="Entity.Employee"
        SelectMethod="GetEmployeeByEmployeeId" InsertMethod="CreateNewEmployee" UpdateMethod="UpdateEmployee"
        DataObjectTypeName="Entity.Employee" OnSelecting="OdsOrderDetails_Selecting"
        OnUpdated="OdsOrderDetails_Updated" OnInserted="OdsOrderDetails_Inserted">
        <UpdateParameters>
            <asp:ControlParameter Name="employeeId" ControlID="formViewEmployee" />
            <asp:Parameter Name="title" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="titleOfCourtesy" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="birthDate" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="city" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="region" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="postalCode" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="extension" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="photo" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="notes" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="reportsTo" Type="Int32" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="photoPath" ConvertEmptyStringToNull="true" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="title" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="titleOfCourtesy" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="birthDate" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="city" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="region" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="postalCode" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="extension" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="photo" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="notes" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="reportsTo" Type="Int32" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="photoPath" ConvertEmptyStringToNull="true" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter Name="employeeId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
