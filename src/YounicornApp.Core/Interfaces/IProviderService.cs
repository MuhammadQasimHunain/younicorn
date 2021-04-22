using System.Collections.Generic;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;

namespace YounicornApp.Core.Interfaces
{
    public interface IProviderService
    {
        Task<IList<Provider>> GetItemsAsync();
        Task<Provider> CreateProvider(Provider item);
        Task<Provider> GetProviderById(int id);
        Task UpdateProvider(Provider item);
        Task DeleteProviderAsync(int id);
    }
}
