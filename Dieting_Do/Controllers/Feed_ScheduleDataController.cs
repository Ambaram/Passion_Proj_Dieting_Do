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
    public class Feed_ScheduleDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Feed_ScheduleData
        public IQueryable<Feed_Schedule> GetFeed_Schedule()
        {
            return db.Feed_Schedule;
        }

        // GET: api/Feed_ScheduleData/5
        [ResponseType(typeof(Feed_Schedule))]
        public IHttpActionResult GetFeed_Schedule(int id)
        {
            Feed_Schedule feed_Schedule = db.Feed_Schedule.Find(id);
            if (feed_Schedule == null)
            {
                return NotFound();
            }

            return Ok(feed_Schedule);
        }

        // PUT: api/Feed_ScheduleData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeed_Schedule(int id, Feed_Schedule feed_Schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feed_Schedule.SchedId)
            {
                return BadRequest();
            }

            db.Entry(feed_Schedule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Feed_ScheduleExists(id))
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

        // POST: api/Feed_ScheduleData
        [ResponseType(typeof(Feed_Schedule))]
        public IHttpActionResult PostFeed_Schedule(Feed_Schedule feed_Schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Feed_Schedule.Add(feed_Schedule);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = feed_Schedule.SchedId }, feed_Schedule);
        }

        // DELETE: api/Feed_ScheduleData/5
        [ResponseType(typeof(Feed_Schedule))]
        public IHttpActionResult DeleteFeed_Schedule(int id)
        {
            Feed_Schedule feed_Schedule = db.Feed_Schedule.Find(id);
            if (feed_Schedule == null)
            {
                return NotFound();
            }

            db.Feed_Schedule.Remove(feed_Schedule);
            db.SaveChanges();

            return Ok(feed_Schedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Feed_ScheduleExists(int id)
        {
            return db.Feed_Schedule.Count(e => e.SchedId == id) > 0;
        }
    }
}