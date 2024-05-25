using AutoMapper;
using WAD._00014384.DAL.DTOs;
using WAD._00014384.DAL.Models;

namespace WAD._00014384.DAL.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.Attendees, opt => opt.MapFrom(src => src.Attendees));

            CreateMap<CreateEventDto, Event>();

            CreateMap<UpdateEventDto, Event>();

            CreateMap<Attendee, AttendeeDto>();

            CreateMap<CreateAttendeeDto, Attendee>();

            CreateMap<UpdateAttendeeDto, Attendee>();
        }
    }
}
