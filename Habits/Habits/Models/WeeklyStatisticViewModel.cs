using System.Collections.Generic;
using Habits.Service.Models;

namespace Habits.Models
{
    public class WeeklyStatisticViewModel
    {
        public int Year { get; set; }
        public int WeekInYear { get; set; }
        public List<WeekInYearDto> Weeks { get; set; }
        public List<DailyStatisticViewModel> WeeklyLogs { get; set; }


    }
}
