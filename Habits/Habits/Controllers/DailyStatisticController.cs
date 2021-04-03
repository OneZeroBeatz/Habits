using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Habits.Data;
using Habits.Models;
using Habits.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Habits.Controllers
{
    public class DailyStatisticController : Controller
    {
        private readonly DailyService _dailyStatisticService;

        public DailyStatisticController(DailyService dailyStatisticService)
        {
            _dailyStatisticService = dailyStatisticService;
        }

        // GET: /DailyStatistic/Index
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("GetStatisticByDate", new { date = DateTime.UtcNow.Date });
        }

        // GET: /DailyStatistic/GetStatisticByDate
        [HttpGet]
        public IActionResult GetStatisticByDate(DateTime date)
        {
            var statisticForDate = _dailyStatisticService.GetLogForDate(date);
            if (statisticForDate == null)
                return RedirectToAction("CreateDailyStatistic", new { date });

            var todayStatisticViewModel = new DailyStatisticViewModel
            {
                Date = statisticForDate.Date,
                City = statisticForDate.City,
                Fasted = statisticForDate.Fasted,
                Id = statisticForDate.Id,
                LastMealTimeStamp = statisticForDate.LastMealTimeStamp,
                MorningWeight = statisticForDate.MorningWeight,
                Steps = statisticForDate.Steps,
                Stretched = statisticForDate.Stretched,
                Sport = statisticForDate.Sport
            };

            return View(todayStatisticViewModel);
        }

        // GET: /DailyStatistic/CreateDailyStatistic
        [HttpGet]
        public IActionResult CreateDailyStatistic(DateTime date)
        {
            var todayStatisticViewModel = new DailyStatisticViewModel
            {
                Date = date,
            };

            return View(todayStatisticViewModel);
        }

        // POST: /DailyStatistic/CreateDailyStatistic
        [HttpPost]
        public IActionResult CreateDailyStatistic(DailyStatisticViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var dailyStatistic = new DailyLog
            {
                City = model.City,
                Date = model.Date,
                Fasted = model.Fasted,
                LastMealTimeStamp = model.LastMealTimeStamp,
                MorningWeight = model.MorningWeight,
                Steps = model.Steps,
                Stretched = model.Stretched,
                Sport = model.Sport
            };

            _dailyStatisticService.AddDailyLog(dailyStatistic);

            return RedirectToAction("GetStatisticByDate", new { model.Date });
        }

        // GET: /DailyStatistic/EditDailyStatistic
        [HttpGet]
        public IActionResult EditDailyStatistic(DateTime date)
        {
            var statisticForDate = _dailyStatisticService.GetLogForDate(date);
            if (statisticForDate == null)
                return RedirectToAction("CreateDailyStatistic", new { date });

            var dailyStatisticForDate = new DailyStatisticViewModel
            {
                Date = statisticForDate.Date,
                City = statisticForDate.City,
                Fasted = statisticForDate.Fasted,
                Id = statisticForDate.Id,
                LastMealTimeStamp = statisticForDate.LastMealTimeStamp,
                MorningWeight = statisticForDate.MorningWeight,
                Steps = statisticForDate.Steps,
                Stretched = statisticForDate.Stretched,
                Sport = statisticForDate.Sport
            };

            return View(dailyStatisticForDate);
        }
        // POST: /DailyStatistic/EditDailyStatistic
        [HttpPost]
        public IActionResult EditDailyStatistic(DailyStatisticViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dailyStatistic = new DailyLog
            {
                City = model.City,
                Date = model.Date,
                Fasted = model.Fasted,
                LastMealTimeStamp = model.LastMealTimeStamp,
                MorningWeight = model.MorningWeight,
                Steps = model.Steps,
                Stretched = model.Stretched,
                Sport = model.Sport
            };

            _dailyStatisticService.EditDailyLog(dailyStatistic);

            return RedirectToAction("GetStatisticByDate", new { model.Date });
        }

    }
}
