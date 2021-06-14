using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using UGIM.Server.Services.Abstract;

namespace UGIM.Server.Services.Concrete
{
    public class SmtpEmailSender : IMailService
    {
        private string _host;
        private int _port;
        private bool _enableSSl;
        private string _username;
        private string _password;
        public SmtpEmailSender(string host, int port, bool enableSsl, string username, string password)
        {
            _host = host;
            _port = port;
            _enableSSl = enableSsl;
            _username = username;
            _password = password;
        }

        public Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = _enableSSl
            };
            return client.SendMailAsync(new MailMessage(_username, toEmail, subject, content)
            {
                IsBodyHtml = true
            });
        }
    }
}
