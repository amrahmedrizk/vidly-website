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
    public class customersController : ApiController
    {
        ApplicationDbContext db;
        public customersController()
        {
            db = new ApplicationDbContext();
        }
        public IHttpActionResult getcustomers(string query=null)
        {
            var customersquery = db.customers.Include(c => c.membershiptype);
            if(!String.IsNullOrWhiteSpace(query))
            {
                customersquery = customersquery.Where(c => c.name.Contains(query));
            }
            var customer = customersquery.ToList().Select(Mapper.Map<customer,customerdto>);
            return Ok(customer);
        }
        public IHttpActionResult getcustomer(int id)
        {
            var customer = db.customers.Include(m=>m.membershiptype).SingleOrDefault(a => a.id == id);
            if (customer==null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<customer,customerdto>(customer));
        }
        [HttpPost]
        public IHttpActionResult createcustomer(customerdto customerdto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<customerdto, customer>(customerdto);
            db.customers.Add(customer);
            db.SaveChanges();
            customerdto.id = customer.id;
            return Created(new Uri(Request.RequestUri + "/" + customer.id), customerdto);
        }
        [HttpPut]
        public void updatecustomer(int id,customerdto customerdto)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerindb = db.customers.SingleOrDefault(m => m.id == id);
            if(customerindb==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map<customerdto, customer>(customerdto, customerindb);
            db.SaveChanges();
        }

        [HttpDelete]
        public void deletecustomer(int id)
        {
            var customer = db.customers.SingleOrDefault(m => m.id == id);
            if(customer==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.customers.Remove(customer);
            db.SaveChanges();

        }
    }
}
