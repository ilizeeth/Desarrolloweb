using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTitles.Models
{
    public class Publisher
    {
        public enum editorial{
        RocaEditorial, Salamandra, Alfaguara, Oceano
    }
        [Key]
        public int PublisherID {get; set;}
        public editorial? PublisherName{get; set;}

        //Uno a muchos
        public ICollection<BookTitle> BookTitles {get; set;}
    }
}