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

        public void Add(Template template)
        {
            _context.Templates
                .Add(template);
            _context.SaveChanges();
        }

        public Template GetById(int id)
        {
            return _context.Templates
                .Include(x => x.Queries)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void Update(Template template)
        {
            _context.Templates.Update(template);
            _context.SaveChanges();
        }

    }
}
