using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineModelClassLibrary.Models {
    public class Airplane {
        //ID WORDT AUTOMATISCH AANGEMAAKT DUS DIE DATABASEGENERATED MOET ER NIET METEEN BIJ!
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        [Required]
        public ICollection<Flight> Flights { get; set; } = new List<Flight>();
    }
}
