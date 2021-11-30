using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineModelClassLibrary.Models {
    public class Flight {

        [Key]
        [MaxLength(20)]
        public string FlightNumber { get; set; }

        [MaxLength(200)]
        public string Arrival { get; set; }

        [MaxLength(200)]
        public string Departure { get; set; }

        [Required]
        public Pilot Piloot { get; set; }

        
        public Pilot CoPiloot { get; set; }

        [Required]
        public Airplane Airplane { get; set; }

        [Required]
        public ICollection<CabinMember> CabinMembers { get; set; } = new List<CabinMember>();

        public int? PassengerInfoId { get; set; }

        public PassengerInfo PassengerInfo { get; set; }
    }
}
