using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientDemographicsApp.Models
{
    public class PatientViewModel
    {
        [Required(ErrorMessage ="Forename is Mandatory. A length of minimum character of 3 and maximum character of 50")]
        [StringLength(50, MinimumLength = 3)]
        public string Forename { get; set; }
        [Required(ErrorMessage = "Surname is Mandatory. A length of minimum character of 2 and maximum character of 50")]
        [StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }
        [Required(ErrorMessage = "Gender is Mandatory")]
        public string Gender { get; set; }
        public string HomeNumber { get; set; }
        public string WorkNumber { get; set; }
        public string MobileNumber { get; set; }
    }
}