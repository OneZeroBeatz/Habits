using Habits.Data;
using Habits.Repo.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Habits.Repo
{
    public class DailyStatisticsRepository : FileRepository<DailyStatistic>
    {
        public DailyStatisticsRepository()
        {
            _entities = new Dictionary<long, DailyStatistic>(30);
            for (int i = 20; i >= 0; i--)
            {
                var record = new DailyStatistic
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
                    Stretched = i % 3 == 1
                };

                _entities.Add(record.Id, record);
            }
        }

        public DailyStatistic GetByDate(DateTime date)
        {
            return _entities.FirstOrDefault(s => s.Value.Date == date.Date).Value;
        }
    }
}
