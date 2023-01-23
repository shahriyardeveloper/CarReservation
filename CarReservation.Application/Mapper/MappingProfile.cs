using AutoMapper;
using CarReservation.Application.DTOs;
using CarReservation.Domain.Entities;

namespace CarReservation.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDTO, User>().ForMember(x => x.Id, c => c.Ignore());
        CreateMap<User, UserDTO>();

        CreateMap<ClientFacingFormDTO, ClientFacingForm>().ForMember(x => x.Id, c => c.Ignore());
        CreateMap<ClientFacingForm, ClientFacingFormDTO>();
    }
}

