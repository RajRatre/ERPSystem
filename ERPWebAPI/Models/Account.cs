using System;
using System.Collections.Generic;

namespace ERPWebAPI.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public double? AvailBalance { get; set; }

    public DateTime? CloseDate { get; set; }

    public DateTime? LastActivityDate { get; set; }

    public DateTime OpenDate { get; set; }

    public double? PendingBalance { get; set; }

    public string? Status { get; set; }

    public int? CustId { get; set; }

    public int OpenBranchId { get; set; }

    public int OpenEmpId { get; set; }

    public string ProductCd { get; set; } = null!;

    public virtual ICollection<AccTransaction> AccTransactions { get; set; } = new List<AccTransaction>();

    public virtual Customer? Cust { get; set; }

    public virtual Branch OpenBranch { get; set; } = null!;

    public virtual Employee OpenEmp { get; set; } = null!;

    public virtual Product ProductCdNavigation { get; set; } = null!;
}
