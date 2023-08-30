using Abp.Authorization;
using ProductManagement.Authorization.Roles;
using ProductManagement.Authorization.Users;

namespace ProductManagement.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
