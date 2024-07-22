using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.bo
{
    public class BorrowRecordsManagement
    {
        public List<BorrowRecord> getAll()
        {
            List<BorrowRecord> list;
            try
            {
                LibraryContext library = new LibraryContext();
                list = library.BorrowRecords.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }
        public List<int> getAllBorrowwedBookId(User user)
        {
            var list = new List<int>();
            foreach (BorrowRecord record in getAll())
            {
                if (record.UserId == user.UserId)
                {
                    list.Add(record.BookId);
                }
            }
            return list;
        }

        public Boolean isBookBorrowedByUser(User user, Book book)
        {
            var list = getAllBorrowwedBookId(user);
            return list.Contains(book.BookId);
        }

        public void borrowBook(BorrowRecord record)
        {
            try
            {
                LibraryContext library = new LibraryContext();
                library.BorrowRecords.Add(record);
                library.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Borrowing failed!");
            }
        }

        public BorrowRecord getRecordByUserAndBook(int userId, int bookId)
        {
            foreach (BorrowRecord record in getAll())
            {
                if (record.UserId ==  userId && record.BookId == bookId)
                {
                    return record;
                }
            }
            return null;
        }

        public void returnBook(User user, Book book)
        {
            try
            {
                BorrowRecord record = getRecordByUserAndBook(user.UserId, book.BookId);
                LibraryContext library = new LibraryContext();
                library.BorrowRecords.Remove(record);
                library.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void updateRecord(BorrowRecord record)
        {
            try
            {
                LibraryContext libraryContext = new LibraryContext();
                libraryContext.Entry<BorrowRecord>(record).State = EntityState.Modified;
                libraryContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Extending failed!");
            }
        }

        public bool isUserBorrowing(int userId)
        {
            foreach (BorrowRecord record in getAll())
            {
                if (record.UserId == userId) return true;
            }
            return false;
        }

        public bool isBookBorrowed(int bookId)
        {
            foreach (BorrowRecord record in getAll())
            {
                if (record.BookId == bookId) 
                { 
                    return true; 
                }
            }
            return false;
        }
    }
}
