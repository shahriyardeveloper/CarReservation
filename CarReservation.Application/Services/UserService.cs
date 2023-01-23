using AutoMapper;
using CarReservation.Application.DTOs;
using CarReservation.Application.Helpers;
using CarReservation.Application.Interfaces;
using CarReservation.Application.Interfaces.Repositories;
using CarReservation.Application.Interfaces.Services;
using CarReservation.Application.Wrappers;
using CarReservation.Domain.Entities;

namespace CarReservation.Application.Services;

public class UserService : IUserService
{
    #region Fields

    private readonly IUnitOfWork unitOfWork;
    private readonly IGenericRepository<User> userRepository;

    #endregion Fields

    #region CTOR

    public UserService(IUnitOfWork unitOfWork, IGenericRepository<User> userRepository)
    {
        this.unitOfWork = unitOfWork;
        this.userRepository = userRepository;
    }

    #endregion CTOR

    public async Task<Response<User>> GetUser(string email, string password)
    {
        var users = await userRepository.GetAllAsync();
        var user = users.Where(l => l.Email == email && l.Password == PasswordHelper.Encrypt(password)).FirstOrDefault();
        if (user == null)
            return new Response<User>(false, "Email and password is incorrect");
        if (user.IsDeleted == true)
            return new Response<User>(false, "User is deactive");

        return new Response<User>(user, "Successful operation");
    }

    public async Task<Response<UserDTO>> AddUser(UserDTO userDTO)
    {
        if (userDTO.Password != userDTO.ConfirmPassword)
            return new Response<UserDTO>(false, "User is deactive");

        User user = new()
        {
            FirstName = userDTO.FirstName,
            LastName = userDTO.LastName,
            Email = userDTO.Email,
            Password = PasswordHelper.Encrypt(userDTO.Password),
            ConfirmPassword = PasswordHelper.Encrypt(userDTO.ConfirmPassword),
            IsAdmin = userDTO.IsAdmin,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        await userRepository.AddAsync(user);
        await unitOfWork.CommitAsync();
        return new Response<UserDTO>(userDTO, "Successful operation");
    }
}

