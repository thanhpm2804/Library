using System.Collections;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.bo
{
    public class CommentsManagement
    {
        private List<Comment> getAll()
        {
            LibraryContext context = new LibraryContext();
            return context.Comments.ToList();
        }

        private List<Comment> getCommentsOfAnUser(int userId)
        {
            List<Comment> comments = new List<Comment>();
            foreach (Comment comment in getAll())
            {
                if (comment.UserId == userId)
                {
                    comments.Add(comment);
                }
            }
            return comments;
        }

        public Comment getCommentByUserAndBook(User user, Book book)
        {
            foreach (Comment comment in getCommentsOfAnUser(user.UserId))
            {
                if (comment.BookId == book.BookId)
                {
                    return comment;
                }
            }
            return null;
        }

        public void removeAllCommentOfUser(int userId)
        {
            foreach (Comment c in getCommentsOfAnUser(userId))
            {
                removeComment(c);
            }
        }

        public Comment getCommentByUserAndBook(int userId, int bookId) 
        {
            foreach (Comment comment in getCommentsOfAnUser(userId))
            {
                if (comment.BookId == bookId)
                {
                    return comment;
                }
            }
            return null;
        }

        public bool isCommentExist(int userId, int bookId)
        {
            return getCommentByUserAndBook(userId, bookId) != null;
        }

        public void insertComment(Comment comment)
        {
            LibraryContext library = new LibraryContext();
            library.Comments.Add(comment);
            library.SaveChanges();
        }

        public void updateComment(Comment comment)
        {
            LibraryContext library = new LibraryContext();
            library.Entry<Comment>(comment).State = EntityState.Modified;
            library.SaveChanges();
        }

        public void removeComment(Comment comment)
        {
            LibraryContext library = new LibraryContext();
            library.Comments.Remove(comment);
            library.SaveChanges();
        }

        private List<Comment> getAllCommentsOfBook(int bookId)
        {
            List<Comment> ret = new List<Comment> ();
            foreach (Comment c in getAll())
            {
                if (c.BookId == bookId)
                {
                    ret.Add(c);
                }
            }
            return ret;
        }

        public void removeAllCommentsOfBook(int bookId)
        {
            foreach (Comment c in getAllCommentsOfBook(bookId))
            {
                removeComment(c);
            }
        }
    }
}
