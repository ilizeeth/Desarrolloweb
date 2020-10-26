using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationv2.Models
{
    public class tblFacilitiesList
    {
        [Key]
        public int ingFacilityID{get; set;}
        [Required]
        [StringLength(50)]
        [Column("Descripción de la habitación")]
        [Display(Name="Descripción de la habitación")]
        public string FacilityDesc{get; set;}

         public ICollection<tblLINK_RoomsFacilities> tblLINK_RoomsFacilitie{get; set;}
    }
}