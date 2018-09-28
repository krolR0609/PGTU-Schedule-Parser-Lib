using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseLib.Models
{
    public class Discipline : IDiscipline
    {
        public DateTime Time { get; set; }
        public DayOfWeek Day { get; set; }
        public string Teacher { get; set; }
        public string Place { get; set; }
    }
}
