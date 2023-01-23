using CarReservation.Application.DTOs;
using CarReservation.Application.Interfaces.Services;
using CarReservation.Application.Services;
using CarReservation.Application.Wrappers;
using CarReservation.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace CarReservation.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [SwaggerTag("Create, read, update and delete Booking")]
    public class BookingController : ControllerBase
    {
        #region Fields

        private readonly IClientFacingFormService _clientService;

        #endregion Fields

        #region CTOR
        public BookingController(IClientFacingFormService clientService)
        {
            _clientService = clientService;
        }

        #endregion CTOR

        [HttpGet]
        [ProducesResponseType(typeof(Response<IReadOnlyList<ClientFacingForm>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<Response<IReadOnlyList<ClientFacingForm>>> GetAllBooking()
        {
            return await _clientService.GetAllEmployeeAsync();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response<ClientFacingFormDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<Response<ClientFacingFormDTO>> AddBooking(ClientFacingFormDTO clientFacing)
        {
            return await _clientService.AddEmployeeAsync(clientFacing);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response<ClientFacingFormDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public  Response<bool> DeleteBooking(int id)
        {
            return  _clientService.DeleteBooking(id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response<ClientFacingFormDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public Task<Response<ClientFacingFormDTO>> UpdateBooking(ClientFacingFormDTO employeeDTO)
        {
            return  _clientService.UpdateBooking(employeeDTO);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response<ClientFacingFormDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public Response<ClientFacingForm> GetBookingById(int id)
        {
            return  _clientService.GetBookingByID(id);
        }
        [HttpGet]
        [ProducesResponseType(typeof(Response<ClientFacingFormDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public Response<bool> ComfirmBooking(int id)
        {
            return  _clientService.ComfirmBooking(id);
        }
    }
}
