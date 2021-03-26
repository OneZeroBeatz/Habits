using System;

namespace Habits.Service.Models
{
    public class WeekInYearDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WeekNumber { get; set; }

        public string WeekRange => $"{StartDate.ToString("dd-MMMM-yyyy")} - {EndDate.ToString("dd-MMMM-yyyy")}";
    }
}
