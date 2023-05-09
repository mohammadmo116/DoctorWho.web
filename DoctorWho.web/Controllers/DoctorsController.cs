using Microsoft.AspNetCore.Mvc;
using DoctorWho.Db;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories.Interfaces;
using DoctorWho.Db.DTOs;

using AutoMapper;


namespace DoctorWho.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorsRepository _doctors;

        public DoctorsController(
                                IMapper mapper, 
                                IDoctorsRepository doctors)
        {
            _mapper = mapper;
            _doctors = doctors;
        }

    
        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
        {
            var doctors = await _doctors.GetAllDoctorsAsync();
          if (doctors == null)
          {
              return NotFound();
          }
            return Ok(_mapper.Map<IEnumerable<DoctorDto>>(doctors));
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetDoctor(int id)
        {
            var doctor = await _doctors.GetDoctorAsync(id);
          if (doctor == null)
          {
              return NotFound();
          }
  
            return Ok(_mapper.Map<DoctorDto>(doctor));
        }

        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, DoctorUpsertDto doctorDto)
        {
            var doctor = await _doctors.GetDoctorAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            _mapper.Map(doctorDto, doctor);
            await _doctors.UpdateAsync(doctor);
           
            
          

            return NoContent();
        }

        // POST: api/Doctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(DoctorUpsertDto doctorDto)
        {
  
          var doctor=_mapper.Map<Doctor>(doctorDto);
         await _doctors.CreateAsyn(doctor);
     


            return CreatedAtAction("GetDoctor", new { id = doctor.DoctorId }, doctorDto);
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctors.GetDoctorAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            await _doctors.RemoveAsync(doctor);
          
            return NoContent();
        }

    }
}
