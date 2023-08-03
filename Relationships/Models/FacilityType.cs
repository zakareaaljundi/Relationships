using System;
using System.Collections.Generic;

namespace Relationships.Models;

public partial class FacilityType
{
    public int FacilityTypeId { get; set; }

    public string? FacilityTypeName { get; set; }

    public virtual ICollection<HealthInstitution> HealthInstitutions { get; set; } = new List<HealthInstitution>();
}
