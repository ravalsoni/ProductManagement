﻿using System.Threading.Tasks;
using Abp.Application.Services;
using ProductManagement.Authorization.Accounts.Dto;

namespace ProductManagement.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
