
using HospitalManagement.Api.Context;
using HospitalManagment.Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Api.Repository
{
    public class DiseaseRepo : IDiseaseRepo
    {
        private readonly AppDbContext _db;

        public DiseaseRepo(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Disease> AddDiseaseAsync(Disease disease)
        {
           _db.Diseases.Add(disease);
            await _db.SaveChangesAsync();
            return disease;
        }

        public async Task UpdateDiseaseAsync(Disease disease)
        {
            _db.Entry(disease).State=EntityState.Modified;
             await _db.SaveChangesAsync();
        }
        public async Task DeleteDiseaseAsync(int id)
        {
            var disease=await _db.Diseases.FindAsync(id);
            if (disease == null)
            {
                throw new ArgumentException("Disease not found");
            }
            _db.Diseases.Remove(disease);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Disease>> GetDiseasesAsync()
        {
            return await _db.Diseases.ToListAsync();
        }

        public async Task<Disease> GetDiseaseyAsync(int id)
        {
            return await _db.Diseases.FindAsync(id);
        }

       
    }
}
