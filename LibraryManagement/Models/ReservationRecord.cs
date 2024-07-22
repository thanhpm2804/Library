using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class ReservationRecord
{
    public int UserId { get; set; }

    public int BookId { get; set; }

    public DateOnly? ReservationDate { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
