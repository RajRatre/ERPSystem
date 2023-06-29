using System;
using System.Collections.Generic;

namespace ERPWebAPI.Models;

public partial class Product
{
    public string ProductCd { get; set; } = null!;

    public DateTime? DateOffered { get; set; }

    public DateTime? DateRetired { get; set; }

    public string Name { get; set; } = null!;

    public string? ProductTypeCd { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ProductType? ProductTypeCdNavigation { get; set; }
}
