namespace Core.Entities.Models;

public class Employee
{
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }
    public string Timespan { get; set; }
    public bool Busy { get; set; }
}