using System.Threading.Tasks;
using YounicornApp.Core.Entities;

namespace YounicornApp.Core.Interfaces
{
    public interface ISignUpService
    {
        Task<SignUpDetails> UserSignUp(SignUpDetails details);
    }
}
