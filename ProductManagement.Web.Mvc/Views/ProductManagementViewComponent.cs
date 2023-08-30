using Abp.AspNetCore.Mvc.ViewComponents;

namespace ProductManagement.Web.Views
{
    public abstract class ProductManagementViewComponent : AbpViewComponent
    {
        protected ProductManagementViewComponent()
        {
            LocalizationSourceName = ProductManagementConsts.LocalizationSourceName;
        }
    }
}
