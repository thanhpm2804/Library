using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public byte? Quantity { get; set; }

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<ReservationRecord> ReservationRecords { get; set; } = new List<ReservationRecord>();
}
