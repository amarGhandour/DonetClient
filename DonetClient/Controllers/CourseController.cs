using DonetClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DonetClient.Controllers
{
    public class CourseController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:8088/api/course");
            List<Course> courses = new List<Course>();

            if (responseMessage.IsSuccessStatusCode)
            {
                var data =  await responseMessage.Content.ReadAsStringAsync();

                courses = JsonSerializer.Deserialize<List<Course>>(data);
            }

            return View(courses);
        }


        public IActionResult GetAll()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:8088/api/topic");
            List<Topic> topics = new List<Topic>();

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();

                topics = JsonSerializer.Deserialize<List<Topic>>(data);
            }

            ViewData["topics"] = topics;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage message = await httpClient.PostAsJsonAsync("http://localhost:8088/api/course", course);

            if (message.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(course);

        }


   
        public async Task<IActionResult> CreateApi()
        {
         
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage message = await httpClient.DeleteAsync($"http://localhost:8088/api/course/{id}");

            if (message.IsSuccessStatusCode)
            {
                return Json(data: true);

            }
            return Json(data: false);
        }
    }
}
