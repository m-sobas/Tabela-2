using Tabela.Models.Domains;

namespace Tabela.Models.ViewModels
{
    public class QueryViewModel
    {
        public int Id { get; set; }
        public bool Radio { get; set; }
        public int? Counter { get; set; }
        public IFormFile File { get; set; }
    }
}
