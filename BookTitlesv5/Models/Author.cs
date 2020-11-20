using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTitles.Models
{
    public class Author
    {
        [Key]
        public int AuthorID{get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name="First Name")]
        public string AuthorFirstName {get; set;}
        [Required]
        [StringLength(50)]
        [Column("FirstName")]
        [Display(Name="Last Name")]
        public string AuthorLastName{get; set;}
        [NotMapped]
        public string FullName => AuthorFirstName + ", " + AuthorLastName;
    

        //Uno a muchos
        public ICollection<Book_Author> Book_Authors {get; set;}
    }
}