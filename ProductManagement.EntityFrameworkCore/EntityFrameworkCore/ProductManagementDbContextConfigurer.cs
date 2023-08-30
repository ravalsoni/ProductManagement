using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.EntityFrameworkCore
{
    public static class ProductManagementDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ProductManagementDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ProductManagementDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
