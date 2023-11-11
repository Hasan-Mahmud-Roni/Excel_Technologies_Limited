

using HospitalManagment.Library.Domain;
using HospitalManagment.Library.Dtos;

namespace HospitalManagement.Api.Repository
{
    public interface IPatientRepo
    {
        Task<Patient> CreatePatientAsync(string name, Epilepsy epilepsy, int diseaseID);
        Task<Patient> UpdatePatientAsync(int id, string name, Epilepsy epilepsy, int diseaseID);
        Task<PatientsDto> GetPatientByIdAsync(int id);
        Task<List<PatientsDto>> GetAllPatientAsync();
        Task DeletePatientAsync(int id);
    }
}
