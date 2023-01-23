using CarReservation.Application.DTOs;
using CarReservation.Application.Wrappers;
using CarReservation.Domain.Entities;

namespace CarReservation.Application.Interfaces.Services;

public interface IUserService
{
    Task<Response<User>> GetUser(string email, string password);
    Task<Response<UserDTO>> AddUser(UserDTO regionDTO);
}

