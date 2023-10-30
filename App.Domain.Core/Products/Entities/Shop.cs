using App.Domain.Core.Users.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class Shop
{
    public int Id { get; set; }

    public int SellerId { get; set; }

    public string ShopName { get; set; } = null!;

    public int Rank { get; set; }

    public int CityId { get; set; }

    public string AdressDetail { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Seller Seller { get; set; } = null!;
}
