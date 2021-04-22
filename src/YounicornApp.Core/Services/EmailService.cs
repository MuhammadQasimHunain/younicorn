using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.Core.Models;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<ProviderService> _logger;
        private readonly IRepository<EmailTemplate> _repository;
        private readonly IRepository<ContactForms> _contactRepository;
        private readonly IRepository<SignUpDetails> _signUpRepository;
        private readonly IUserHistoryService _userHistoryService;
        private readonly IEmailSender _emailSender;

        public EmailService(ILogger<ProviderService> logger, 
            IRepository<EmailTemplate> repository, 
            IEmailSender emailSender, 
            IRepository<ContactForms> contactrepository,
            IUserHistoryService userHistoryService,
            IRepository<SignUpDetails> signUpRepository)
        {
            _repository = repository;
            _contactRepository = contactrepository;
            _logger = logger;
            _emailSender = emailSender;
            _userHistoryService = userHistoryService;
            _signUpRepository = signUpRepository;
        }

        public async Task<EmailTemplate> CreateEmailTemplate(EmailTemplate item)
        {
            return await _repository.AddAsync(item);
        }

        public async Task DeleteEmailTemplateAsync(int id)
        {
            var provider = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(provider);
        }

        public async Task<EmailTemplate> GetEmailTemplateById(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item;
        }

        public async Task<IList<EmailTemplate>> GetItemsAsync()
        {
            var items = await _repository.ListAsync();
            return items;
        }

        public async Task UpdateEmailTemplate(EmailTemplate item)
        {
            await _repository.UpdateAsync(item);
        }

        public async Task<SendEmailResponse> TestEmailAsync(EmailTemplate item, string type)
        {
            try
            {
                int templateID = type.Equals("NewSignup") ? 1 : 2;
                string to = string.Empty;
                string firstname = string.Empty;
                string surname = string.Empty;
                string planname = string.Empty;
                string emailbody = string.Empty;
                if (type.Equals("NewSignup"))
                {
                    var signUp = await _signUpRepository.ListAsync();
                    if (signUp.Count >0)
                    {
                        var planName = (await _userHistoryService.GetISPOffers()).Where(d => d.Id == signUp[0].IspOfferId).FirstOrDefault();
                        to = signUp[0].Email;
                        emailbody = item.Body.Replace("#firstname#", signUp[0].Firstname).Replace("#surname#", signUp[0].Lastname).Replace("#planname#", planName?.Value);
                    }
                }
                else if (type.Equals("NewContact"))
                {
                    var contactForms = await _contactRepository.ListAsync();
                    if (contactForms.Count > 0)
                    {
                        to = contactForms[0].Email;
                        emailbody = item.Body.Replace("#firstname#", contactForms[0].FirstName).Replace("#surname#", contactForms[0].SurName).Replace("#planname#", string.Empty);
                    }
                }
                if (!string.IsNullOrEmpty(type))
                {
                    string message = await _emailSender.SendEmailAsync(to, item.SendCC.Split(';').ToList(), item.SendBCC.Split(';').ToList(), item.Subject, emailbody);
                    return new SendEmailResponse { Message = message, Success = (message.Split('-')[0]).Equals("Error") };
                }

            }
            catch (Exception exp)
            {
                return new SendEmailResponse { Message = exp.Message, Success = false };
            }
            return new SendEmailResponse { Message = string.Empty, Success = false };

        }




    }
}
