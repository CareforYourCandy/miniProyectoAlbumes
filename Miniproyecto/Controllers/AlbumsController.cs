using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Miniproyecto.Models;
using Newtonsoft.Json;

namespace Miniproyecto.Controllers
{
    public class AlbumsController : Controller
    {
        static HttpClient client = new HttpClient();

        private readonly MiniproyectoContext _context;

        public AlbumsController(MiniproyectoContext context)
        {
            _context = context;
        }

        // GET: Albums
        public async Task<IActionResult> Index()
        {

            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("albums");


            var responseString = await response.Content.ReadAsStringAsync();

            List<Album> Albums = JsonConvert.DeserializeObject<List<Album>>(responseString);


            client.CancelPendingRequests();

            return View(Albums);





        }

        // GET: Albums/Details/5

     

        // GET: Albums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,userId,title")] Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }


        public ActionResult redirectPhotos(int refAlbum)
        {
            return RedirectToAction("Index", "Photos", new { albumId = refAlbum });
        }



    }
}

