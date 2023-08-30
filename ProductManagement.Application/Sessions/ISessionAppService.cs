using System.Threading.Tasks;
using Abp.Application.Services;
using ProductManagement.Sessions.Dto;

namespace ProductManagement.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
