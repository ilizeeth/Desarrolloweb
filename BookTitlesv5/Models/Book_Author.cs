using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTitles.Models
{
    public class Book_Author
    {
     
        public int ISBN_Number{get; set;} //ID
        public int AuthorID{get; set;} 
        
        //Muchos a uno
        public Author Author {get; set;}
        public BookTitle BookTitle{get; set;}
    }
}