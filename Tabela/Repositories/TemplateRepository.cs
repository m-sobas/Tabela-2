using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Tabela.Models.Domains;

namespace Tabela.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly IApplicationDbContext _context;
        public TemplateRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void AddTemplate(Template template)
        {
            _context.Templates.Add(template);
            _context.SaveChanges();
        }

        public Template GetTemplateById(int id)
        {
            return _context.Templates
                .Include(x => x.Queries)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
    }
}
