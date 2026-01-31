using EngitelExam.Web.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EngitelExam.Web.Models.ViewModels
{
    public class Step2VeicoliVM
    {
        public List<VeicoloVM> Veicoli { get; set; } = new List<VeicoloVM>();

    }
}