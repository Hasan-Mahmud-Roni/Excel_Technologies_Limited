using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalManagment.Library.Domain
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientID { get; set; }
        public string Name { get; set; }
        public Epilepsy Epilepsy { get; set; } = Epilepsy.Yes;
        public int DiseaseID { get; set; }

        [JsonIgnore]
        public Disease? Disease { get; set; }
        // public virtual ICollection<Allergies> Allergiess { get; set; } = new List<Allergies>();
        // public virtual ICollection<NCD> NCDs { get; set; } = new List<NCD>();
    }
    public enum Epilepsy
    {
        Yes,
        No
    }
}
