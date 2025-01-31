using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Zurex.Controllers
{
    [Route("Email")]
    public class EmailController : Controller
    {
        private readonly IConfiguration _config;

        public EmailController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail(string name, string email, string subject, string message)
        {
            try
            {
                var smtpServer = _config["EmailSettings:SmtpServer"];
                var smtpPort = int.Parse(_config["EmailSettings:SmtpPort"]);
                var senderEmail = _config["EmailSettings:SenderEmail"];
                var senderPassword = _config["EmailSettings:SenderPassword"];

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail, "Formulario de Contacto"),
                    Subject = subject,
                    Body = $"Nombre: {name}\nEmail: {email}\n\nMensaje:\n{message}",
                    IsBodyHtml = false
                };

                mailMessage.To.Add("iran_carrillo_g@outlook.com"); // Cambia esto por el correo de destino

                using (var smtp = new SmtpClient(smtpServer, smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;

                    await smtp.SendMailAsync(mailMessage);
                }

                return Ok(new { message = "Correo enviado correctamente" });
            }
            catch (SmtpException smtpEx)
            {
                return BadRequest($"Error SMTP: {smtpEx.Message}");
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}