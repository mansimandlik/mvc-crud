using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace practicemvc.Models
{
    public class Recruitment
    {   
        [Display(Name="Intern")]
        [Required(ErrorMessage ="Intern name should be provided")]
        [MaxLength(25)]
        public string intern { get; set; }

        [Display(Name = "Intern Id")]
        [Required(ErrorMessage = "Please provide Intern_Id")]
        public int Intern_id { get; set; }

        [MaxLength(25)]
        public string address { get; set; }
        [MaxLength(20)]

        public string technology { get; set; }
        public int experience { get; set; }
    }
}