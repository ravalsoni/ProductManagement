using System.Threading.Tasks;
using ProductManagement.Configuration.Dto;

namespace ProductManagement.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
