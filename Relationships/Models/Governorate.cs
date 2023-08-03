using System;
using System.Collections.Generic;

namespace Relationships.Models;

public partial class Governorate
{
    public int GovernorateId { get; set; }

    public string? GovernorateName { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual ICollection<Doh> Dohs { get; set; } = new List<Doh>();

    public virtual ICollection<HealthInstitution> HealthInstitutions { get; set; } = new List<HealthInstitution>();

    public virtual ICollection<Nahia> Nahia { get; set; } = new List<Nahia>();
}
