using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.dtos;
using vidly.Models;

namespace vidly.Controllers.api
{
    public class moviesController : ApiController
    {
        ApplicationDbContext db;
        public moviesController()
        {
            db = new ApplicationDbContext();
        }
        public IHttpActionResult getmovies()
        {
            var movies = db.movies.Include(m=>m.genra).ToList().Select(Mapper.Map<movie, moviedto>);
            return Ok(movies);
        }
        public IHttpActionResult getmovie(int id)
        {
            var movie = db.movies.SingleOrDefault(m => m.id == id);
            if(movie==null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<movie, moviedto>(movie));
        }
        [HttpPost]
        public IHttpActionResult createmovie(moviedto moviedto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<moviedto, movie>(moviedto);
            db.movies.Add(movie);
            db.SaveChanges();
            moviedto.id = movie.id;
            return Created(new Uri(Request.RequestUri + "/" + movie.id), moviedto);

        }
        [HttpPut]
        public IHttpActionResult updatemovie(int id,moviedto moviedto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = db.movies.SingleOrDefault(m => m.id == id);
            if(movie==null)
            {
                return NotFound();
            }
            Mapper.Map<moviedto, movie>(moviedto, movie);
            //db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
            moviedto.id = movie.id;
            return Created(new Uri(Request.RequestUri + "/" + movie.id), moviedto);
        } 
        [HttpDelete]
        public void deletemovie(int id)
        {
            var movie = db.movies.SingleOrDefault(m => m.id == id);
            if(movie==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.movies.Remove(movie);
            db.SaveChanges();
        }
    }
}
