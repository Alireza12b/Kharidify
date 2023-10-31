using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Users.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime RegisterDate { get; set; } = DateTime.Now;

    public bool IsActive { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
