using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.Core.Services
{
    public class ContactFormService : IContactFormService
    {

        private readonly ILogger<ProviderService> _logger;
        private readonly IRepository<ContactForms> _repository;


        public ContactFormService(ILogger<ProviderService> logger, IRepository<ContactForms> repository)
        {
            _repository = repository;
            _logger = logger;
        }


        public async Task<ContactForms> CreateContactFormsAsync(ContactForms item)
        {
            return await _repository.AddAsync(item);
        }

        public async Task DeleteContactFormsAsync(int id)
        {
            var provider = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(provider);
        }

        public async Task<ContactForms> GetContactFormsByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item;
        }

        public async Task<IList<ContactForms>> GetItemsAsync()
        {
            var items = await _repository.ListAsync();
            return items;
        }

        public async Task UpdateContactFormsAsync(ContactForms item)
        {
            await _repository.UpdateAsync(item);
        }
    }
}
