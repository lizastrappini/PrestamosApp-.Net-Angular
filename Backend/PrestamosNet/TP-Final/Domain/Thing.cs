using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Final.Domain
{
    public class Thing
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("Category")]
        public int IdCategory { get; set; }

        [ForeignKey("Person")]
        public int PersonDni { get; set; }
    }
}
