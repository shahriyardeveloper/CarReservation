using CarReservation.Application.DTOs;
using CarReservation.Application.Wrappers;
using CarReservation.Domain.Entities;

namespace CarReservation.Application.Interfaces.Services;

public interface IClientFacingFormService
{
    Task<Response<IReadOnlyList<ClientFacingForm>>> GetAllEmployeeAsync();
    Task<Response<ClientFacingFormDTO>> AddEmployeeAsync(ClientFacingFormDTO employeeDTO);
    Response<bool> DeleteBooking(int id);
    Task<Response<ClientFacingFormDTO>> UpdateBooking(ClientFacingFormDTO employeeDTO);
    Response<ClientFacingForm> GetBookingByID(int id);
    Response<bool> ComfirmBooking(int id);
}

