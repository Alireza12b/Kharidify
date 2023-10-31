using App.Domain.Core.Users.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public string Message { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
