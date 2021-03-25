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
        private readonly DailyStatisticService _dailyStatisticService;

        public DailyStatisticController(DailyStatisticService dailyStatisticService)
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
            var statisticForDate = _dailyStatisticService.GetStatisticForDate(date);
            if (statisticForDate == null)
                return RedirectToAction("CreateDailyStatistic", new { date });

            var todayStatisticViewModel = new StatisticForDateViewModel
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
            var todayStatisticViewModel = new StatisticForDateViewModel
            {
                Date = date,
            };

            return View(todayStatisticViewModel);
        }

        // POST: /DailyStatistic/CreateDailyStatistic
        [HttpPost]
        public IActionResult CreateDailyStatistic(StatisticForDateViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var dailyStatistic = new DailyStatistic
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

            _dailyStatisticService.AddDailyStatistic(dailyStatistic);

            return RedirectToAction("GetStatisticByDate", new { model.Date });
        }

        // GET: /DailyStatistic/EditDailyStatistic
        [HttpGet]
        public IActionResult EditDailyStatistic(DateTime date)
        {
            var statisticForDate = _dailyStatisticService.GetStatisticForDate(date);
            if (statisticForDate == null)
                return RedirectToAction("CreateDailyStatistic", new { date });

            var todayStatisticViewModel = new StatisticForDateViewModel
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
        // POST: /DailyStatistic/EditDailyStatistic
        [HttpPost]
        public IActionResult EditDailyStatistic(StatisticForDateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dailyStatistic = new DailyStatistic
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

            _dailyStatisticService.EditDailyStatistic(dailyStatistic);

            return RedirectToAction("GetStatisticByDate", new { model.Date });
        }

    }
}
