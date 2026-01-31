using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EngitelExam.Web.Models.ViewModels
{
    public class VeicoloVM
    {
        [Required]
        public string Targa { get; set; }

        [Required]
        public string Modello { get; set; }

    }
}