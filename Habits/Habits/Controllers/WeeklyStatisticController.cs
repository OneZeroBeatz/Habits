using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Habits.Data;
using Habits.Models;
using Habits.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Habits.Controllers
{
    public class WeeklyStatisticController : Controller
    {
        private readonly WeeklyService _weeklyService;

        public WeeklyStatisticController(WeeklyService weeklyService)
        {
            _weeklyService = weeklyService;
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

            var veiwModel = new WeeklyStatisticViewModel
            {
                WeekInYear = weekInYear,
                Weeks = weeksInYear,
                Year = year
            };

            return View(veiwModel);
        }
    }
}
