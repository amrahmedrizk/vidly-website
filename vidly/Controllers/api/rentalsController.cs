using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.dtos;
using vidly.Models;

namespace vidly.Controllers.api
{
    public class rentalsController : ApiController
    {
        ApplicationDbContext db;
        public rentalsController()
        {
            db = new ApplicationDbContext();

        }
        [HttpPost]
        public IHttpActionResult createnewrental(rentaldto rental)
        {
            //var customer = db.customers.SingleOrDefault(m => m.id == rental.customerid);
            //foreach (var a in rental.movieid)
            //{
            //    var movie = db.movies.SingleOrDefault(m => m.id == rental.movieid);

            //    var movie = db.movies.SingleOrDefault(m => m.id == a);
            //    if (movie.numberavailable == 0)
            //    {
            //        return BadRequest("movie" + movie.name + "is not available");
            //    }
            //    rental ren = new rental
            //    {
            //        customerid = customer.id,
            //        movieid = movie.id,
            //        rentdate = DateTime.Now,
            //        returndate = DateTime.Now
            //    };
            //    db.rentals.Add(ren);
            //    movie.numberavailable--;
            //}
            //db.SaveChanges();
            //return Ok();
            var customer = db.customers.Single(c => c.id == rental.customerid);
            var movies = db.movies.Where(m => rental.movieids.Contains(m.id)).ToList();
            foreach (var movie in movies)
            {
                if (movie.numberavailable == 0)
                    return BadRequest("Movie is not available.");
                movie.numberavailable--;
                var r = new rental
                {
                    customer = customer,
                    movie = movie,
                    rentdate = DateTime.Now
                };
                db.rentals.Add(r);
            }
            db.SaveChanges();
            return Ok();
        }
    }
}
