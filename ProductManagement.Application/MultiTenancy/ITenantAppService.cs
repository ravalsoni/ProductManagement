using Abp.Application.Services;
using ProductManagement.MultiTenancy.Dto;

namespace ProductManagement.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

