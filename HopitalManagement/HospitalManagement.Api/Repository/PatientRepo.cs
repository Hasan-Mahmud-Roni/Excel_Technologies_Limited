
using HospitalManagement.Api.Context;
using HospitalManagment.Library.Domain;
using HospitalManagment.Library.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Api.Repository
{
    public class PatientRepo : IPatientRepo
    {
        private readonly AppDbContext _db;

        public PatientRepo(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Patient> CreatePatientAsync(string name, Epilepsy epilepsy, int diseaseID)
        {
            var patient = new Patient()
            {
                Name = name,
                Epilepsy = epilepsy,
                DiseaseID = diseaseID
            };
            _db.Patients.Add(patient);
            await _db.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> UpdatePatientAsync(int id, string name, Epilepsy epilepsy, int diseaseID)
        {
            var patient = await _db.Patients.FindAsync(id);

            if (patient == null)
            {
                return null;
            }

            patient.Name = name;
            patient.Epilepsy = epilepsy;
            patient.DiseaseID = diseaseID;
          

            _db.Patients.Update(patient);
            await _db.SaveChangesAsync();

            return patient;

        }

        public async Task<List<PatientsDto>> GetAllPatientAsync()
        {
            var paitents = await _db.Patients
                 .Include(p => p.Disease)
                 
                 .Select(p => new PatientsDto
                 {
                     PatientID = p.PatientID,
                     Name = p.Name,
                     Epilepsy = p.Epilepsy,
                     DiseaseID = p.Disease.DiseaseID,
                   
                     DiseaseName = p.Disease.DiseaseName
                 })
                 .ToListAsync();

            return paitents;
        }

        public async Task<PatientsDto> GetPatientByIdAsync(int id)
        {
            var patientDto = await _db.Patients
                .Where(p => p.PatientID == id)
                .Select(p => new PatientsDto
                {
                    PatientID = p.PatientID,
                    Name = p.Name,
                   
                    DiseaseID = p.Disease.DiseaseID,
                  
                    DiseaseName = p.Disease.DiseaseName,
                   
                })
                .SingleOrDefaultAsync();

            return patientDto;
        }
        public async Task DeletePatientAsync(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient==null )
            {
                throw new ArgumentException("Patients not found");
            }
            _db.Patients.Remove(patient);
            await _db.SaveChangesAsync();
        }

       

        
    }
}
