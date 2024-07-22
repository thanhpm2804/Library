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

namespace Library
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            BookManagementPage bookManagementPage = new BookManagementPage();
            frMain.Content = bookManagementPage;
        }

        private void btnManageBooks_Click(object sender, RoutedEventArgs e)
        {
            BookManagementPage bookManagementPage = new BookManagementPage();
            frMain.Content = bookManagementPage;
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

        private void btnManageUsers_Click(object sender, RoutedEventArgs e)
        {
            ManageUsersPage page = new ManageUsersPage();
            frMain.Content = page;
        }

        private void frMain_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void frMain_Navigated_1(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
