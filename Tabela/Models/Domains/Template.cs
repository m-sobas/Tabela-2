namespace Tabela.Models.Domains
{
    public class Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<Query> Queries { get; set; }
    }
}
