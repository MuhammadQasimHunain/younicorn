using System.Threading.Tasks;
using YounicornApp.Core.Entities;

namespace YounicornApp.Core.Interfaces
{
    public interface IAccountService
    {
        Task<User> ValidateCredentials(string userName, string password);
    }
}
