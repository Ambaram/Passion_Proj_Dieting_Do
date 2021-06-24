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
    public class AnimalsDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AnimalsData/ListAnimal
        [HttpGet]
        public IEnumerable<AnimalDto> ListAnimal()
        {
            List<Animal> Animals = db.Animal.ToList();
            List<AnimalDto> animalDtos = new List<AnimalDto>();
            Animals.ForEach(a => animalDtos.Add(new AnimalDto()
            {
                AnimalId = a.AnimalId,
                AnimalName = a.AnimalName,
                AnimalHeight = a.AnimalHeight,
                AnimalWeight = a.AnimalWeight,
                AnimalSpecies = a.Species.AnimalSpecies
            }));
            return animalDtos;
        }

        // GET: api/AnimalsData/AnimalDetails/5
        [ResponseType(typeof(Animal))]
        [HttpGet]
        public IHttpActionResult AnimalDetails(int id)
        {
            Animal animal = db.Animal.Find(id);
            AnimalDto AnimalDto = new AnimalDto()
            {
                AnimalId = animal.AnimalId,
                AnimalName = animal.AnimalName,
                AnimalHeight = animal.AnimalHeight,
                AnimalWeight = animal.AnimalWeight,
                AnimalSpecies = animal.Species.AnimalSpecies
            };
            if (animal == null)
            {
                return NotFound();
            }

            return Ok(AnimalDto);
        }

        // PUT: api/AnimalsData/UpdateAnimal/5
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateAnimal(int id, Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animal.AnimalId)
            {
                return BadRequest();
            }

            db.Entry(animal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
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

        // POST: api/AnimalsData/AddAnimal
        [ResponseType(typeof(Animal))]
        [HttpPost]
        public IHttpActionResult AddAnimal(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Animal.Add(animal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = animal.AnimalId }, animal);
        }

        // DELETE: api/AnimalsData/DeleteAimal/5
        [HttpPost]
        [ResponseType(typeof(Animal))]
        public IHttpActionResult DeleteAnimal(int id)
        {
            Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return NotFound();
            }

            db.Animal.Remove(animal);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnimalExists(int id)
        {
            return db.Animal.Count(e => e.AnimalId == id) > 0;
        }
    }
}