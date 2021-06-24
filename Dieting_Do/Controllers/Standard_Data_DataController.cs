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
    public class Standard_Data_DataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Standard_Data_Data
        public IQueryable<Standard_Data> GetStandard_Data()
        {
            return db.Standard_Data;
        }

        // GET: api/Standard_Data_Data/5
        [ResponseType(typeof(Standard_Data))]
        public IHttpActionResult GetStandard_Data(int id)
        {
            Standard_Data standard_Data = db.Standard_Data.Find(id);
            if (standard_Data == null)
            {
                return NotFound();
            }

            return Ok(standard_Data);
        }

        // PUT: api/Standard_Data_Data/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStandard_Data(int id, Standard_Data standard_Data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != standard_Data.DataId)
            {
                return BadRequest();
            }

            db.Entry(standard_Data).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Standard_DataExists(id))
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

        // POST: api/Standard_Data_Data
        [ResponseType(typeof(Standard_Data))]
        public IHttpActionResult PostStandard_Data(Standard_Data standard_Data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Standard_Data.Add(standard_Data);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = standard_Data.DataId }, standard_Data);
        }

        // DELETE: api/Standard_Data_Data/5
        [ResponseType(typeof(Standard_Data))]
        public IHttpActionResult DeleteStandard_Data(int id)
        {
            Standard_Data standard_Data = db.Standard_Data.Find(id);
            if (standard_Data == null)
            {
                return NotFound();
            }

            db.Standard_Data.Remove(standard_Data);
            db.SaveChanges();

            return Ok(standard_Data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Standard_DataExists(int id)
        {
            return db.Standard_Data.Count(e => e.DataId == id) > 0;
        }
    }
}