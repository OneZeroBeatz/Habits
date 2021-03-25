using System;
using System.ComponentModel.DataAnnotations;
using Habits.Data.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Habits.Models
{
    public class StatisticForDateViewModel
    {
        [HiddenInput]
        public long Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        public bool Fasted { get; set; }
        [Display(Name = "Morning Weight")]
        public decimal? MorningWeight { get; set; }
        [Display(Name = "Last Meal Time")]
        public TimeSpan? LastMealTimeStamp { get; set; }
        public string City { get; set; }
        public bool Stretched { get; set; }
        public int? Steps { get; set; }
        public Sport? Sport { get; set; }
    }
}
