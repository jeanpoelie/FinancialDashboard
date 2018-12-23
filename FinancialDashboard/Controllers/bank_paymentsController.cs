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
using FinancialDashboard;

namespace FinancialDashboard.Controllers
{
    public class bank_paymentsController : ApiController
    {
        private test_paymentsEntities db = new test_paymentsEntities();

        // GET: api/bank_payments
        public IQueryable<bank_payments> Getbank_payments()
        {
            return db.bank_payments;
        }

        // GET: api/bank_payments/5
        [ResponseType(typeof(bank_payments))]
        public IHttpActionResult Getbank_payments(int id)
        {
            bank_payments bank_payments = db.bank_payments.Find(id);
            if (bank_payments == null)
            {
                return NotFound();
            }

            return Ok(bank_payments);
        }

        // PUT: api/bank_payments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbank_payments(int id, bank_payments bank_payments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bank_payments.Id)
            {
                return BadRequest();
            }

            db.Entry(bank_payments).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bank_paymentsExists(id))
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

        // POST: api/bank_payments
        [ResponseType(typeof(bank_payments))]
        public IHttpActionResult Postbank_payments(bank_payments bank_payments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.bank_payments.Add(bank_payments);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bank_payments.Id }, bank_payments);
        }

        // DELETE: api/bank_payments/5
        [ResponseType(typeof(bank_payments))]
        public IHttpActionResult Deletebank_payments(int id)
        {
            bank_payments bank_payments = db.bank_payments.Find(id);
            if (bank_payments == null)
            {
                return NotFound();
            }

            db.bank_payments.Remove(bank_payments);
            db.SaveChanges();

            return Ok(bank_payments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool bank_paymentsExists(int id)
        {
            return db.bank_payments.Count(e => e.Id == id) > 0;
        }
    }
}