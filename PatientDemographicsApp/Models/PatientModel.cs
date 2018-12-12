using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientDemographicsApp.Models
{
    public class PatientModel
    {
        public string Forename { get; set; }
        
        public string Surname { get; set; }
        
        public DateTime? DOB { get; set; }
        
        public string Gender { get; set; }

        public TelephoneNumbers TelephoneNumbers { get; set; }
    }
}