namespace Vilnius1.Api.Contracts;

    public sealed class Facility
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<string> AssignmentNames { get; set; } = new();
        public List<Assignment> Assignments { get; set; } = new();
}
