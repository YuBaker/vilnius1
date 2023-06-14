namespace Vilnius1.Application.Models;

public class Facility
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FacilityAssignmentLog> FacilityAssignmentLogs { get; set; } = new List<FacilityAssignmentLog>();

    public virtual ICollection<FacilityAssignment> FacilityAssignments { get; set; } = new List<FacilityAssignment>();
}
