using CarReservation.Application.DTOs;
using CarReservation.Application.Wrappers;
using CarReservation.Domain.Entities;
using CarReservation.Models;
using CarReservation.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace CarReservation.Controllers
{
    public class BookingController : Controller
    {

        private readonly HttpService _service;

        public BookingController(HttpService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            string? userjson = HttpContext.Session.GetString("currentuser");
            var user = JsonConvert.DeserializeObject<User>(userjson);
            var message = await _service.GetMethodHttpClient("Booking/GetAllBooking");
            var Clients = JsonConvert.DeserializeObject<Response<IReadOnlyList<ClientFacingForm>>>(message);
            ClaintFacingFormToUsers? common = new()
            {
                User = user,
                Client = Clients.Data
            };
            return View(common);
        }
        [HttpGet]
        public async Task<IActionResult> AddBooking()
        {
            ClientFacingForm client = new ClientFacingForm();
            return View(client);
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(ClientFacingFormDTO clientform)
        {
            HttpResponseMessage response = await _service.PostMethodHttpClient(clientform, "Booking/AddBooking");
            if (response.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            Dictionary<string, string> keyvalue = new();
            keyvalue.Add("id", id.ToString());
            var response = await _service.PostMethodWithQueryParamter(keyvalue,"Booking/DeleteBooking");
            Console.WriteLine(response);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            Dictionary<string, string> keyvalue = new();
            keyvalue.Add("id", id.ToString());
            var response = await _service.PostMethodWithQueryParamter(keyvalue, "Booking/GetBookingById");
            var booking = JsonConvert.DeserializeObject<Response<ClientFacingForm>>(response);
            return View(booking.Data);
        }
        [HttpGet]
        public async Task<IActionResult> ComfirmBooking(int id)
        {
            Dictionary<string, string> keyvalue = new();
            keyvalue.Add("id", id.ToString());
            var response = await _service.PostMethodWithQueryParamter(keyvalue, "Booking/ComfirmBooking");
            Console.WriteLine(response);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(ClientFacingForm booking)
        {
            HttpResponseMessage response  = await _service.PostMethodHttpClient(booking, "Booking/UpdateBooking");
            if (response.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}