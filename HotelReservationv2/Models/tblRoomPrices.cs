using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationv2.Models
{
    public class tblRoomPrices
    {
        [Key]
        public int ingRoomPriceID{get; set;}
        [Required]
        [StringLength(50)]
        [Column("Precio de la habitación")]
        [Display(Name="Precio de la habitación")]
        public decimal curRoomPrice{get; set;}

        public ICollection<tblRooms> tblRoom{get; set;}
    }
}