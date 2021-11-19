using System.Threading.Tasks;

namespace Marketplace.Contracts
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}