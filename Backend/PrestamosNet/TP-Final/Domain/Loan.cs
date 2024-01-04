using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Final.Domain
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Status { get; set; }
        public string BorrowerName { get; set; }

        [ForeignKey("Person")]
        public int DniPerson { get; set; }

        [ForeignKey("Thing")]
        public int IdThing { get; set; }
    }
}
