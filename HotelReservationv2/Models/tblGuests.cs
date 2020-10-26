using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationv2.Models
{
    public class tblGuests
    {
        [Key]
        public int ingGuestID{get; set;}
         [Required]
        [StringLength(50)]
        [Display(Name="Húesped titular")]
        public string txtGuestTitle{get; set;}
        [Required]
        [StringLength(50)]
        [Column("Nombres")]
        [Display(Name="Nombre(s)")]
        public string txtGuestForenames{get; set;}
        [Required]
        [StringLength(50)]
        [Column("Apellidos")]
        [Display(Name="Apellidos")]
        public string txtGuestSurnames{get; set;}
         [Required]
        [StringLength(50)]
        [Column("Fecha de nacimiento")]
        [Display(Name="Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime dteGuestDOB{get; set;}
         [Required]
        [StringLength(50)]
        [Column("Calle")]
        [Display(Name="Calle")]
        public string txtGuestAddressStreet{get; set;}
         [Required]
        [StringLength(50)]
        [Column("Ciudad")]
        [Display(Name="Ciudad")]
        public string txtGuestAddressTown{get; set;}
         [Required]
        [StringLength(50)]
        [Column("País")]
        [Display(Name="País")]
        public string txtGuestAddressCountry{get; set;}
         [Required]
        [StringLength(50)]
        [Column("Código postal")]
        [Display(Name="Código postal")]
        public string txtGuestAddressPostalCode{get; set;}
         [Required]
        [StringLength(50)]
        [Column("Telefono de contacto")]
        [Display(Name="Telefono de contacto")]
        public string txtGuestContactPhone{get; set;}

        
        public ICollection<tblLINK_BookingsRooms> tblLINK_BookingsRoom{get; set;}

    }
}