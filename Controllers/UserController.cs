using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PracticalTask.Helper;
using PracticalTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PracticalTask.Controllers
{
    public class UserController : Controller
    {
        HelperApi _api = new HelperApi();
        List <UserViewModel> userViewModels = new List<UserViewModel>();
        ProfileInfoViewModel profileInfoViewModel = new ProfileInfoViewModel();
        Root root;

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            return View();
        }

        public async Task<IActionResult> GetTableData()
        {
            var result = "";
            HttpClient client = _api.Initial();

            HttpResponseMessage res1 = await client.GetAsync("/api");
            if (res1.IsSuccessStatusCode)
            {
                result = res1.Content.ReadAsStringAsync().Result;
                root = JsonConvert.DeserializeObject<Root>(result);

                foreach(var i in root.results)
                {
                    userViewModels.Add(new UserViewModel { first = i.name.first, last = i.name.last, gender = i.gender, date = i.dob.date, email = i.email, country = i.location.country, thumbnail = i.picture.thumbnail});
                }
            }
            return Json(new { data = userViewModels });
        }

        public async Task<IActionResult> ProfileInformation()
        {
            var result = "";
            HttpClient client = _api.Initial();
            HttpResponseMessage res1 = await client.GetAsync("/api");
            if (res1.IsSuccessStatusCode)
            {
                result = res1.Content.ReadAsStringAsync().Result;
                root = JsonConvert.DeserializeObject<Root>(result);

                profileInfoViewModel.uuid = root.results[0].login.uuid;
                profileInfoViewModel.username = root.results[0].login.username;
                profileInfoViewModel.password = root.results[0].login.password;
                profileInfoViewModel.date = root.results[0].registered.date;
                profileInfoViewModel.age = root.results[0].registered.age;
                
            }
            return Json(new { data = profileInfoViewModel });
        }
    }
}
