using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00014384.DAL.DTOs;
using WAD._00014384.DAL.Interfaces;
using WAD._00014384.DAL.Models;

namespace WAD._00014384.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        private readonly IAttendeeRepository _attendeeRepository;
        private readonly IMapper _mapper;

        public AttendeesController(IAttendeeRepository attendeeRepository, IMapper mapper)
        {
            _attendeeRepository = attendeeRepository;
            _mapper = mapper;
        }

        // GET: api/attendees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendeeDto>>> GetAttendees()
        {
            var attendees = await _attendeeRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AttendeeDto>>(attendees));
        }

        // GET: api/attendees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttendeeDto>> GetAttendee(int id)
        {
            var attendee = await _attendeeRepository.GetByIdAsync(id);

            if (attendee == null)
            {
                return NotFound();
            }

            return _mapper.Map<AttendeeDto>(attendee);
        }

        // POST: api/attendees
        [HttpPost]
        public async Task<ActionResult<AttendeeDto>> CreateAttendee(CreateAttendeeDto createAttendeeDto)
        {
            var attendee = _mapper.Map<Attendee>(createAttendeeDto);
            await _attendeeRepository.AddAsync(attendee);
            return Ok(_mapper.Map<AttendeeDto>(attendee));
        }

        // PUT: api/attendees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendee(int id, UpdateAttendeeDto updateAttendeeDto)
        {
            if (id != updateAttendeeDto.Id)
            {
                return BadRequest();
            }

            var existingAttendee = await _attendeeRepository.GetByIdAsync(id);

            if (existingAttendee == null)
            {
                return NotFound();
            }

            _mapper.Map(updateAttendeeDto, existingAttendee);

            await _attendeeRepository.UpdateAsync(existingAttendee);

            return NoContent();
        }

        // DELETE: api/attendees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendee(int id)
        {
            var existingAttendee = await _attendeeRepository.GetByIdAsync(id);

            if (existingAttendee == null)
            {
                return NotFound();
            }

            await _attendeeRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
