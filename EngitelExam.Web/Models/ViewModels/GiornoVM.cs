using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EngitelExam.Web.Models.ViewModels
{
    public class GiornoVM
    {
        public int DayId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<AppuntamentoVM> Appuntamenti { get; set; }
    }
}