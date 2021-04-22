using System.Collections.Generic;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;

namespace YounicornApp.Core.Interfaces
{
    public interface IIspOfferService
    {
        Task<IList<IspOffer>> GetItemsAsync();
        Task<IspOffer> CreateOffer(IspOffer user);
        Task<IspOffer> GetOfferById(int id);
        Task<IList<IspOffer>> GetItemsByProviderIdAsync(int id);
        Task UpdateOffer(IspOffer car);
        Task DeleteOfferAsync(int id);       
    }
}
