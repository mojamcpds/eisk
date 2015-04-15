<%@ Page Theme="" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<html>
<head runat="server">
<title />
   
</head>
<body>

    <script language="C#" runat="server">
        protected void Page_Load(Object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection("server=" + txtServer.Text + ";database=" + txtDatabase.Text + ";user=" + textUserName.Text + ";password=" + txtPassword.Text + ";");
            SqlDataAdapter myCommand = new SqlDataAdapter("select * from " + txtTable.Text, myConnection);

            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.CurrentCulture;
            myCommand.Fill(ds, txtTable.Text);

            MyDataGrid.DataSource = ds.Tables[txtTable.Text].DefaultView;
            MyDataGrid.DataBind();
        }
    </script>
<form runat="server">
    <h3 class="SpecialFont">
        Simple Select to a DataGrid Control</h3>
    <p class="SpecialFont">
        server:
            <asp:TextBox ID="txtServer" runat="server">(local)</asp:TextBox>&nbsp;</p>
    <p class="SpecialFont">
        database:
            <asp:TextBox ID="txtDatabase" runat="server">northwind</asp:TextBox>&nbsp;</p>
    <p>
        table:
        <asp:TextBox ID="txtTable" runat="server">employees</asp:TextBox></p>
    <p>
        user name:
        <asp:TextBox ID="textUserName" runat="server">sa</asp:TextBox></p>
    <p>
        password:
        <asp:TextBox TextMode="Password" ID="txtPassword" runat="server">12345</asp:TextBox>&nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Test" />&nbsp;</p>
        <asp:DataGrid ID="MyDataGrid" runat="server" Width="700" BackColor="#ccccff" BorderColor="black"
        ShowFooter="false" CellPadding="3" CellSpacing="0" Font-Name="Verdana" Font-Size="8pt"
        HeaderStyle-BackColor="#aaaadd" EnableViewState="false" />
        </form>
</body>
</html>
