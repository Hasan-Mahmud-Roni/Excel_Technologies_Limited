
using HospitalManagement.Api.Repository;
using HospitalManagment.Library.Domain;
using HospitalManagment.Library.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepo _patientRepo;

        public PatientsController(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] Patient requestModel)
        {
            try
            {
                var patient = await _patientRepo.CreatePatientAsync(requestModel.Name, requestModel.Epilepsy, requestModel.DiseaseID);
                return CreatedAtAction("GetPatient", new { id = patient.PatientID }, patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] Patient requestModel)
        {
            try
            {
                var patient = await _patientRepo.UpdatePatientAsync(id, requestModel.Name, requestModel.Epilepsy, requestModel.DiseaseID);
                if (patient == null)
                {
                    return NotFound();
                }

                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _patientRepo.GetPatientByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientsDto>>> GetAllPatients()
        {
            var patients = await _patientRepo.GetAllPatientAsync();
            return Ok(patients);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                await _patientRepo.DeletePatientAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
