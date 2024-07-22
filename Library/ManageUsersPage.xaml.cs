using System.Windows;
using System.Windows.Controls;
using Library.bo;
using Library.Models;

namespace Library
{
    /// <summary>
    /// Interaction logic for ManageUsersPage.xaml
    /// </summary>
    public partial class ManageUsersPage : Page
    {
        UserManagement userManagement;
        BorrowRecordsManagement borrowManagement;
        ReservationRecordManagement reservationManagement;
        CommentsManagement commentsManagement;
        public ManageUsersPage()
        {
            InitializeComponent();
            userManagement = new UserManagement();
            borrowManagement = new BorrowRecordsManagement();
            reservationManagement = new ReservationRecordManagement();
            commentsManagement = new CommentsManagement();
            loadList();
        }

        private void loadList()
        {
            List<User> all = userManagement.getAll();
            List<User> ret = new List<User>();
            foreach (User user in all) 
            { 
                if (!(bool)user.IsAdmin)
                {
                    ret.Add(user);
                }
            }
            lvUser.ItemsSource = ret;
        }

        private User getUserInfo()
        {
            try
            {
                User user = new User();
                string fullName = txtFullName.Text;
                if (fullName == null || fullName == "")
                {
                    throw new Exception("Name is empty!");
                }
                user.FullName = fullName;
                string email = txtEmail.Text;
                if (email == null || email == "")
                {
                    throw new Exception("Email is empty!");
                }
                user.Email = email;
                string password = txtPassword.Text;
                if (password == null || password == "")
                {
                    throw new Exception("Password is empty!");
                }
                user.Password = password;
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = getUserInfo();
                user.IsAdmin = false;
                userManagement.insertUser(user);
                loadList();
                MessageBox.Show("Insert user successfully!", "Insert user");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert user");
            }
        }

        private bool isUserActive(User user)
        {
            return borrowManagement.isUserBorrowing(user.UserId) || reservationManagement.isUserReserving(user.UserId);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int userId;
                try
                {
                    userId = int.Parse(txtUserID.Text);
                }
                catch
                {
                    throw new Exception("Please select an user!");
                }
                User user = getUserInfo();
                user.IsAdmin = false;
                user.UserId = userId;
                userManagement.updateUser(user);
                loadList();
                MessageBox.Show("Update user successfully!", "Update user");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update user");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int userId;
                try
                {
                    userId = int.Parse(txtUserID.Text);
                }
                catch
                {
                    throw new Exception("Please select an user!");
                }
                User user = userManagement.getUserById(userId);
                if (user == null)
                {
                    throw new Exception("Delete failed!");
                }
                if (isUserActive(user))
                {
                    throw new Exception("Can't delete. User is still active!");
                }
                commentsManagement.removeAllCommentOfUser(user.UserId);
                userManagement.removeUser(user);
                loadList();
                MessageBox.Show("Delete user successfully!", "Delete user");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete user");
            }
        }
    }
}
