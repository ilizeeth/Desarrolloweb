using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationv2.Models
{
    public class tblCustomers
    {   [Key]
        public int IngCutomerID{get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name="Titular de la reservación")]
        public string txtCustomerTitle{get; set;}
        [Required]
        [StringLength(50)]
        [Column("Nombres")]
        [Display(Name="Nombre(s)")]
        public string txtCustomerForenames{get; set;}
         [Required]
        [StringLength(50)]
        [Column("Apellidos")]
        [Display(Name="Apellidos")]
        public string txtCustomerSurnames{get; set;}
         [Required]
        [StringLength(50)]
        [Column("Fecha de nacimiento")]
        [Display(Name="Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime CustomerDOB{get; set;}
        [Required]
        [StringLength(50)]
        [Column("Calle")]
        [Display(Name="Calle")]
        public string txtCustomerAddressStreet{get; set;}
        [Required]
        [StringLength(50)]
        [Column("Ciudad")]
        [Display(Name="Ciudad")]
        public string txtCustomerAddressTown{get; set;}
        [Required]
        [StringLength(50)]
        [Column("País")]
        [Display(Name="País")]
        public string txtCustomerAddressCountry{get; set;}
        [Required]
        [StringLength(50)]
        [Column("Código postal")]
        [Display(Name="Código postal")]
        public string txtCustomerAddressPostalCode{get; set;}
       
        [StringLength(50)]
        [Column("Telefono de Casa")]
        [Display(Name="Telefono de casa")]
        public string txtCustomerHomePhone{get; set;}
        [Required]
        [StringLength(50)]
        [Column("Numero de celular")]
        [Display(Name="Numero de Celular")]
        public string txtCustomerMobilePhone{get; set;}
        [Required]
        [StringLength(50)]
        [Column("Email")]
        [Display(Name="Email")]
        public string hypCustomerEmail{get; set;}


        public ICollection<tblBookings> tblBooking{get; set;}
        public ICollection<tblPayments> tblPayment{get; set;}


        
    }
}