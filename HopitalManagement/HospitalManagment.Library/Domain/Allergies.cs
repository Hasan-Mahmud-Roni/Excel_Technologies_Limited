using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagment.Library.Domain
{
    public class Allergies
    {
        public int AllergiesID { get; set; }
        public string AllergiesName { get; set; }
        public Patient Patient { get; set; }
    }
}
