<%@ Page Language="C#" %>

<%@ Import Namespace="System.Net.Mail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    void SendMail()
    {
        string MailServer = txtSmtp.Text;
        string from = txtFrom.Text;

        SmtpClient smtpClient = new SmtpClient();
        MailMessage message = new MailMessage();

        try
        {
            MailAddress fromAddress = new MailAddress(from, "Admin");

            // You can specify the host name or ipaddress of your server
            // Default in IIS will be localhost 
            smtpClient.Host = txtSmtp.Text;
            System.Net.NetworkCredential credential = new System.Net.NetworkCredential(txtSmtpUser.Text, txtSmtpPassword.Text);
            smtpClient.Credentials = credential;

            //From address will be given as a MailAddress Object
            message.From = fromAddress;

            // To address collection of MailAddress
            message.To.Add(txtTo.Text);
            message.Subject = txtTest.Text;

            // CC and BCC optional
            // You can specify Address directly as string
            message.Bcc.Add(new MailAddress("joy_csharp@yahoo.com"));

            //Body can be Html or text format
            //Specify true if it  is html message
            message.IsBodyHtml = true;

            // Message body content
            message.Body = txtTest.Text;

            // Send SMTP mail
            smtpClient.Send(message);

            Response.Write("Email successfully sent.");
        }
        catch
        {
            throw;
        }
    }

    protected void ButtonSendMessage_Click(object sender, EventArgs e)
    {
        SendMail();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Tester</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Email Tester<br />
        From
        <asp:TextBox ID="txtFrom" runat="server">joy_csharp@yahoo.com</asp:TextBox><br />
        To
        <asp:TextBox ID="txtTo" runat="server">joy_csharp@hotmail.com</asp:TextBox><br />
        Text
        <asp:TextBox ID="txtTest" runat="server">test message</asp:TextBox><br />
        Smtp Server
        <asp:TextBox ID="txtSmtp" runat="server">smtp.example.com</asp:TextBox><br />
        Smtp User
        <asp:TextBox ID="txtSmtpUser" runat="server"></asp:TextBox><br />
        Smtp Password
        <asp:TextBox ID="txtSmtpPassword" runat="server"></asp:TextBox><br />
        <asp:Button ID="buttonSendMessage" runat="server" OnClick="ButtonSendMessage_Click"
            Text="Send" /></div>
    </form>
</body>
</html>
