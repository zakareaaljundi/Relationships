using System;
using System.Collections.Generic;

namespace Relationships.Models;

public partial class HealthInstitution
{
    public int HealthInstitutionId { get; set; }

    public string? HealthInstitutionName { get; set; }

    public int GovernorateId { get; set; }

    public int FacilityTypeId { get; set; }

    public int DohId { get; set; }

    public virtual Doh Doh { get; set; } = null!;

    public virtual FacilityType FacilityType { get; set; } = null!;

    public virtual Governorate Governorate { get; set; } = null!;
}
