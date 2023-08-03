using System;
using System.Collections.Generic;

namespace Relationships.Models;

public partial class District
{
    public int DistrictId { get; set; }

    public string? DistrictName { get; set; }

    public int GovernorateId { get; set; }

    public int DohId { get; set; }

    public virtual Doh Doh { get; set; } = null!;

    public virtual Governorate Governorate { get; set; } = null!;

    public virtual ICollection<Nahia> Nahia { get; set; } = new List<Nahia>();
}
