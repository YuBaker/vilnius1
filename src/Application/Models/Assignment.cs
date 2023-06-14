namespace Vilnius1.Application.Models;

public class Assignment
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<FacilityAssignmentLog> FacilityAssignmentLogs { get; set; } = new List<FacilityAssignmentLog>();

    public virtual ICollection<FacilityAssignment> FacilityAssignments { get; set; } = new List<FacilityAssignment>();
}
