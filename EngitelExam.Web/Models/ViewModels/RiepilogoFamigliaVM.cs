using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EngitelExam.Web.Models.ViewModels
{
    public class RiepilogoFamigliaVM
    {
        public Step1FamigliaVM Famiglia { get; set; }
        public List<VeicoloVM> Veicoli { get; set; }
    }
}