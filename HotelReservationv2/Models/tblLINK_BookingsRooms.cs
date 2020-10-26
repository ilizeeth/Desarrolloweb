using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationv2.Models
{
    public class tblLINK_BookingsRooms
    {
        public int ingBookingID {get; set;}
        public int ingRoomID {get; set;}
        public int ingGuestID {get; set;}

        public tblBookings tblBooking {get; set;}
        public tblRooms tblRoom{get; set;}
        public tblGuests tblGuest{get; set;}
        

      


    }
}