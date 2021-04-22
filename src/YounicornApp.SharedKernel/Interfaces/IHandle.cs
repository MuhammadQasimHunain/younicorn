using System.Threading.Tasks;
using YounicornApp.SharedKernel;

namespace YounicornApp.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}