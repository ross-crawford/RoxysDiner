using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public class BookingModel
    {
        [Key]
        public int BookingId { get; set; }
        
        [Required]
        [Display(Name = "Date / Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public DateTime BookingDateTime { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Party Size")]
        public int PartySize { get; set; }

        [Required]
        [Display(Name = "Table")]
        public int TableAllocation { get; set; }

        [Display(Name = "Comments")]
        public string BookingComments { get; set; }
        
        public virtual CustomerModel Customer { get; set; }
        public virtual TableModel Table { get; set; }

    }
}