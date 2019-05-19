using Microsoft.AspNetCore.Mvc;
using MVCMovie.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovie.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _db;

        public HomeController(MovieContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MovieList(string searchString)
        {          
            if (!string.IsNullOrEmpty(searchString))
            {
                var movies = _db.Movies.Where(movie => movie.Title.Contains(searchString));
                return View(movies);
            }
            else
            {
                var movies = _db.Movies.OrderBy(x => x.Title).ToArray();
                return View(movies);
            }
           
           
        }

        [HttpGet, Route("create")]
        public ActionResult Create()
        {          
            return View();
        }
        [HttpPost, Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Add(movie);
                _db.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                return View(movie);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _db.Movies.FindAsync(id);
            if(movie == null)
            {
                return NotFound();
            }
            else
            {
                return View(movie);
            }
        }
        
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Update(movie);
                _db.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                return View(movie);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _db.Movies.FindAsync(id);
            _db.Remove(movie);
            _db.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}