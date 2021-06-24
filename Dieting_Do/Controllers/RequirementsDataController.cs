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
    public class RequirementsDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Requirements
        public IQueryable<Requirements> GetRequirements()
        {
            return db.Requirements;
        }

        // GET: api/Requirements/5
        [ResponseType(typeof(Requirements))]
        public IHttpActionResult GetRequirements(int id)
        {
            Requirements requirements = db.Requirements.Find(id);
            if (requirements == null)
            {
                return NotFound();
            }

            return Ok(requirements);
        }

        // PUT: api/Requirements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequirements(int id, Requirements requirements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requirements.ReqId)
            {
                return BadRequest();
            }

            db.Entry(requirements).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequirementsExists(id))
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

        // POST: api/Requirements
        [ResponseType(typeof(Requirements))]
        public IHttpActionResult PostRequirements(Requirements requirements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Requirements.Add(requirements);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = requirements.ReqId }, requirements);
        }

        // DELETE: api/Requirements/5
        [ResponseType(typeof(Requirements))]
        public IHttpActionResult DeleteRequirements(int id)
        {
            Requirements requirements = db.Requirements.Find(id);
            if (requirements == null)
            {
                return NotFound();
            }

            db.Requirements.Remove(requirements);
            db.SaveChanges();

            return Ok(requirements);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequirementsExists(int id)
        {
            return db.Requirements.Count(e => e.ReqId == id) > 0;
        }
    }
}