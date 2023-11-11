using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagment.Library.Domain
{
    public class Disease
    {
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public ICollection<Patient>? Patients { get; set; }
    }
}
