using HospitalManagment.Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagment.Library.Dtos
{
    public class PatientsDto
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public Epilepsy Epilepsy { get; set; } = Epilepsy.Yes;
        public int DiseaseID { get; set; }
       
        public string DiseaseName { get; set; }
        // public int NCDID { get; set; }
        // public int AllergiesID { get; set; }

        //public virtual ICollection<Allergies> Allergiess { get; set; } = new List<Allergies>();
        // public virtual ICollection<NCD> NCDs { get; set; } = new List<NCD>();
    }

}
