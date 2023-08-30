using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ProductManagement.Authorization.Roles;
using ProductManagement.Authorization.Users;
using ProductManagement.MultiTenancy;
using ProductManagement.Tasks;
using ProductManagement.Categories;

namespace ProductManagement.EntityFrameworkCore
{
    public class ProductManagementDbContext : AbpZeroDbContext<Tenant, Role, User, ProductManagementDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }


        public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options)
            : base(options)
        {
        }
    }
}
