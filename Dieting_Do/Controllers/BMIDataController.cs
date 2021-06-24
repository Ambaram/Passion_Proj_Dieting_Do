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
using Dieting_Do.Models;

namespace Dieting_Do.Controllers
{
    public class BMIDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BMIData/ListBMIData
        [HttpGet]
        public IQueryable<BMI> GetBodyMassIndex()
        {
            return db.BodyMassIndex;
        }

        // GET: api/BMIData/5
        [ResponseType(typeof(BMI))]
        public IHttpActionResult GetBMI(int id)
        {
            BMI bMI = db.BodyMassIndex.Find(id);
            if (bMI == null)
            {
                return NotFound();
            }

            return Ok(bMI);
        }

        // PUT: api/BMIData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBMI(int id, BMI bMI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bMI.BMIId)
            {
                return BadRequest();
            }

            db.Entry(bMI).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BMIExists(id))
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

        // POST: api/BMIData
        [ResponseType(typeof(BMI))]
        public IHttpActionResult PostBMI(BMI bMI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BodyMassIndex.Add(bMI);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bMI.BMIId }, bMI);
        }

        // DELETE: api/BMIData/5
        [ResponseType(typeof(BMI))]
        public IHttpActionResult DeleteBMI(int id)
        {
            BMI bMI = db.BodyMassIndex.Find(id);
            if (bMI == null)
            {
                return NotFound();
            }

            db.BodyMassIndex.Remove(bMI);
            db.SaveChanges();

            return Ok(bMI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BMIExists(int id)
        {
            return db.BodyMassIndex.Count(e => e.BMIId == id) > 0;
        }
    }
}