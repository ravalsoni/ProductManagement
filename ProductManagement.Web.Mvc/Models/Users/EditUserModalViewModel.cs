using System.Collections.Generic;
using System.Linq;
using ProductManagement.Roles.Dto;
using ProductManagement.Users.Dto;

namespace ProductManagement.Web.Models.Users
{
    public class EditCategoryModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
