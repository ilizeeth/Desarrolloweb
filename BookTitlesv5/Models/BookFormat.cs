using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTitles.Models
{
    public enum Format{
        PDF,EBUP, Fisico
    }
    public class BookFormat
    {
        [Key]
        public int BookFormatID{get; set;}
        public Format? FormatDescription{get; set;}

        //Uno a muchos
        public ICollection<BookTitle> BookTitles {get; set;}
    }
}