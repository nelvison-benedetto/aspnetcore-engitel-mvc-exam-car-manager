using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EngitelExam.Web.Models.ViewModels
{
    public class Step1FamigliaVM
    {
        [Required, StringLength(50)]
        public string NomeFamiglia { get; set; }

        [Range(1, 10)]
        public int NumeroComponenti { get; set; }

        [Range(0, 10)]
        public int NumeroComponentiWCar { get; set; }

    }
}