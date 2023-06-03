using System;
using System.Collections.Generic;

namespace AGK.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public int IdServices { get; set; }

    public virtual Service IdServicesNavigation { get; set; } = null!;
}
