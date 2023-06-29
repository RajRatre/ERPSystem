using System;
using System.Collections.Generic;

namespace ERPWebAPI.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public DateTime? EndDate { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public string? Title { get; set; }

    public int? AssignedBranchId { get; set; }

    public int? DeptId { get; set; }

    public int? SuperiorEmpId { get; set; }

    public virtual ICollection<AccTransaction> AccTransactions { get; set; } = new List<AccTransaction>();

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual Branch? AssignedBranch { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual ICollection<Employee> InverseSuperiorEmp { get; set; } = new List<Employee>();

    public virtual Employee? SuperiorEmp { get; set; }
}
