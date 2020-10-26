using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationv2.Models
{
    public class tblLINK_RoomsFacilities
    {
        public int ingRoomID{get; set;}
        public int ingFacilityID{get; set;}
        [Required]
        [StringLength(50)]
        [Column("Detalles de la habitación")]
        [Display(Name="Detalles de la habitación")]
        public string strFacilityDetails{get; set;}

        public tblFacilitiesList tblFacilitiesLists{get; set;}
        public tblRooms tblRoom{get; set;}
    }
}