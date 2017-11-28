using System.Net.Mail;
using System.Text;

namespace Creational_Builder.Extension_Methods
{
    public class Program
    {
        public static void Main()
        {
            var mail = new MailMessage()
                .From("alexnizov@gmail.com")
                .To("support@microsoft.com")
                .Cc("some_email@mail.com")
                .Subject("Msdn is down!")
                .Body("Please Fix!", Encoding.UTF8);

            new SmtpClient().Send(mail);
        }
    }
    public static class MailMessageByilderEx
    {
        public static MailMessage From(this MailMessage mailMessage, string address)
        {
            mailMessage.From = new MailAddress(address);
            return mailMessage;
        }

        public static MailMessage To(this MailMessage mailMessage, string address)
        {
            mailMessage.To.Add(address);
            return mailMessage;
        }

        public static MailMessage Cc(this MailMessage mailMessage, string address)
        {
            mailMessage.CC.Add(address);
            return mailMessage;
        }

        public static MailMessage Subject(this MailMessage mailMessage, string subject)
        {
            mailMessage.Subject = subject;
            return mailMessage;
        }

        public static MailMessage Body(this MailMessage mailMessage, string body, Encoding encoding)
        {
            mailMessage.Body = body;
            mailMessage.BodyEncoding = encoding;
            return mailMessage;
        }
    }
}
