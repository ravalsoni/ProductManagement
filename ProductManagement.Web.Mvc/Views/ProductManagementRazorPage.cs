using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace ProductManagement.Web.Views
{
    public abstract class ProductManagementRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ProductManagementRazorPage()
        {
            LocalizationSourceName = ProductManagementConsts.LocalizationSourceName;
        }
    }
}
