using System;
using System.Collections.Generic;

namespace Relationships.Models;

public partial class Nahia
{
    public int NahiaId { get; set; }

    public string? NahiaName { get; set; }

    public int GovernorateId { get; set; }

    public int DistrictId { get; set; }

    public int DohId { get; set; }

    public virtual District District { get; set; } = null!;

    public virtual Doh Doh { get; set; } = null!;

    public virtual Governorate Governorate { get; set; } = null!;
}
