using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using ShoppingCart.Bll.Service.Interface;
using ShoppingCart.Bll.ViewModels;
using ShoppingCart.Data;

namespace ShoppingCart.Bll.Service
{
    public class EmailService : IEmailService
    {        
        public void Send(EmailViewModel model, EmailSettings emailSettings)
        {
            if (model != null && emailSettings != null)
            {
                // create message
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(model.From);
                email.To.Add(MailboxAddress.Parse(model.To));
                email.Subject = model.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = model.Body };

                // send email
                using var smtp = new SmtpClient();
                smtp.Connect(emailSettings.SmtpHost, emailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(emailSettings.SmtpUser, emailSettings.SmtpPass);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}
