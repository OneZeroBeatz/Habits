using Habits.Repo;
using Habits.Service.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Habits.Service
{
    public class WeeklyService
    {
        private DailyLogRepository _dailyLogRepository;

        public WeeklyService(DailyLogRepository dailyLogRepository)
        {
            _dailyLogRepository = dailyLogRepository;
        }

        public List<WeekInYearDto> GetWeeksForYear(int year)
        {
            var jan1 = new DateTime(year, 1, 1);
            //beware different cultures, see other answers
            var startOfFirstWeek = jan1.AddDays(1 - (int)(jan1.DayOfWeek));
            var weeks =
                Enumerable
                    .Range(0, 54)
                    .Select(i => new {
                        weekStart = startOfFirstWeek.AddDays(i * 7)
                    })
                    .TakeWhile(x => x.weekStart.Year <= jan1.Year)
                    .Select(x => new {
                        x.weekStart,
                        weekFinish = x.weekStart.AddDays(6)
                    })
                    .SkipWhile(x => x.weekFinish < jan1.AddDays(1))
                    .Select((x, i) => new WeekInYearDto (){
                        StartDate = x.weekStart,
                        EndDate = x.weekFinish,
                        WeekNumber = i + 1
                    });

            return weeks.ToList();
        }

        public int GetWeekNumberForDateTime(DateTime dateTime)
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            Calendar calendar = cultureInfo.Calendar;

            return calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

    }
}
