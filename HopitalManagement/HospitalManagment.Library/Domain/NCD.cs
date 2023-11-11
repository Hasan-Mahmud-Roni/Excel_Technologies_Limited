using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagment.Library.Domain
{
    public class NCD
    {
        public int NCDID { get; set; }
        public string NCDName { get; set; }
        public Patient Patient { get; set; }
    }
}
