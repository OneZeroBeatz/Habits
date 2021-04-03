using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Habits.Data;
using Habits.Models;
using Habits.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Habits.Controllers
{
    public class WeeklyStatisticController : Controller
    {
        private readonly WeeklyService _weeklyService;
        private readonly DailyService _dailyService;

        public WeeklyStatisticController(WeeklyService weeklyService, DailyService dailyService)
        {
            _weeklyService = weeklyService;
            _dailyService = dailyService;
        }

        // GET: /DailyStatistic/Index
        [HttpGet]
        public IActionResult Index()
        {
            var now = DateTime.Now;
            var year = now.Year;
            var weekInYear = _weeklyService.GetWeekNumberForDateTime(DateTime.Now);

            return RedirectToAction("GetStatisticForWeek", new { year, weekInYear });
        }

        // GET: /DailyStatistic/GetStatisticForWeek
        [HttpGet]
        public IActionResult GetStatisticForWeek(int year, int weekInYear)
        {
            var weeksInYear = _weeklyService.GetWeeksForYear(year);
            var targetWeek = weeksInYear.First(week => week.WeekNumber == weekInYear);
            var weeklyLogs = _dailyService.GetDailyLogsForRange(targetWeek.StartDate.Date, targetWeek.EndDate.Date);

            var veiwModel = new WeeklyStatisticViewModel
            {
                WeekInYear = weekInYear,
                Weeks = weeksInYear,
                Year = year,
                WeeklyLogs = weeklyLogs.Select(GenerateDailyLogViewModel).ToList()
            };

            return View(veiwModel);
        }
        public JsonResult GetWeeksForYear(int year)
        {
            var weeksForYear = _weeklyService.GetWeeksForYear(year);
            return Json(weeksForYear);
        }

        private DailyStatisticViewModel GenerateDailyLogViewModel(DailyLog dailyLog)
        {
            var todayStatisticViewModel = new DailyStatisticViewModel
            {
                Date = dailyLog.Date,
                City = dailyLog.City,
                Fasted = dailyLog.Fasted,
                Id = dailyLog.Id,
                LastMealTimeStamp = dailyLog.LastMealTimeStamp,
                MorningWeight = dailyLog.MorningWeight,
                Steps = dailyLog.Steps,
                Stretched = dailyLog.Stretched,
                Sport = dailyLog.Sport
            };

            return todayStatisticViewModel;
        }
    }
}
