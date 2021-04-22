
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.Core.Services
{
    public class SignUpService : ISignUpService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IRepository<SignUpDetails> _repository;

        public SignUpService(ILogger<AccountService> logger, IRepository<SignUpDetails> repository)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<SignUpDetails> UserSignUp(SignUpDetails details)
        {
            details.CreatedBy = 1;
            return await _repository.AddAsync(details);
        }
    }
}
