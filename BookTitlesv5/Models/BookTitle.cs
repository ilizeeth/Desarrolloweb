using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTitles.Models
{
    public class BookTitle
    {
        [Key]
        public int ISBN_Number{get; set;} //ID
        [Required]
        [StringLength(50)]
        [Display(Name="Title")]
        public string Title{get; set;}
        public int PublisherID{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime Published{get; set;}
        public int BookFormatID{get; set;}
        [Required]
        public int Pages{get; set;}
        [Required]
        public float Price{get; set;}
        public string Comments{get; set;}

        //Uno a muchos
        public ICollection<Book_Author> Book_Authors {get; set;}
        public ICollection<BookCategory> BookCategories {get; set;}

        //Muchos a uno
        public Publisher Publisher {get; set;}
        public BookFormat BookFormat {get; set;}
        


    }
}