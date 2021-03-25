using Habits.Data;
using Habits.Repo;
using Habits.Repo.Interfaces;
using System;

namespace Habits.Service
{
    public class DailyStatisticService
    {
        private DailyStatisticsRepository _dailyStatisticRepository;

        public DailyStatisticService(DailyStatisticsRepository dailyStatisticRepository)
        {
            _dailyStatisticRepository = dailyStatisticRepository;
        }

        public DailyStatistic GetDailyStatistic(long id)
        {
            return _dailyStatisticRepository.Get(id);
        }

        public DailyStatistic GetStatisticForToday()
        {
            return _dailyStatisticRepository.GetByDate(DateTime.UtcNow.Date);
        }

        public DailyStatistic GetStatisticForDate(DateTime dateTime)
        {
            return _dailyStatisticRepository.GetByDate(dateTime.Date);
        }

        public DailyStatistic AddDailyStatistic(DailyStatistic dailyStatistic)
        {
            if (_dailyStatisticRepository.GetByDate(dailyStatistic.Date) != null)
                return default;

            dailyStatistic.AddedDate = DateTime.Now;
            _dailyStatisticRepository.Insert(dailyStatistic);

            return dailyStatistic;
        }

        public DailyStatistic EditDailyStatistic(DailyStatistic dailyStatistic)
        {
            var statisticToEdit = _dailyStatisticRepository.GetByDate(dailyStatistic.Date);

            statisticToEdit.ModifiedDate = DateTime.Now;
            statisticToEdit.LastMealTimeStamp = dailyStatistic.LastMealTimeStamp;
            statisticToEdit.Fasted = dailyStatistic.Fasted;
            statisticToEdit.City = dailyStatistic.City;
            statisticToEdit.MorningWeight = dailyStatistic.MorningWeight;
            statisticToEdit.Stretched = dailyStatistic.Stretched;
            statisticToEdit.Steps = dailyStatistic.Steps;
            statisticToEdit.Sport = dailyStatistic.Sport;

            _dailyStatisticRepository.Update(dailyStatistic);

            return dailyStatistic;
        }
    }
}
