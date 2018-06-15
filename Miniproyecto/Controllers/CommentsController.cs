using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Miniproyecto.Models;
using Newtonsoft.Json;
using PeliApp.Models;

namespace Miniproyecto.Controllers
{
    public class CommentsController : Controller
    {
        private readonly MiniproyectoContext _context;
        static HttpClient client = new HttpClient();

        public CommentsController(MiniproyectoContext context)
        {
            _context = context;
        }

        // GET: Comments
        public async Task<IActionResult> Index(int refPhoto)
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("comments?" + $"albumId={refPhoto}");


            var responseString = await response.Content.ReadAsStringAsync();

            List<Comment> Comments = JsonConvert.DeserializeObject<List<Comment>>(responseString);



            return View(Comments);
          

        }

      
    }
}
