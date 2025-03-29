using Tabela.Models.Domains;

namespace Tabela.Models.ViewModels
{
    public class TemplateViewModel
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public DateTime TemplateDateTime { get; set; }
        public IEnumerable<QueryViewModel> Queries { get; set; }
    }
}
