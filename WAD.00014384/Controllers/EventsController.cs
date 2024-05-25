using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00014384.DAL.DTOs;
using WAD._00014384.DAL.Interfaces;
using WAD._00014384.DAL.Models;

namespace WAD._00014384.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventsController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        // GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            var events = await _eventRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<EventDto>>(events));
        }

        // GET: api/events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            var @event = await _eventRepository.GetByIdAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return _mapper.Map<EventDto>(@event);
        }

        // POST: api/events
        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateEvent(CreateEventDto createEventDto)
        {
            var @event = _mapper.Map<Event>(createEventDto);
            await _eventRepository.AddAsync(@event);
            return CreatedAtAction(nameof(GetEvent), new { id = @event.Id }, _mapper.Map<EventDto>(@event));
        }

        // PUT: api/events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, UpdateEventDto updateEventDto)
        {
            if (id != updateEventDto.Id)
            {
                return BadRequest();
            }

            var existingEvent = await _eventRepository.GetByIdAsync(id);

            if (existingEvent == null)
            {
                return NotFound();
            }

            _mapper.Map(updateEventDto, existingEvent);

            await _eventRepository.UpdateAsync(existingEvent);

            return NoContent();
        }

        // DELETE: api/events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var existingEvent = await _eventRepository.GetByIdAsync(id);

            if (existingEvent == null)
            {
                return NotFound();
            }

            await _eventRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
