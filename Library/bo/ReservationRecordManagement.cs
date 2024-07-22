using Library.Models;

namespace Library.bo
{
    public class ReservationRecordManagement
    {
        public List<ReservationRecord> getAll()
        {
            List<ReservationRecord> list;
            try
            {
                LibraryContext library = new LibraryContext();
                list = library.ReservationRecords.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }
        public List<int> getAllReservedBookId(User user)
        {
            var list = new List<int>();
            foreach (ReservationRecord record in getAll())
            {
                if (record.UserId == user.UserId)
                {
                    list.Add(record.BookId);
                }
            }
            return list;
        }

        public Boolean isBookReserved(Book book, User user)
        {
            var list = getAllReservedBookId(user);
            return list.Contains(book.BookId);
        }

        private ReservationRecord getReservationByUserAndBook(int userId, int bookId)
        {
            foreach (ReservationRecord record in getAll())
            {
                if (record.UserId == userId && record.BookId == bookId)
                {
                    return record;
                }
            }
            return null;
        }

        public void removeReservation(Book book, User user)
        {
            try 
            { 
                ReservationRecord record = getReservationByUserAndBook(user.UserId, book.BookId);
                LibraryContext library = new LibraryContext();
                library.ReservationRecords.Remove(record);
                library.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        public void reserveBook(ReservationRecord record)
        {
            try
            {
                LibraryContext library = new LibraryContext();
                library.ReservationRecords.Add(record);
                library.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Reserve failed!");
            }
        }

        public bool isUserReserving(int userId)
        {
            foreach (ReservationRecord rec in getAll())
            {
                if (rec.UserId == userId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isBookReserved(int bookId)
        {
            foreach (ReservationRecord record in getAll())
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
