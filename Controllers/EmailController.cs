using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System;

namespace Zurex.Controllers
{
    public class EmailController : Controller
    {
        [HttpPost] // Indica que este método responde a solicitudes POST
        public IActionResult SendEmail(string name, string email, string subject, string message)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.office365.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("Mikemask930515@outlook.es", "@MiLl3r2123"),
                    EnableSsl = true,
                };

                // Crear el mensaje de correo
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("mikemask930515@gmail.com"), // Tu correo configurado
                    Subject = subject,
                    Body = $"<p><strong>Nombre:</strong> {name}</p>" +
                           $"<p><strong>Correo del remitente:</strong> {email}</p>" +
                           $"<p><strong>Mensaje:</strong> {message}</p>",
                    IsBodyHtml = true,
                };

                // Correo donde tú recibirás los mensajes
                mailMessage.To.Add("lmarriagamoreno93@gmail.com");

                // Opcional: permite responder directamente al correo del usuario
                mailMessage.ReplyToList.Add(email);

                smtpClient.Send(mailMessage);

                return RedirectToAction("Success"); // Redirige a una página de éxito (asegurémonos de que la página existe)
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
                // Si ocurre un error, redirige a la página de error
                return RedirectToAction("Error", new { message = ex.Message }); // Pasar el mensaje del error a la vista
            }
        }

        // Acción para mostrar la vista de error
        public IActionResult Error(string message)
        {
            ViewBag.ErrorMessage = message; // Almacenamos el mensaje de error en ViewBag
            return View(); // Mostrar la vista de error
        }
    }
}
