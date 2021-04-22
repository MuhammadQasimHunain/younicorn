using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;

namespace YounicornApp.Core.Interfaces
{
    public interface IContactFormService
    {
        Task<IList<ContactForms>> GetItemsAsync();
        Task<ContactForms> CreateContactFormsAsync(ContactForms item);
        Task<ContactForms> GetContactFormsByIdAsync(int id);
        Task UpdateContactFormsAsync(ContactForms item);
        Task DeleteContactFormsAsync(int id);

    }
}
