using Microsoft.AspNetCore.Mvc;
using Mission6Assignment.Models;
using System.Diagnostics;

namespace Mission6Assignment.Controllers
{
    public class HomeController : Controller
    {
        private FormContext _context;
        public HomeController(FormContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult Form(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(movie);
            }

            if (movie.MovieId == 0)
                _context.Movies.Add(movie);
            else
                _context.Movies.Update(movie);

            _context.SaveChanges();
            return RedirectToAction("List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult List()
        {
            try
            {
                if (_context == null)
                {
                    return Content("_context is NULL");
                }

                if (_context.Movies == null)
                {
                    return Content("_context.Movies is NULL");
                }

                var movies = _context.Movies.ToList();
                return View(movies);
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var movie = _context.Movies.Find(id);
            if (movie == null)
                return NotFound();
            return View("Form", movie);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
