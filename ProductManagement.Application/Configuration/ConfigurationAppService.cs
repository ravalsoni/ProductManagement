using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ProductManagement.Configuration.Dto;

namespace ProductManagement.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ProductManagementAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
