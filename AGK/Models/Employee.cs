using System;
using System.Collections.Generic;

namespace AGK.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public int IdServices { get; set; }

    public virtual Service IdServicesNavigation { get; set; } = null!;
}
