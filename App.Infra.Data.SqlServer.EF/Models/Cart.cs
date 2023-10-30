using System;
using System.Collections.Generic;

namespace App.Infra.Data.SqlServer.EF.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public bool IsPaid { get; set; }

    public DateTime? PayDate { get; set; }

    public int? CityId { get; set; }

    public string? AddressDetail { get; set; }

    public string? PostalCode { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int StatusId { get; set; }

    public virtual City? City { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual OrderStatus Status { get; set; } = null!;
}
