using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EngitelExam.Web.Models.ViewModels
{
    public class CalendarioVM
    {

        public int Year { get; set; }
        public int Month { get; set; }
        public IList<DayVM> Days { get; set; } = new IList<DayVM>();

    }
}