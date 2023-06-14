﻿using System;
using System.Collections.Generic;

namespace Vilnius1.Application.Models;

public partial class FacilityAssignment
{
    public long Id { get; set; }

    public long FacilityId { get; set; }

    public long AssignmentId { get; set; }

    public virtual Assignment Assignment { get; set; } = null!;

    public virtual Facility Facility { get; set; } = null!;
}
