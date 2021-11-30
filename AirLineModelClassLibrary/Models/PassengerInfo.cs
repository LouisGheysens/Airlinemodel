using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirLineModelClassLibrary.Models {
    public class PassengerInfo {

        //INT IS ALTIJD REQUIRED, dus dan moet je dat er niet boven doen

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Flight Flight { get; set; }

        
        public int EconomySeatsOccupied { get; set; }

        public int BusinessSeatsOccupied { get; set; }
    }
}