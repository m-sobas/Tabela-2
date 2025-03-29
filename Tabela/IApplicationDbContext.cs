using Microsoft.EntityFrameworkCore;
using Tabela.Models.Domains;


namespace Tabela
{
    public interface IApplicationDbContext
    {
        DbSet<Query> Queries { get; set; }
        DbSet<Template> Templates { get; set; }
        int SaveChanges();
    }
}
