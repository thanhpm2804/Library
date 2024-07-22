using Library.Models;

List<BorrowRecord> getAll()
{
    List<BorrowRecord> list;
    try
    {
        LibraryContext library = new LibraryContext();
        list = library.BorrowRecords.ToList();
    }
    catch (Exception ex)
    {
        throw new Exception(ex.Message);
    }

    return list;
}
List<Book> getAllBorrowwedBooks(User user)
{
    var list = new List<Book>();
    foreach (BorrowRecord record in getAll())
    {
        if (record.UserId == user.UserId)
        {
            list.Add(record.Book);
        }
    }
    return list;
}

Boolean isBookBorrowed(User user, Book book)
{
    var list = getAllBorrowwedBooks(user);
    return list.Contains(book);
}