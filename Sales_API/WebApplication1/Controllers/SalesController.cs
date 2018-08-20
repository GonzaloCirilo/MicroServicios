using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SalesController : ApiController
    {
        private salesdbEntities db = new salesdbEntities();

        // GET: api/Sales
        public IQueryable<Object> GetSales()
        {
            return db.Sales.Take(50).Select(x => new {
                sales_id = x.SalesID,
                customer = x.Customers.FirstName + " " + x.Customers.LastName,
                salesperson = x.Employees.FirstName + " " + x.Employees.LastName,
                product = x.Products.Name,
                product_price = x.Products.Price,
                quantity = x.Quantity,
                
            });
        }

        // GET: api/Sales/5
        [ResponseType(typeof(Sales))]
        public IHttpActionResult GetSales(int id)
        {
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return NotFound();
            }
            Object sale = new
            {
                sales_id = sales.SalesID,
                customer = sales.Customers.FirstName + " " + sales.Customers.LastName,
                salesperson = sales.Employees.FirstName + " " + sales.Employees.LastName,
                product = sales.Products.Name,
                product_price = sales.Products.Price,
                quantity = sales.Quantity,

            };
            return Ok(sale);
        }

        // PUT: api/Sales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSales(int id, Sales sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sales.SalesID)
            {
                return BadRequest();
            }

            db.Entry(sales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Sales
        [ResponseType(typeof(Sales))]
        public IHttpActionResult PostSales(Sales sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sales.Add(sales);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sales.SalesID }, sales);
        }

        // DELETE: api/Sales/5
        [ResponseType(typeof(Sales))]
        public IHttpActionResult DeleteSales(int id)
        {
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return NotFound();
            }

            db.Sales.Remove(sales);
            db.SaveChanges();

            return Ok(sales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesExists(int id)
        {
            return db.Sales.Count(e => e.SalesID == id) > 0;
        }
    }
}