using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.Core.Services
{
    public class ProviderService : IProviderService
    {
        private readonly ILogger<ProviderService> _logger;
        private readonly IRepository<Provider> _repository;

        public ProviderService(ILogger<ProviderService> logger, IRepository<Provider> providerRepository)
        {
            _logger = logger;
            _repository = providerRepository;
        }

        public async Task<Provider> CreateProvider(Provider item)
        {
            return await _repository.AddAsync(item);
        }

        public async Task DeleteProviderAsync(int id)
        {
            var provider = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(provider);
        }

        public async Task<IList<Provider>> GetItemsAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task<Provider> GetProviderById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateProvider(Provider provider)
        {
            await _repository.UpdateAsync(provider);
        }
    }
}
