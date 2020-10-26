using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationv2.Models
{
    public class tblRooms
    {
        [Key]
        public int ingRoomID{get; set;}
        public int ingRoomTypeID{get; set;}
        public int ingRoomBandID{get; set;}
        public int ingRoomPriceID{get; set;}
        [Required]
        [StringLength(10)]
        [Column("Piso")]
        [Display(Name="Piso")]
        public string strFloor{get; set;}
        [StringLength(100)]
        [Column("Notas Adicionales")]
        [Display(Name="Notas adicionales")]
        public string memAdditionNotes{get; set;}
        
         
        public ICollection<tblLINK_BookingsRooms> tblLINK_BookingsRoom{get; set;}
        public ICollection<tblLINK_RoomsFacilities> tblLINK_RoomsFacilitie{get; set;}
        
        public tblRoomTypes tblRoomType{get; set;}
        public tblRoomBands tblRoomBand {get; set;}
        public tblRoomPrices tblRoomPrice{get; set;}
    }
}