using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezarvasyon", "berkaygenceroglu6@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAdressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAdressTo);
            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = createMailDto.Body;
            mimeMessage.Body = bodybuilder.ToMessageBody();
            mimeMessage.Subject = createMailDto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("berkaygenceroglu6@gmail.com", "oikguxlicnznwpwu");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return RedirectToAction("Index","Category");
        }
    }
}
