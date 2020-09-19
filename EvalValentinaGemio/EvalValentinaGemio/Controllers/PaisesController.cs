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
using EvalValentinaGemio.Models;

namespace EvalValentinaGemio.Controllers
{
    public class PaisesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Paises
        public IQueryable<Paises> GetPaises()
        {
            return db.Paises;
        }

        // GET: api/Paises/5
        [ResponseType(typeof(Paises))]
        public IHttpActionResult GetPaises(int id)
        {
            Paises paises = db.Paises.Find(id);
            if (paises == null)
            {
                return NotFound();
            }

            return Ok(paises);
        }

        // PUT: api/Paises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaises(int id, Paises paises)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paises.GemioID)
            {
                return BadRequest();
            }

            db.Entry(paises).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisesExists(id))
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

        // POST: api/Paises
        [ResponseType(typeof(Paises))]
        public IHttpActionResult PostPaises(Paises paises)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paises.Add(paises);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paises.GemioID }, paises);
        }

        // DELETE: api/Paises/5
        [ResponseType(typeof(Paises))]
        public IHttpActionResult DeletePaises(int id)
        {
            Paises paises = db.Paises.Find(id);
            if (paises == null)
            {
                return NotFound();
            }

            db.Paises.Remove(paises);
            db.SaveChanges();

            return Ok(paises);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaisesExists(int id)
        {
            return db.Paises.Count(e => e.GemioID == id) > 0;
        }
    }
}