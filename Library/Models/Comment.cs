using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Comment
{
    public int UserId { get; set; }

    public int BookId { get; set; }

    public string? Comments { get; set; }

    public byte? Rating { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
