using System;
using System.Collections.Generic;

namespace ERPWebAPI.Models;

public partial class Branch
{
    public int BranchId { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string Name { get; set; } = null!;

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public virtual ICollection<AccTransaction> AccTransactions { get; set; } = new List<AccTransaction>();

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
