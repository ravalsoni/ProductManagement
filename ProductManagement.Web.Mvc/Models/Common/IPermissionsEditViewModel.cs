using System.Collections.Generic;
using ProductManagement.Roles.Dto;

namespace ProductManagement.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}