using CarReservation.Application.Wrappers;
using CarReservation.Domain.Entities;
using CarReservation.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarReservation.Controllers
{
    public class AccountController : Controller
    {

        private readonly HttpService _httpService;

        public AccountController(HttpService httpService)
        {
            _httpService = httpService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            User user = new();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            Dictionary<string,string> Queries = new Dictionary<string,string>();
            Queries.Add("email", user.Email);
            Queries.Add("password", user.Password);
            var responseString = await _httpService.PostMethodWithQueryParamter(Queries, "Account/Login");
            Response<User>? currentuser = JsonConvert.DeserializeObject<Response<User>>(responseString);
            if (currentuser != null)
            {
                HttpContext.Session.SetString("currentuser", JsonConvert.SerializeObject(currentuser.Data));
                return RedirectToAction("Index", "Booking");
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Register()
        {
            User user = new();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            HttpResponseMessage response =  await _httpService.PostMethodHttpClient(user, "Account/Register");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Response<User>? currentuser = JsonConvert.DeserializeObject<Response<User>>(data);
                HttpContext.Session.SetString("currentuser", JsonConvert.SerializeObject(currentuser.Data));
                return RedirectToAction("Index", "Booking");
            }
            return View();
        }
    }
}
