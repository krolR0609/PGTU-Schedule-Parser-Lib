using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseLib.Models
{
    public interface IDiscipline
    {
        DateTime Time { get; set; }
        DayOfWeek Day { get; set; }
        string Teacher { get; set; }
        string Place { get; set; }
    }
}
