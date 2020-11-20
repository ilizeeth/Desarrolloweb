using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookTitles.Models;

namespace BookTitles.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BookContext context)
        {
            context.Database.EnsureCreated();

           
            if (context.Authors.Any())
            {
                return;   // DB has been seeded
            }


             var authors = new Author[]
            {
                new Author { AuthorFirstName="Kira", AuthorLastName="Cass" },
                new Author{AuthorFirstName="R.J", AuthorLastName="Palacio"}
            };

            foreach (Author s in authors)
            {
                context.Authors.Add(s);
            }
            context.SaveChanges();

            var publisher = new Publisher[]
            {
                new Publisher {PublisherName=Publisher.editorial.RocaEditorial},
                new Publisher {PublisherName=Publisher.editorial.Oceano}

            };
            foreach (Publisher s in publisher)
            {
                context.publishers.Add(s);
            }
            context.SaveChanges();

            var format = new BookFormat[]
            {
                new BookFormat{FormatDescription=Format.EBUP},
                new BookFormat{FormatDescription=Format.PDF}
            };

            foreach (BookFormat s in format)
            {
                context.BookFormats.Add(s);
            }
            context.SaveChanges();

            var category = new Category[]
            {
                new Category{CategoryDescription=Categories.Drama},
                new Category{CategoryDescription=Categories.Romance}
            };
            foreach (Category s in category)
            {
                context.Categories.Add(s);
            }
            context.SaveChanges();

            var BookTitles = new BookTitle[]
            {
                new BookTitle{ISBN_Number=1234,Title="La seleccion", PublisherID=publisher.Single(i=>i.PublisherName==Publisher.editorial.RocaEditorial).PublisherID,Published=DateTime.Parse("2007-09-01"),
                BookFormatID=format.Single(i=>i.FormatDescription==Format.EBUP).BookFormatID,
                Pages=234,Price=459,Comments=""},

                new BookTitle{ISBN_Number=4321,Title="La leccion de august", PublisherID=publisher.Single(i=>i.PublisherName==Publisher.editorial.Oceano).PublisherID,Published=DateTime.Parse("2006-11-11"),
                BookFormatID=format.Single(i=>i.FormatDescription==Format.PDF).BookFormatID,
                Pages=347,Price=255,Comments=""}
            };

           /* foreach (BookTitle s in BookTitles)
            {
                context.BookTitles.Add(s);
            }
            context.SaveChanges();*/

            foreach (BookTitle e in BookTitles)
            {
                var bookindatabase = context.BookTitles.Where(
                    s =>
                            s.Publisher.PublisherID == e.PublisherID &&
                            s.BookFormat.BookFormatID == e.BookFormatID).SingleOrDefault();
                if (bookindatabase == null)
                {
                    context.BookTitles.Add(e);
                }
            }
            context.SaveChanges();

            var AuthorBookTitle = new Book_Author[]{

                new Book_Author{AuthorID=authors.Single(i=> i.AuthorLastName=="Cass").AuthorID,
                                ISBN_Number=BookTitles.Single(i=>i.Title=="La seleccion").ISBN_Number},

                 new Book_Author{AuthorID=authors.Single(i=> i.AuthorLastName=="Palacio").AuthorID,
                                ISBN_Number=BookTitles.Single(i=>i.Title=="La leccion de august").ISBN_Number}
            };

            foreach (Book_Author s in AuthorBookTitle)
            {
                context.Book_Authors.Add(s);
            }
            context.SaveChanges();

            

            var BooksCategory = new BookCategory[]
            {
                new BookCategory{CategoryID=category.Single(i=>i.CategoryDescription==Categories.Drama).CategoryID, 
                ISBN_Number=BookTitles.Single(i=>i.Title=="La seleccion").ISBN_Number},
                
                new BookCategory{CategoryID=category.Single(i=>i.CategoryDescription==Categories.Romance).CategoryID,
                ISBN_Number=BookTitles.Single(i=>i.Title=="La leccion de august").ISBN_Number}

            };

            foreach (BookCategory s in BooksCategory)
            {
                context.BookCategories.Add(s);
            }
            context.SaveChanges();

            


        }
    }
}