using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Library.bo;
using Library.Models;

namespace Library
{
    /// <summary>
    /// Interaction logic for CommentPage.xaml
    /// </summary>
    public partial class CommentPage : Page
    {
        User user;
        CommentsManagement commentsManagement;
        BookManagement bookManagement;
        public CommentPage(User user)
        {
            InitializeComponent();
            this.user = user;
            commentsManagement = new CommentsManagement();
            bookManagement = new BookManagement();
            loadList();
        }

        private void loadList()
        {
            lvBook.ItemsSource = GetCommentList();
        }

        private List<Comment> GetCommentList()
        {
            List<Comment> ret = new List<Comment>();
            foreach (Book book in bookManagement.getAllBooks())
            {
                Comment comment = commentsManagement.getCommentByUserAndBook(user, book);
                if (comment == null)
                {
                    ret.Add(new Comment
                    {
                        Book = book,
                    });
                }
                else
                {
                    comment.Book = book;
                    ret.Add(comment);
                }
            }
            return ret;
        }

        private Comment getCommentInfo()
        {
            try
            {
                Comment comment = new Comment();
                String bid = txtBookID.Text;
                if (bid == null || bid == "")
                {
                    throw new Exception("Please choose a book!");
                }
                comment.BookId = int.Parse(bid);
                String comm = txtComment.Text;
                if (comm == null || comm == "")
                {
                    throw new Exception("Please enter comment!");
                }
                comment.Comments = comm;
                try
                {
                    byte rating = byte.Parse(txtRating.Text);
                    if (rating < 0 || rating > 5)
                    {
                        throw new Exception();
                    }
                    comment.Rating = rating;
                }
                catch (Exception ex)
                {
                    throw new Exception("Please enter your rating with an integer from 0 - 5!");
                }
                comment.UserId = user.UserId;
                return comment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnComment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Comment comment = getCommentInfo();
                if (!commentsManagement.isCommentExist(comment.UserId, comment.BookId))
                {
                    commentsManagement.insertComment(comment);
                }
                else
                {
                    commentsManagement.updateComment(comment);
                }
                loadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Comment");
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String bid = txtBookID.Text;
                if (bid == null || bid == "")
                {
                    throw new Exception("Please choose a book!");
                }
                int bookId = int.Parse(bid);
                Comment comment = commentsManagement.getCommentByUserAndBook(user.UserId, bookId);
                if (comment == null)
                {
                    throw new Exception("You haven't comment on this book yet!");
                }
                else
                {
                     commentsManagement.removeComment(comment);
                }
                loadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Remove comment");
            }
        }

        private void lvBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
