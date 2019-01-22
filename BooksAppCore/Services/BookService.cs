using System.Collections.Generic;
using BooksAppCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BooksAppCore.Repository;

namespace BooksAppCore.Services
{
    public class BookService : IBookService
    {
        //private DbContext dbContext;
        private IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            //this.dbContext = dbContext;
            this.bookRepository = bookRepository;

            if (bookRepository.Select().Count == 0)
            {
                var books = new List<Book>()
                {
                    new Book() { Title = "Book 1", Year = 1990,
                        Authors = new List<Author>() { new Author() { FirstName = "Author", LastName = "One" }, new Author() { FirstName = "Author", LastName = "Two" } } },
                    new Book() { Title = "Book 2", Year = 1991,
                        Authors = new List<Author>() { new Author() { FirstName = "Author", LastName = "Three" } } },
                    new Book() { Title = "Book 3", Year = 1992,
                        Authors = new List<Author>() { new Author() { FirstName = "Author", LastName = "Four" }, new Author() { FirstName = "Author", LastName = "Five" } } },
                    new Book() { Title = "Book 4", Year = 1993 },
                    new Book() { Title = "Book 5", Year = 1994 }
                };

                foreach (var book in books)
                {
                    bookRepository.Insert(book);
                }
            }
        }

        public List<Book> Get()
        {
            return bookRepository.Select();
        }

        public Book Get(int id)
        {
            return bookRepository.Select(id);
        }

        public Book Insert(Book book)
        {
            bookRepository.Insert(book);
            return book;
        }

        public Book Update(Book book)
        {
            bookRepository.Update(book);
            return book;
        }

        public void Delete(int id)
        {
            Book find = bookRepository.Select(id);
            bookRepository.Delete(find);
        }

        public void Delete(Book book)
        {
            bookRepository.Delete(book);
        }

        public List<Author> GetAuthors(int id)
        {
            return bookRepository.Select(id)?.Authors;
        }

    }
}