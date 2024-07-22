using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.bo
{
    public class BookManagement
    {
        public Book getBookById(int bookId)
        {
            Book book = null;
            try
            {
                LibraryContext library = new LibraryContext();
                book = library.Books.SingleOrDefault(book => book.BookId == bookId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return book;
        }

        public List<Book> getAllBooks()
        {
            List<Book> books;
            try
            {
                LibraryContext library = new LibraryContext();
                books = library.Books.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return books;
        }

        public void AddNewBook(Book book)
        {
            if (book == null)
            {
                throw new Exception("Insert failed!");
            }
            else
            {
                LibraryContext libraryContext = new LibraryContext();
                libraryContext.Books.Add(book);
                libraryContext.SaveChanges();
            }
        }

        public void UpdateBook(Book book)
        {
            if (book == null)
            {
                throw new Exception("Update failed!");
            }
            else
            {
                try
                {
                    if (getBookById(book.BookId) == null)
                    {
                        throw new Exception("BookID not found!");
                    }
                    else
                    {
                        LibraryContext libraryContext = new LibraryContext();
                        libraryContext.Entry<Book>(book).State = EntityState.Modified;
                        libraryContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void DeleteBook(Book book)
        {
            if (book == null)
            {
                throw new Exception("Delete failed!");
            }
            else
            {
                try
                {
                    if (getBookById(book.BookId) == null)
                    {
                        throw new Exception("BookID not found!");
                    }
                    else
                    {
                        LibraryContext libraryContext = new LibraryContext();
                        libraryContext.Books.Remove(book);
                        libraryContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
