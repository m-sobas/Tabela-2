using Microsoft.EntityFrameworkCore;
using Tabela.Models.Domains;

namespace Tabela
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
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
        }

        public DbSet<Query> Queries { get; set; }
        public DbSet<Template> Templates { get; set; }
    }
}