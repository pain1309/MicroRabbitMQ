using MicroRabbit.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MicroRabbit.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
        {
        }

        public DbSet<TransferLog> TransferLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MicroRabbit.Transfer.Api/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<TransferDbContext>();
            var connectionString = configuration.GetConnectionString("TransferDbConnection");
            optionsBuilder.UseSqlServer(connectionString, options =>
            {
                options.MigrationsHistoryTable("__UsersMigrationsHistory", "TransferLogs");
            });
        }
    }
    // xử lý khi tầng chưa dbcontext k cùng với tầng khởi tạo service provider 
    // https://medium.com/oppr/net-core-using-entity-framework-core-in-a-separate-project-e8636f9dc9e5
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TransferDbContext>
    {
        public TransferDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MicroRabbit.Transfer.Api/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<TransferDbContext>();
            var connectionString = configuration.GetConnectionString("TransferDbConnection");
            builder.UseSqlServer(connectionString);
            return new TransferDbContext(builder.Options);
        }
    }
}
