using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabela.Models.Domains
{
    public class Template
    {
        public Template()
        {
           Queries = new Collection<Query>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<Query> Queries { get; set; }
    }
}
