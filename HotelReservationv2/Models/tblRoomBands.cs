using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationv2.Models
{
    public class tblRoomBands
    {
        [Key]
        public int ingRoomBandID{get; set;}
        public string strBandDesc{get; set;}

         public ICollection<tblRooms> tblRoom{get; set;}
    }
}