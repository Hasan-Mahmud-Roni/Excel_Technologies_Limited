
using HospitalManagement.Api.Repository;
using HospitalManagment.Library.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseaseRepo _diseaseRepo;

        public DiseasesController(IDiseaseRepo diseaseRepo)
        {
            _diseaseRepo = diseaseRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disease>>> GetDiseases()
        {
            var diseases = await _diseaseRepo.GetDiseasesAsync();
            return Ok(diseases);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Disease>> GetDisease(int id)
        {
            var disease = await _diseaseRepo.GetDiseaseyAsync(id);
            if (disease == null)
            {
                return NotFound();
            }

            return Ok(disease);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisease(int id, Disease disease)
        {
            if (id != disease.DiseaseID)
            {
                return BadRequest();
            }

            await _diseaseRepo.UpdateDiseaseAsync(disease);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Disease>> PostDisease(Disease disease)
        {
            var createdDisease = await _diseaseRepo.AddDiseaseAsync(disease);

            return CreatedAtAction("GetDisease", new { id = createdDisease.DiseaseID }, createdDisease);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisease(int id)
        {
            await _diseaseRepo.DeleteDiseaseAsync(id);

            return NoContent();
        }
    }
}
