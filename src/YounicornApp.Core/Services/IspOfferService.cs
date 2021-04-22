using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.Core.Services
{
    public class IspOfferService : IIspOfferService
    {
        private readonly ILogger<ProviderService> _logger;
        private readonly IRepository<IspOffer> _repository;
        private readonly IRepository<Provider> _provRepository;

        public IspOfferService(ILogger<ProviderService> logger, IRepository<IspOffer> repository, IRepository<Provider> provRepository)
        {
            _repository = repository;
            _provRepository = provRepository;
            _logger = logger;
        }

        public async Task<IspOffer> CreateOffer(IspOffer item)
        {
            return await _repository.AddAsync(item);
        }

        public async Task DeleteOfferAsync(int id)
        {
            var provider = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(provider);
        }

        public async Task<IList<IspOffer>> GetItemsAsync()
        {
            var items = await _repository.ListAsync();
            foreach (var i in items)
            {
                i.Isp = await _provRepository.GetByIdAsync(i.Ispid);
            }
            return items;
        }

        public async Task<IList<IspOffer>> GetItemsByProviderIdAsync(int providerId)
        {
            var items = await _repository.ListAsync();
            return items.Where(i => i.Ispid == providerId).ToList();
        }

        public async Task<IspOffer> GetOfferById(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            item.Isp = await _provRepository.GetByIdAsync(item.Ispid);
           // item.Isp = ispData;
            return item;
        }

        public async Task UpdateOffer(IspOffer item)
        {
            item.ModifiedDate = DateTime.UtcNow;
            await _repository.UpdateAsync(item);
        }
    }
}
