using BooksAppCore.Models;
using BooksAppCore.Repository;
using BooksInfrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksInfrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private CustomDbContext customDbContext;

        public BookRepository(CustomDbContext customDbContext)
        {
            this.customDbContext = customDbContext;
        }

        public int Delete(Book book)
        {
            customDbContext.Books.Remove(book);
            return customDbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var book = customDbContext.Books.Find();
            customDbContext.Books.Remove(book);
            return customDbContext.SaveChanges();
        }

        public int Insert(Book book)
        {
            customDbContext.Books.Add(book);
            return customDbContext.SaveChanges();
        }

        public List<Book> Select()
        {
            return customDbContext.Books.ToList();
        }

        public Book Select(int id)
        {
            return customDbContext.Books.Find(id);
        }

        public int Update(Book book)
        {
            var editBook = customDbContext.Books.Find(book.Id);
            editBook.Title = book.Title;
            editBook.Year = book.Year;
            return customDbContext.SaveChanges();
        }
    }
}
