using System.Windows;
using Library.Models;

namespace Library
{
    public partial class LoginWindow : Window
    {
        LibraryManagement libraryManagement;
        public LoginWindow()
        {
            InitializeComponent();
            libraryManagement = new LibraryManagement();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String email = txtEmail.Text;
            try
            {
                User user = libraryManagement.getUserByEmail(email);
                if (user == null)
                {
                    throw new Exception("Email does not exist!");
                }
                else
                {
                    String password = txtPass.ToString();
                    if (password != user.Password)
                    {
                        throw new Exception("Password is incorrect");
                    }
                    else
                    {
                        this.Hide();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
