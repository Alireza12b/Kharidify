using App.Domain.Core.Products.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Users.Entities;

public partial class User : IdentityUser<int>
{
    public override int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime RegisterDate { get; set; } = DateTime.Now;

    public bool IsActive { get; set; }

    public bool IsRemoved { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual Seller Seller { get; set; } = null!;
}
