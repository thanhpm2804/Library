using System.Windows;
using System.Windows.Controls;
using Library.bo;
using Library.Models;

namespace Library
{
    /// <summary>
    /// Interaction logic for BorrowRecordsPage.xaml
    /// </summary>
    public partial class BorrowRecordsPage : Page
    {
        User user;
        BookManagement bookManagement;
        BorrowRecordsManagement borrowManagement;
        public BorrowRecordsPage(User user)
        {
            InitializeComponent();
            this.user = user;
            bookManagement = new BookManagement();
            borrowManagement = new BorrowRecordsManagement();
            LoadList();
        }

        private void LoadList()
        {
            lvBook.ItemsSource = getBorrowedList();
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

        private List<BorrowRecord> getBorrowedList()
        {
            List<BorrowRecord> all = borrowManagement.getAll();
            List<BorrowRecord> ret = new List<BorrowRecord>();
            foreach (BorrowRecord record in all)
            {
                if (record.UserId == user.UserId)
                {
                    record.Book = bookManagement.getBookById(record.BookId);
                    ret.Add(record);
                }
            }

            return ret;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book book = getSelectedBook();
                if (book == null)
                {
                    throw new Exception("Return failed!");
                }
                borrowManagement.returnBook(user, book);
                book.Quantity = (byte)(book.Quantity + 1);
                bookManagement.UpdateBook(book);
                LoadList();
                MessageBox.Show($"Return book {book.Title} successfully!", "Return book");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Return book");
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book book = getSelectedBook();
                if (book == null)
                {
                    throw new Exception("Change failed!");
                }
                DateOnly newReturnDate;
                try
                {
                    newReturnDate = DateOnly.FromDateTime(txtDueDate.SelectedDate.Value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Please select a new return date!");
                }
                BorrowRecord record = borrowManagement.getRecordByUserAndBook(user.UserId, book.BookId);
                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                DateOnly returnDate = (DateOnly)record.DueDate;
                if (newReturnDate.CompareTo(today) < 0 && newReturnDate.CompareTo(returnDate) < 0)
                {
                    throw new Exception("New return date invalid!");
                }
                record.DueDate = newReturnDate;
                borrowManagement.updateRecord(record);
                LoadList();
                MessageBox.Show($"Change return date for book {book.Title} successfully!", "Change return date");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Change return date");
            }
        }
    }
}
