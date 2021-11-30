using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineModelClassLibrary.Models {
    public class Pilot {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [Required]
        public Airline Werk { get; set; }

        [ForeignKey("PilotId")] //Naam moet niet bestaan, dat is de naam die je eraan geeft!
        public ICollection<Flight> VluchtenPiloot { get; set; } = new List<Flight>();

        [ForeignKey("CopilotId")]
        public ICollection<Flight> VluchtenCoPiloot { get; set; } = new List<Flight>();


    }
}
