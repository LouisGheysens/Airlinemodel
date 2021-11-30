using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineModelClassLibrary.Models {
    public class Airline {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        public ICollection<Pilot> Piloten { get; set; } = new List<Pilot>();

        public ICollection<CabinMember> CabinMembers { get; set; } = new List<CabinMember>();


    }
}
