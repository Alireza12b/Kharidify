﻿using System;
using System.Collections.Generic;

namespace App.Infra.Data.SqlServer.EF.Models;

public partial class Province
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}