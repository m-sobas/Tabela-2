using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using Tabela.Models.Domains;

namespace Tabela
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public static readonly ILoggerFactory _loggerFactory =
            new NLogLoggerFactory();

        private readonly IConfiguration _configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection")
                );

            optionsBuilder
                .UseLoggerFactory(_loggerFactory)
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();  
            }

        public DbSet<Query> Queries { get; set; }
        public DbSet<Template> Templates { get; set; }
    }
}