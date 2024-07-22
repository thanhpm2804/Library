using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library.bo;
using Library.Models;

namespace Library
{
    /// <summary>
    /// Interaction logic for BorrowPage.xaml
    /// </summary>
    public partial class BorrowPage : Page
    {
        User user;
        BookManagement bookManagement;
        ReservationRecordManagement reservationManagement;
        BorrowRecordsManagement borrowManagement;
        public BorrowPage(User user)
        {
            InitializeComponent();

            bookManagement = new BookManagement();
            reservationManagement = new ReservationRecordManagement();
            borrowManagement = new BorrowRecordsManagement();

            this.user = user;
            LoadBookList();
        }

        private void LoadBookList()
        {
            lvBook.ItemsSource = getAllUnborrowedBook();
        }

        private List<Book> getAllUnborrowedBook()
        {
            List<Book> books = bookManagement.getAllBooks();
            List<int> borrowedIds = borrowManagement.getAllBorrowwedBookId(user);
            List<Book> ret = new List<Book>();

            foreach (Book b in books)
            {
                if (!borrowedIds.Contains(b.BookId))
                {
                    ret.Add(b);
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
                if (borrowManagement.isBookBorrowedByUser(user, book))
                {
                    throw new Exception("You have already borrow this book!");
                }
                else
                {
                    if (reservationManagement.isBookReserved(book, user))
                    {
                        reservationManagement.removeReservation(book, user);
                    }
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
                    LoadBookList();
                    MessageBox.Show($"Borrowed book {book.Title} successfully!", "Borrow book");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Borrow book");
            }
        }

        private void btnReserve_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book book = getSelectedBook();
                if (book == null)
                {
                    throw new Exception("Reserving book failed!");
                }
                if (borrowManagement.isBookBorrowedByUser(user, book))
                {
                    throw new Exception("Book is already borrowed!");
                }
                if (reservationManagement.isBookReserved(book, user))
                {
                    throw new Exception("Book is already reserved!");
                }
                ReservationRecord record = new ReservationRecord
                {
                    BookId = book.BookId,
                    UserId = user.UserId,
                    ReservationDate = DateOnly.FromDateTime(DateTime.Now),
                };
                reservationManagement.reserveBook(record);
                MessageBox.Show($"Reserve book {book.Title} successfully!", "Reserve book");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reserve book");
            }
        }
    }
}
