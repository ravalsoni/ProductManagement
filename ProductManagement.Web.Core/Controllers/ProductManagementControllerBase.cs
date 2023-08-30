using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ProductManagement.Controllers
{
    public abstract class ProductManagementControllerBase: AbpController
    {
        protected ProductManagementControllerBase()
        {
            LocalizationSourceName = ProductManagementConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
