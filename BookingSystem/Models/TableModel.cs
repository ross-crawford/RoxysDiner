using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public class TableModel
    {
        [Key, ForeignKey("Booking")]
        public int TableId { get; set; }

        [Required]
        [Display(Name = "Table Number")]
        public int TableNumber { get; set; }

        [Required]
        [Display(Name = "Max People")]
        public int TableCapacity { get; set; }

        public virtual ICollection<BookingModel> Booking { get; set; }
    }
}