using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTitles.Models
{
    public enum Categories{
        Romance, Drama, Terror, Fantasia,Otra
    }
    public class Category
    {
        [Key]
        public int CategoryID{get; set;}
        public Categories? CategoryDescription{get; set;}

        //Uno a muchos
        public ICollection<BookCategory> BookCategories {get; set;}
    }
}