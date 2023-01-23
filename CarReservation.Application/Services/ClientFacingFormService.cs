using CarReservation.Application.DTOs;
using CarReservation.Application.Interfaces;
using CarReservation.Application.Interfaces.Repositories;
using CarReservation.Application.Interfaces.Services;
using CarReservation.Application.Wrappers;
using CarReservation.Domain.Entities;
using System.Data;

namespace CarReservation.Application.Services
{
    public class ClientFacingFormService : IClientFacingFormService
    {
        #region Fields

        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<ClientFacingForm> clientRepository;

        #endregion Fields

        #region CTOR

        public ClientFacingFormService(IUnitOfWork unitOfWork, IGenericRepository<ClientFacingForm> clientRepository)
        {
            this.unitOfWork = unitOfWork;
            this.clientRepository = clientRepository;
        }

        #endregion CTOR

        public async Task<Response<ClientFacingFormDTO>> AddEmployeeAsync(ClientFacingFormDTO employeeDTO)
        {
            ClientFacingForm client = new ClientFacingForm()
            {
                BookingDate = employeeDTO.BookingDate,
                VehicleSize = employeeDTO.VehicleSize,
                ContactNumber = employeeDTO.ContactNumber,
                CreatedDate = DateTime.Now,
                EmailAddress = employeeDTO.EmailAddress,
                Flexibility = employeeDTO.Flexibility,
                IsDeleted = false,
                Name = employeeDTO.Name,
                Status = employeeDTO.Status,
            };
            await clientRepository.AddAsync(client);
            await unitOfWork.CommitAsync();
            return new Response<ClientFacingFormDTO>(employeeDTO, "Successful operation");
        }

        public Response<bool> DeleteBooking(int id)
        {
            var Bookings = GetAllEmployeeAsync();

            var booking = Bookings.Result.Data.FirstOrDefault(b => b.Id == id);

            if(booking == null)
            {
                return new Response<bool>(false, "Booking Not Found");
            }
            clientRepository.Delete(booking);
            unitOfWork.CommitAsync();
            return new Response<bool>(true, "Booking Deleted");
        }
        public Response<bool> ComfirmBooking(int id)
        {
            var Bookings = GetAllEmployeeAsync();

            var booking = Bookings.Result.Data.FirstOrDefault(b => b.Id == id);

            booking.Status = 1;

            if(booking == null)
            {
                return new Response<bool>(false, "Booking Not Found");
            }
            clientRepository.Update(booking);
            unitOfWork.CommitAsync();
            return new Response<bool>(true, "Booking Deleted");
        }

        public Response<ClientFacingForm> GetBookingByID(int id)
        {
            var Bookings = GetAllEmployeeAsync();

            var booking = Bookings.Result.Data.FirstOrDefault(b => b.Id == id);

            if (booking == null)
            {
                return new Response<ClientFacingForm>(null, "Booking Not Found");
            }
            return new Response<ClientFacingForm>(booking, "Successfull operation");
        }

        public async Task<Response<ClientFacingFormDTO>> UpdateBooking(ClientFacingFormDTO employeeDTO)
        {
            var Bookings = GetAllEmployeeAsync();

            var booking = Bookings.Result.Data.FirstOrDefault(b => b.Id == employeeDTO.Id);

            if(booking == null)
            {
                return new Response<ClientFacingFormDTO>(employeeDTO, "Booking Not Found");
            }
            var ClienFactoryForm = new ClientFacingForm()
            {
                Id = employeeDTO.Id,
                BookingDate = employeeDTO.BookingDate,
                ContactNumber = employeeDTO.ContactNumber,
                EmailAddress = employeeDTO.EmailAddress,
                Flexibility = employeeDTO.Flexibility,
                Name = employeeDTO.Name,
                Status = employeeDTO.Status,
                VehicleSize = employeeDTO.VehicleSize,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            clientRepository.Update(ClienFactoryForm);
            await unitOfWork.CommitAsync();
            return new Response<ClientFacingFormDTO>(employeeDTO, "Booking Updated");
        }

        public  async Task<Response<IReadOnlyList<ClientFacingForm>>> GetAllEmployeeAsync()
        {
            var Clients = await clientRepository.GetAllAsync();
            return new Response<IReadOnlyList<ClientFacingForm>>(Clients, "Successful operation");
        }
    }
}
