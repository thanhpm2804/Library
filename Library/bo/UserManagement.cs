using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.bo
{
    public class UserManagement
    {
        public User getUserByEmail(string email)
        {
            User user = null;
            try
            {
                LibraryContext library = new LibraryContext();
                user = library.Users.SingleOrDefault(user => user.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public List<User> getAll()
        {
            LibraryContext library = new LibraryContext();
            return library.Users.ToList();
        }

        public void insertUser(User user)
        {
            try
            {
                LibraryContext library = new LibraryContext();
                library.Users.Add(user);
                library.SaveChanges();
            }
            catch
            {
                throw new Exception("Insert user failed!");
            }
        }

        public void updateUser(User user)
        {
            try
            {
                LibraryContext libraryContext = new LibraryContext();
                libraryContext.Entry<User>(user).State = EntityState.Modified;
                libraryContext.SaveChanges();
            }
            catch
            {
                throw new Exception("Update failed!");
            }
        }

        public User getUserById(int id)
        {
            foreach (User user in getAll())
            {
                if (user.UserId == id)
                {
                    return user;
                }
            }
            return null;
        }

        public void removeUser(User user)
        {
            try
            {
                LibraryContext libraryContext = new LibraryContext();
                libraryContext.Remove(user);
                libraryContext.SaveChanges();
            }
            catch
            {
                throw new Exception("Delete failed!");
            }
        }
    }
}
