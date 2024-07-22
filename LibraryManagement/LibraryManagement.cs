using Library.Models;

namespace Library
{
    public class LibraryManagement
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

    }
}
