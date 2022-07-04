using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreKamp.Controllers
{
    public class EmpolyeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44319/api/Default");
            var jsonString=await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddEmploye()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmploye(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmploye=JsonConvert.SerializeObject(p);
            StringContent content= new StringContent(jsonEmploye,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44319/api/Default",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditEmploye(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44319/api/Default/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmploye = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonEmploye);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditEmploye(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmploye = JsonConvert.SerializeObject(p);
            var content=new StringContent(jsonEmploye,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44319/api/Default",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public async Task<IActionResult>DeleteEmploye(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44319/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
