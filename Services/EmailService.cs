using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CreditelApp.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendCreditNotificationAsync(string client, decimal amount, string commercial)
        {
            var message = new MailMessage();
            message.From = new MailAddress(_config["Email:From"]);
            message.To.Add("fyasocialcapital@gmail.com");
            message.Subject = "Nuevo crédito registrado";
            message.Body = $"Cliente: {client}\nValor: {amount}\nComercial: {commercial}\nFecha: {DateTime.Now}";

            using var smtp = new SmtpClient(_config["Email:Smtp"], int.Parse(_config["Email:Port"]!))
            {
                Credentials = new NetworkCredential(
                    _config["Email:User"],
                    _config["Email:Password"]
                ),
                EnableSsl = true
            };

            await smtp.SendMailAsync(message);
        }
    }
}

