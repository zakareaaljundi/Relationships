using System;
using System.Collections.Generic;

namespace Relationships.Models;

public partial class Doh
{
    public int DohId { get; set; }

    public string? DohName { get; set; }

    public int GovernorateId { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual Governorate? Governorate { get; set; }

    public virtual ICollection<HealthInstitution> HealthInstitutions { get; set; } = new List<HealthInstitution>();

    public virtual ICollection<Nahia> Nahia { get; set; } = new List<Nahia>();
}
