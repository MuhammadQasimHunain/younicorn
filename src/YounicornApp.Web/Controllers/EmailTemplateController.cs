using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Interfaces;
using YounicornApp.Web.ApiModels;

namespace YounicornApp.Web.Controllers
{
    public class EmailTemplateController : Controller
    {
        private readonly IEmailSender EmailSender;
        private readonly IEmailService EmailService;

        public EmailTemplateController(IEmailSender _emailSender, IEmailService _emailService)
        {
            EmailSender = _emailSender;
            EmailService = _emailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetEmailAsync(string type)
        {
            try
            {
                int id = string.IsNullOrEmpty(type) ? 1 : type.Equals("NewSignup") ? 1 : 2;
                var result = await EmailService.GetEmailTemplateById(id);
                return Json(result);
            }
            catch (Exception exp)
            {
                return Json(string.Empty);
            }
            
        }


        [HttpPost]
        public async Task<IActionResult> TestEmailAsync(EmailTemplateDTO model)
        {
            if (model.isValid())
            {
                var item = await EmailService.TestEmailAsync(new Core.Entities.EmailTemplate
                {
                    Body = model.Body,
                    Subject = model.Subject,
                    SendBCC = model.SendBCC,
                    SendCC = model.SendCC
                }, model.Type);

                return Json(new EmailResponse { Message = item.Message, Success = item.Success });
            }
            else
            {
                return Json(new EmailResponse { Message = "Model is Invalid", Success = false });
            }
        }

        [HttpPost]
        public IActionResult SaveEmail(EmailTemplateDTO model)
        {
            if (model.isValid())
            {
                var emailTemplate = EmailService.UpdateEmailTemplate(
                    new Core.Entities.EmailTemplate 
                    {
                        Id = model.Type.Equals("NewSignup") ? 1 : 2,
                        Body = model.Body,
                        Subject = model.Subject,
                        SendBCC = model.SendBCC,
                        SendCC = model.SendCC
                    }
                    );
                return Json(new EmailResponse { Message = "Email Is Updated.", Success = false });
            }
            else
            {
                return Json(new EmailResponse { Message = "Model is Invalid", Success = false });
            }
        }
    }
}
