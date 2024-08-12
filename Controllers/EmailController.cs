using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Dummymvc3.Models;

namespace Dummymvc3.Controllers
{
    public class EmailController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult SendEmail()
        {
            return View(new EmailViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var emailSettings = _configuration.GetSection("EmailSettings");
                var host = emailSettings["Host"];
                var port = int.Parse(emailSettings["Port"]);
                var username = emailSettings["Username"];
                var password = emailSettings["Password"];

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(username),
                    Subject = model.Subject,
                    Body = model.Message,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(model.ToEmail);

                using var smtpClient = new SmtpClient(host, port)
                {
                    Credentials = new NetworkCredential(username, password),
                    EnableSsl = true
                };

                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                    ViewBag.Message = "Email sent successfully!";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = $"Error sending email: {ex.Message}";
                }
            }
            return View(model);
        }
    }
}
