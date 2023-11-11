

using HospitalManagment.Library.Domain;

namespace HospitalManagement.Api.Repository
{
    public interface IDiseaseRepo
    {
        Task<IEnumerable<Disease>> GetDiseasesAsync();
        Task<Disease> GetDiseaseyAsync(int id);
        Task<Disease> AddDiseaseAsync(Disease disease);
        Task UpdateDiseaseAsync(Disease disease);       
        Task DeleteDiseaseAsync(int id);
    }
}
