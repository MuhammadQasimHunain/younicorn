
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IRepository<User> _repository;

        public AccountService(ILogger<AccountService> logger, IRepository<User> repository)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<User> ValidateCredentials(string userName, string password)
        {
            var items = await _repository.ListAsync();
            return items.FirstOrDefault(i => (i.Username == userName || i.Email == userName) && i.Password == password);  
        }
    }
}
