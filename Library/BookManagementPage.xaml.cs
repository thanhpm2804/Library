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
    /// Interaction logic for BookManagementPage.xaml
    /// </summary>
    public partial class BookManagementPage : Page
    {
        BookManagement bookManagement;
        BorrowRecordsManagement borrowManagement;
        ReservationRecordManagement reservationManagement;
        CommentsManagement commentsManagement;
        public BookManagementPage()
        {
            InitializeComponent();
            bookManagement = new BookManagement();
            borrowManagement = new BorrowRecordsManagement();
            reservationManagement = new ReservationRecordManagement();
            commentsManagement = new CommentsManagement();
            LoadBookList();
        }

        private Book getBookInfo()
        {
            Book book = new Book();
            try
            {
                String title = txtTitle.Text;
                if (title == null || title == "") 
                {
                    throw new Exception("Title is empty!");

                }
                else
                {
                    book.Title = title;
                }

                String author = txtAuthor.Text;
                if (author == null || author == "")
                {
                    throw new Exception("Author is empty!");

                }
                else
                {
                    book.Author = author;
                }

                byte quantity = 0;
                try
                {
                    quantity = byte.Parse(txtQuantity.Text);
                    if (quantity < 0)
                    {
                        throw new Exception();
                    }
                    book.Quantity = quantity;
                }
                catch (Exception ex)
                {
                    throw new Exception("Please enter an non-negative integer for quantity!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return null;
            }
            return book;
        }

        private void LoadBookList()
        {
            lvBook.ItemsSource = bookManagement.getAllBooks();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book b = getBookInfo();
                bookManagement.AddNewBook(b);
                LoadBookList();
                MessageBox.Show($"Insert book {b.Title} successfully!", "Insert book");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert book");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book b = getBookInfo();
                b.BookId = byte.Parse(txtBookID.Text);
                bookManagement.UpdateBook(b);
                LoadBookList();
                MessageBox.Show($"Update book with id {b.BookId} successfully!", "Update book");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update book");
            }
        }

        private bool isBookActive(Book book)
        {
            return borrowManagement.isBookBorrowed(book.BookId) || reservationManagement.isBookReserved(book.BookId);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book b = getBookInfo();
                b.BookId = byte.Parse(txtBookID.Text);
                if (isBookActive(b))
                {
                    throw new Exception("Book is active! Can't delete.");
                }
                commentsManagement.removeAllCommentsOfBook(b.BookId);
                bookManagement.DeleteBook(b);
                LoadBookList();
                MessageBox.Show($"Delete book with id {b.BookId} successfully!", "Delete book");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete book");
            }
        }
    }
}
