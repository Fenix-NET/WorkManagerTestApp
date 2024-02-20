using Core.Entities.Models;
using Core.Entities.RequestParametrs;
using System.Globalization;

namespace Infrastructure.Extensions;

public static class TimeHelper
{
    public static bool TimeFilter(this Employee employee, DepartmentAssignParams param)
    {
        string[] parts = employee.Timespan.Split('-');

        string startTime = parts[0].Trim();
        string endTime = parts[1].Trim();

        DateTime minTime = DateTime.ParseExact(startTime, "hh\\:mm", CultureInfo.InvariantCulture);
        DateTime maxTime = DateTime.ParseExact(endTime, "hh\\:mm", CultureInfo.InvariantCulture);

        bool isAccess = param.StartAt > minTime && param.StartAt < maxTime;

        return isAccess;

    }
}