using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ProductManagement.Authorization;

namespace ProductManagement
{
    [DependsOn(
        typeof(ProductManagementCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ProductManagementApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ProductManagementAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ProductManagementApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
