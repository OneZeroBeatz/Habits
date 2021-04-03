using Habits.Data;
using Habits.Data.Enums;
using Habits.Repo.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Habits.Repo
{
    public class DailyLogRepository : FileRepository<DailyLog>
    {
        public DailyLogRepository()
        {
            _entities = new Dictionary<long, DailyLog>(30);
            for (int i = 20; i >= 0; i--)
            {
                var record = new DailyLog
                {
                    Date = DateTime.UtcNow.AddDays(-i).Date,
                    Steps = 300,
                    City = "Knicanin" + i,
                    AddedDate = DateTime.UtcNow,
                    Fasted = i % 2 == 1,
                    LastMealTimeStamp = new TimeSpan(20, 20, 30),
                    Id = 20 - i,
                    ModifiedDate = DateTime.UtcNow,
                    MorningWeight = i % 2 == 1 ? 83 : 99,
                    Stretched = i % 3 == 1,
                    Sport = (Sport)(i % 3)
                };

                _entities.Add(record.Id, record);
            }
        }

        public DailyLog GetByDate(DateTime date)
        {
            return _entities.FirstOrDefault(s => s.Value.Date == date.Date).Value;
        }

        public List<DailyLog> GetDailyLogsForRange(DateTime startDate, DateTime endDate)
        {
            return _entities
                .Where(log => log.Value.Date.CompareTo(startDate.Date) >= 0)
                .Where(log => log.Value.Date.CompareTo(endDate.Date) <= 0)
                .Select(x=>x.Value)
                .ToList();
        }
    }
}
