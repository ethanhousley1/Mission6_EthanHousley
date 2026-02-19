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
            return View();
        }
        [HttpPost]
        public IActionResult Form(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult List()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }
    }
}
