using System.Collections.Generic;
using ProductManagement.Roles.Dto;

namespace ProductManagement.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
