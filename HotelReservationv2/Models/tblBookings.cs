using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationv2.Models
{
    public class tblBookings
    {
        [Key]
        public int ingBookingID{get; set;}
        public int ingCustomerID{get; set;}
        [Required]
        [Column("Fecha de reserva")]
        [Display(Name="Fecha de reserva")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime dteDateBookingMade{get; set;}
        [Required]
        [Column("Entrega de habitación")]
        [Display(Name="Entrega de habitación")]
        public string tmeTimeBookingMade{get; set;}
         [Required]
        [Column("Fecha de Entrada")]
        [Display(Name="Fecha de Entrada")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime dteBookedStartDate{get; set;}
         [Required]
        [Column("Fecha de salida")]
        [Display(Name="Fecha de salida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime dteBookedEndDate{get; set;}
         [Required]
        [Column("Fecha de vencimiento de pago")]
        [Display(Name="Fecha de vencimiento de pago")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime dteTotalPaymentDueDate{get; set;}
        [Required]
        [Column("Total de la reservación")]
        [Display(Name="Total de la reservación")]
        public decimal dteTotalPaymentDueAmount{get; set;}
        [Column("Comentarios")]
        [Display(Name="Comentarios")]
        public string memBookingComments{get; set;}

        [Column("Pago realizado")]
        [Display(Name="Fecha del pago realizado")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime dteTotalPaymentMadeOn{get; set;}



        public ICollection<tblLINK_BookingsRooms> tblLINK_BookingsRoom{get; set;}
        public ICollection<tblPayments> tblPayment{get; set;}
        public tblCustomers tblCustomer{get; set;}
    }
}