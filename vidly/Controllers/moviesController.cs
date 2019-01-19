using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.viewmodels;

namespace vidly.Controllers
{
    public class moviesController : Controller
    {
        ApplicationDbContext db;
        public moviesController()
        {
            db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        // GET: movies
        public ActionResult Index()
        {
            //var movie = db.movies.Include(c => c.genra).ToList();
            //return View(movie);
            if(User.IsInRole("canmanegemovies"))
            return View("index");
            return View("readonlylist");
        }
        public ActionResult details(int id)
        {
            var movie = db.movies.Include(f => f.genra).Where(a => a.id == id).SingleOrDefault();
            return View(movie);
        }
        [Authorize(Roles = "canmanegemovies")]
        public ActionResult New(int? id)
        {
            var movieview = new movieviewmodel();

            if (id == null)
            {

                movieview.movies = new movie();
                movieview.genra = db.genras.ToList();

            }
            else
            {
                movieview.movies = db.movies.SingleOrDefault(m => m.id == id);
                movieview.genra = db.genras.ToList();

            }
            return View("movieform", movieview);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult save(movieviewmodel movieview)
        {
            if(!ModelState.IsValid)
            {
                movieview.genra = db.genras.ToList();
                return View("movieform", movieview);
            }
            if(movieview.movies.id == 0)
            {
                movieview.movies.dateadded = DateTime.Now;
                var moviee = movieview.movies;
                db.movies.Add(moviee);
                db.SaveChanges();
            }
            else
            {
                var movieindb = db.movies.SingleOrDefault(m => m.id == movieview.movies.id);
                movieindb.name = movieview.movies.name;
                movieindb.numberinstock = movieview.movies.numberinstock;
                movieindb.releasedate = movieview.movies.releasedate;
                movieindb.genraid = movieview.movies.genraid;
                db.Entry(movieindb).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("index","movies");
        }
    }
}