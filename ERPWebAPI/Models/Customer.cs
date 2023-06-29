using System;
using System.Collections.Generic;

namespace ERPWebAPI.Models;

public partial class Customer
{
    public int CustId { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string CustTypeCd { get; set; } = null!;

    public string FedId { get; set; } = null!;

    public string? PostalCode { get; set; }

    public string? State { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual Business? Business { get; set; }

    public virtual Individual? Individual { get; set; }

    public virtual ICollection<Officer> Officers { get; set; } = new List<Officer>();
}
