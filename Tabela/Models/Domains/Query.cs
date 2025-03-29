using System.ComponentModel.DataAnnotations.Schema;
using Tabela.Models.ViewModels;

namespace Tabela.Models.Domains
{
    public class Query
    {
        public int Id { get; set; }
        public bool Radio { get; set; }
        public int? Counter { get; set; }
        public string ImageFileName { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public int TemplateId { get; set; }
        public Template Template { get; set; }
    }
}
