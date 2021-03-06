using Habits.Data.Base;
using Habits.Data.Enums;
using System;

namespace Habits.Data
{
    public class DailyLog : BaseEntity
    {
        public DateTime Date { get; set; }
        public bool Fasted { get; set; }
        public decimal? MorningWeight { get; set; }
        public TimeSpan? LastMealTimeStamp { get; set; }
        public string City { get; set; }
        public bool Stretched { get; set; }
        public int? Steps { get; set; }
        public Sport? Sport { get; set; }
    }
}
