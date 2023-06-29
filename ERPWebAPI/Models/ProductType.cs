using System;
using System.Collections.Generic;

namespace ERPWebAPI.Models;

public partial class ProductType
{
    public string ProductTypeCd { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
