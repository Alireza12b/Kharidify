using App.Domain.Core.Users.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ProvinceId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual Province? Province { get; set; }

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}
