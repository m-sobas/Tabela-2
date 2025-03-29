using Tabela.Models.Domains;

namespace Tabela.Repositories
{
    public interface ITemplateRepository
    {
        Template GetTemplateById(int id);
        void AddTemplate(Template template);
    }
}
