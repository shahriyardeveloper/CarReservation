﻿namespace CarReservation.Application.DTOs;
public class UserDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public bool IsAdmin { get; set; }
}
