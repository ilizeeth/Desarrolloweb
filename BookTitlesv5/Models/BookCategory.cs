using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTitles.Models
{
    public class BookCategory
    {
        public int ISBN_Number{get; set;}
        public int CategoryID{get; set;}

        //Muchos a uno
        public BookTitle BookTitle {get; set;}
        public Category Category {get; set;}
    }
}
