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
using System.Windows.Shapes;
using Library.bo;
using Library.Models;

namespace Library
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        User user;
        public UserWindow()
        {
            InitializeComponent();
        }

        public UserWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            loadBorrowPage();
        }

        private void loadBorrowPage()
        {
            BorrowPage borrowPage = new BorrowPage(user);
            frMain.Content = borrowPage;
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
            loadBorrowPage();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBorrowRecords_Click(object sender, RoutedEventArgs e)
        {
            BorrowRecordsPage page = new BorrowRecordsPage(user);
            frMain.Content = page;
        }

        private void btnReservationRecords_Click(object sender, RoutedEventArgs e)
        {
            ReservationRecordsPage page = new ReservationRecordsPage(user);
            frMain.Content = page;
        }

        private void btnComments_Click(object sender, RoutedEventArgs e)
        {
            CommentPage page = new CommentPage(user);
            frMain.Content = page;
        }
    }
}
