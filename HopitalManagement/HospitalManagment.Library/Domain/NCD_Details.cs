using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagment.Library.Domain
{
    public class NCD_Details
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int? NCDID { get; set; }
    }
}
