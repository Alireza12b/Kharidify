using System;
using System.Collections.Generic;

namespace App.Infra.Data.SqlServer.EF.Models;

public partial class Product
{
    public int Id { get; set; }

    public int ShopId { get; set; }

    public int SubCategoriesId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int TotalQuantity { get; set; }

    public DateTime RegisterDate { get; set; }

    public bool IsActive { get; set; }

    public bool IsRemoved { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual ICollection<ProductsPrice> ProductsPrices { get; set; } = new List<ProductsPrice>();

    public virtual Shop Shop { get; set; } = null!;

    public virtual SubCategory SubCategories { get; set; } = null!;
}
