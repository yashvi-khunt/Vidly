using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vidly.Models;
using Vidly.ViewModels;


//for learning
//namespace Vidly.Controllers
//{
//    public class MoviesController : Controller
//    {
//        // GET: Movies/Random
//        public ActionResult Random()
//        {
//            var movie = new Movie() {Name = "Shrek!" };
//            var customers = new List<Customer>
//            {
//                new Customer{Id = 1, Name = "Customer 1"},
//                new Customer{Id = 2, Name = "Customer 2"}
//            };

//            var viewModel = new RandomMovieViewModel
//            {
//                Movie = movie,
//                Customers = customers
//            };


//            return View(viewModel);
//            //return Content("Hello World");
//            //return HttpNotFound();
//            //return new EmptyResult();
//            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});

//        }

//        public ActionResult Edit(int id) {
//            return Content("id = " + id);
//        }

//        public ActionResult Index(int? pageIndex, string sortBy)
//        {
//            if (!pageIndex.HasValue)
//            {
//                pageIndex = 1;
//            }
//            if (string.IsNullOrEmpty(sortBy))
//            {
//                sortBy = "Name";
//            }
//            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
//        }


//        //NEW METHOD FOR ROUTING
//        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
//        public ActionResult ByReleasedDate(int year, int month)
//        {
//            return Content(String.Format("{0} / {1}",year,month));
//        }
//    }
//}


//without databse connection
//namespace Vidly.Controllers
//{
//    public class MoviesController : Controller
//    {
//        public ActionResult Index()
//        {
            
//            var movies  = new List<Movie>
//            {
//                new Movie{Id =  1, Name = "Shrek"},
//                new Movie{Id = 2, Name = "Wall-e"}
//            };

//            //var movies = new List<Movie>();
//            var moviesViewModel = new MovieListViewModel { Movies = movies };
//            return View(moviesViewModel);
//        }
//    }
//}

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();


            return View(movies);

        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            return View(movies);
        }
    }
}


    
        

    
