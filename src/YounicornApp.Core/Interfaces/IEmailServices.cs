using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Models;
using YounicornApp.Core.Services;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.Core.Interfaces
{
    public interface IEmailService
    {
        Task<IList<EmailTemplate>> GetItemsAsync();
        Task<EmailTemplate> CreateEmailTemplate(EmailTemplate item);
        Task<EmailTemplate> GetEmailTemplateById(int id);
        Task UpdateEmailTemplate(EmailTemplate item);
        Task DeleteEmailTemplateAsync(int id);
        Task<SendEmailResponse> TestEmailAsync(EmailTemplate item, string type);
    }
}
