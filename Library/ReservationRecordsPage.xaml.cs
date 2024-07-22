using System.Windows;
using System.Windows.Controls;
using Library.bo;
using Library.Models;

namespace Library
{
    /// <summary>
    /// Interaction logic for ReservationRecordsPage.xaml
    /// </summary>
    public partial class ReservationRecordsPage : Page
    {
        User user;
        BookManagement bookManagement;
        ReservationRecordManagement reservationManagement;
        BorrowRecordsManagement borrowManagement;
        public ReservationRecordsPage(User user)
        {
            InitializeComponent();
            this.user = user;
            bookManagement = new BookManagement();
            reservationManagement = new ReservationRecordManagement();
            borrowManagement = new BorrowRecordsManagement();
            loadList();
        }

        private void loadList()
        {
            lvBook.ItemsSource = getList();
        }

        private List<ReservationRecord> getList()
        {
            List<ReservationRecord> all = reservationManagement.getAll();
            List<ReservationRecord> ret = new List<ReservationRecord>();

            foreach (ReservationRecord record in all)
            {
                if (record.UserId == user.UserId)
                {
                    record.Book = bookManagement.getBookById(record.BookId);
                    ret.Add(record);
                }
            }

            return ret;
        }
        private Book getSelectedBook()
        {
            Book book = null;
            try
            {
                String bid = txtBookID.Text;
                if (bid == null || bid == "")
                {
                    throw new Exception("Please select a book!");
                }
                int bookId = int.Parse(bid);
                return bookManagement.getBookById(bookId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book book = getSelectedBook();
                if (book == null)
                {
                    throw new Exception("Borrowing book failed!");
                }
                DateTime? returnDate = txtDueDate.SelectedDate.Value;
                if (returnDate == null)
                {
                    throw new Exception("Please select the return date!");
                }
                DateOnly dueDate = DateOnly.FromDateTime(txtDueDate.SelectedDate.Value);
                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                if (dueDate.CompareTo(today) < 0)
                {
                    throw new Exception("Please select return date not before today!");
                }
                if (book.Quantity == 0)
                {
                    throw new Exception("This book is not available!");
                }
                else
                {
                    reservationManagement.removeReservation(book, user);
                    BorrowRecord record = new BorrowRecord
                    {
                        BookId = book.BookId,
                        UserId = user.UserId,
                        DueDate = dueDate,
                        BorrowDate = today,
                    };
                    book.Quantity = (byte)(book.Quantity - 1);
                    bookManagement.UpdateBook(book);
                    borrowManagement.borrowBook(record);
                    loadList();
                    MessageBox.Show($"Borrowed book {book.Title} successfully!", "Borrow book");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Borrow book");
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book book = getSelectedBook();
                if (book == null)
                {
                    throw new Exception("Remove book failed!");
                }
                reservationManagement.removeReservation(book, user);
                loadList();
                MessageBox.Show($"Remove book {book.Title} successfully!", "Remove book");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Remove book");
            }
        }
    }
}
