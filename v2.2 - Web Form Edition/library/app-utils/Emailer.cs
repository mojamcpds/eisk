namespace Utilities
{
    using System;
    using System.Net.Mail;
    using System.Text;
    using System.Net;
    using System.IO;
    /// <summary>
    /// Utility class for sending email
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    public sealed class Emailer
    {
        private Emailer()
        {
        }

        public static void SendMail(string from, string to, string subject, string body, Stream attachment)
        {
            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress(from);
            mailMsg.To.Add(to);
            mailMsg.Subject = subject;
            mailMsg.IsBodyHtml = true;
            mailMsg.BodyEncoding = Encoding.UTF8;
            mailMsg.Body = body;
            mailMsg.Priority = MailPriority.Normal;

            //Message attahment
            if (attachment != null)
                mailMsg.Attachments.Add(new Attachment(attachment, "my.text"));

            // Smtp configuration
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("", "");
            client.Port = 25; //use 465 or 587 for gmail           
            client.Host = "localhost";//for gmail "smtp.gmail.com";
            client.EnableSsl = false;

            MailMessage message = mailMsg;
            
            client.Send(message);
            
        }

    }
}