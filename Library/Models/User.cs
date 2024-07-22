using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? IsAdmin { get; set; }

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<ReservationRecord> ReservationRecords { get; set; } = new List<ReservationRecord>();
}
