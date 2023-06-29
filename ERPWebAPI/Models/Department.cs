using System;
using System.Collections.Generic;

namespace ERPWebAPI.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
