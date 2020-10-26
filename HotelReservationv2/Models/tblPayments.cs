using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationv2.Models
{
    public class tblPayments
    {
        [Key]
        public int ingPaymentID{get; set;}
        public int ingBookingID{get; set;}
        public int ingCustomerID{get; set;}
        public int ingPaymentMethodID{get; set;}
        [Required]
        [Column("Monto de pago")]
        [Display(Name="Monto de pago")]
        public decimal curPaymentAmount{get; set;}
        [Column("Comentarios")]
        [Display(Name="Comentarios")]
        public string memPaymentComments{get; set;}

        public tblCustomers tblCustomer{get; set;}
        public tblPaymentMethods tblPaymentMethod{get; set;}
        public tblBookings tblBooking{get; set;}
    }
}