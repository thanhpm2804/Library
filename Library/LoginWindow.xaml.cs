using System.Windows;
using Library.bo;
using Library.Models;

namespace Library
{
    public partial class LoginWindow : Window
    {
        UserManagement userManagement;
        public LoginWindow()
        {
            InitializeComponent();
            userManagement = new UserManagement();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String email = txtEmail.Text;
            try
            {
                User admin = LibraryContext.adminAccount();
                if (email == admin.Email)
                {
                    String password = txtPass.Password;
                    if (password == admin.Password)
                    {
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Password is incorrect");
                    }
                }
                else
                {
                    User user = userManagement.getUserByEmail(email);
                    if (user == null)
                    {
                        throw new Exception("Email does not exist!");
                    }
                    else
                    {
                        String password = txtPass.Password;
                        if (password != user.Password)
                        {
                            throw new Exception("Password is incorrect");
                        }
                        else
                        {
                            UserWindow userWindow = new UserWindow(user);
                            userWindow.Show();
                            this.Close();
                        }
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
