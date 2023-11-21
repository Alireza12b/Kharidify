using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class Product
{
    public int Id { get; set; }

    public int ShopId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int TotalQuantity { get; set; }

    public DateTime RegisterDate { get; set; } = DateTime.Now;

    public bool IsActive { get; set; }

    public bool IsRemoved { get; set; }


    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<ProductsPrice> ProductsPrices { get; set; } = new List<ProductsPrice>();

    public virtual OrderLine OrderLines { get; set; } = null!;

    public virtual Auction Auctions { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
