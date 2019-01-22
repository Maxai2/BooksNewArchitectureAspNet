using BooksAppCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksAppCore.Repository
{
    public interface IBookRepository
    {
        List<Book> Select();
        Book Select(int id);
        int Insert(Book book);
        int Update(Book book);
        int Delete(Book book);
        int Delete(int id);
    }
}
