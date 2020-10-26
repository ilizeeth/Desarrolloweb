using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationv2.Models
{
    public class tblRoomTypes
    {
        [Key]
        public int ingRoomTypeID{get; set;}
        [Required]
        [StringLength(50)]
        [Column("Tipo de habitación")]
        [Display(Name="Tipo de habitación")]
        public string strRoomType{get; set;}

        public ICollection<tblRooms> tblRoom{get; set;}
        
    }
}