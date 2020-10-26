using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationv2.Models
{
    public class tblPaymentMethods
    {
        [Key]
        public int ingPaymentMethodID {get; set;}
        [Column("Metodos de pago")]
        [Display(Name="Metodos de pago")]
        public string txtPaymentMethod {get; set;}

        public ICollection<tblPayments> tblPayment{get; set;}

    }
}