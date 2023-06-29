using System;
using System.Collections.Generic;

namespace ERPWebAPI.Models;

public partial class Business
{
    public DateTime? IncorpDate { get; set; }

    public string Name { get; set; } = null!;

    public string StateId { get; set; } = null!;

    public int CustId { get; set; }

    public virtual Customer Cust { get; set; } = null!;
}
