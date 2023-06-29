using System;
using System.Collections.Generic;

namespace ERPWebAPI.Models;

public partial class Individual
{
    public DateTime? BirthDate { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int CustId { get; set; }

    public virtual Customer Cust { get; set; } = null!;
}
