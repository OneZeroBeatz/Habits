using Habits.Data;
using Habits.Repo;
using System;
using System.Collections.Generic;

namespace Habits.Service
{
    public class DailyService
    {
        private DailyLogRepository _dailyLogRepository;

        public DailyService(DailyLogRepository dailyLogRepository)
        {
            _dailyLogRepository = dailyLogRepository;
        }

        public DailyLog GetDailyLog(long id)
        {
            return _dailyLogRepository.Get(id);
        }

        public DailyLog GetLogForDate(DateTime dateTime)
        {
            return _dailyLogRepository.GetByDate(dateTime.Date);
        }

        public DailyLog AddDailyLog(DailyLog dailyLog)
        {
            if (_dailyLogRepository.GetByDate(dailyLog.Date) != null)
                return default;

            dailyLog.AddedDate = DateTime.Now;
            _dailyLogRepository.Insert(dailyLog);

            return dailyLog;
        }

        public DailyLog EditDailyLog(DailyLog dailyLog)
        {
            var dailyLogToEdit = _dailyLogRepository.GetByDate(dailyLog.Date);

            dailyLogToEdit.ModifiedDate = DateTime.Now;
            dailyLogToEdit.LastMealTimeStamp = dailyLog.LastMealTimeStamp;
            dailyLogToEdit.Fasted = dailyLog.Fasted;
            dailyLogToEdit.City = dailyLog.City;
            dailyLogToEdit.MorningWeight = dailyLog.MorningWeight;
            dailyLogToEdit.Stretched = dailyLog.Stretched;
            dailyLogToEdit.Steps = dailyLog.Steps;
            dailyLogToEdit.Sport = dailyLog.Sport;

            _dailyLogRepository.Update(dailyLog);

            return dailyLog;
        }

        public List<DailyLog> GetDailyLogsForRange(DateTime startDate, DateTime endDate)
        {
            return _dailyLogRepository.GetDailyLogsForRange(startDate, endDate);
        }
    }
}
