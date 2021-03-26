using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Habits.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Habits.Models
{
    public class WeeklyStatisticViewModel
    {
        public int Year { get; set; }
        public int WeekInYear { get; set; }
        public List<WeekInYearDto> Weeks { get; set; }
        
    
    }
}
