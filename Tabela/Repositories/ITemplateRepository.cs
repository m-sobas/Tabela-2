using Tabela.Models.Domains;

namespace Tabela.Repositories
{
    public interface ITemplateRepository
    {
        void Add(Template template);
        Template GetById(int id);
        void Update(Template template);
    }
}
