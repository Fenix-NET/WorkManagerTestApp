using ConsoleDataGenerator.Data;
using ConsoleDataGenerator.Models;

namespace ConsoleDataGenerator.Extensions;

public static class DataBasePlaceholder
{
    public static void AddEmployees(WorkDBContext context)
    {
        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            var department = context.Departments.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                DepartmentId = department.Id,
                Timespan = GetRandomTimespan(random),
                Busy = false
            };

            context.Employees.Add(employee);
        }
    }

    public static void AddDepartments(WorkDBContext context)
    {
        string[] departmentNames = { "management", "development", "analytics" };

        foreach (var departmentName in departmentNames)
        {
            var department = new Department
            {
                Id = Guid.NewGuid(),
                Name = departmentName
            };

            context.Departments.Add(department);
        }
    }

    static string GetRandomTimespan(Random random)
    {
        string[] timespans = { "08:00-17:00", "09:00-18:00", "10:00-19:00" };
        return timespans[random.Next(timespans.Length)];
    }
}