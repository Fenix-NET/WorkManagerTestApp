using Core.Entities.Models;

namespace Core.Shared;

public static class WorkingTimeHelper
{
    public static Employee SelectEmployee(IEnumerable<Employee> employees, DateTime startAt)
    {
        TimeSpan timeDifference = TimeSpan.MaxValue;
        Employee selectEmployee = null;

        foreach (var employee in employees)
        {
            string[] workHours = employee.Timespan.Split('-');
            DateTime startTime = DateTime.Parse(workHours[0].Trim());
            DateTime endTime = DateTime.Parse(workHours[1].Trim());

            if (startAt > startTime && startAt < endTime)
            {
                TimeSpan tempTimeDifference = endTime - startAt;

                if (tempTimeDifference < timeDifference)
                {
                    selectEmployee = employee;
                    timeDifference = tempTimeDifference;
                }
            }
        }
        return selectEmployee;
    }

    public static bool TimeChecking(Employee employee, DateTime dt)
    {
        string[] workHours = employee.Timespan.Split('-');
        DateTime startTime = DateTime.Parse(workHours[0].Trim());
        DateTime endTime = DateTime.Parse(workHours[1].Trim());

        bool isCheck = dt > startTime && dt < endTime;

        return isCheck;
    }
}