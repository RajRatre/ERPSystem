using System;
using System.Collections.Generic;

namespace ERPWebAPI.Models;

public partial class Officer
{
    public int OfficerId { get; set; }

    public DateTime? EndDate { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public string? Title { get; set; }

    public int? CustId { get; set; }

    public virtual Customer? Cust { get; set; }
}
