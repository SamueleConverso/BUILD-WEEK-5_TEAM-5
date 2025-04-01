using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildWeek5_Team5.Models {
    [Table("Armadietti")]
    public class Armadietto {
        [Key]
        public int ArmadiettoId {
            get; set;
        }

        public ICollection<Cassetto> Cassetti
        {
            get; set;
        }
    }
}
