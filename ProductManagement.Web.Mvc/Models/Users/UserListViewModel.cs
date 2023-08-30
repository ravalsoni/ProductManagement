using System.Collections.Generic;
using ProductManagement.Roles.Dto;

namespace ProductManagement.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
