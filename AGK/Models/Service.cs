using System;
using System.Collections.Generic;

namespace AGK.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Price { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
