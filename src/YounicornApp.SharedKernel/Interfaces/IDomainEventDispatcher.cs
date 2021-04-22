using System.Threading.Tasks;
using YounicornApp.SharedKernel;

namespace YounicornApp.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}