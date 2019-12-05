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
using Servicio_Web_REST_y_Entiy_Framwork_MOTOS.Models;
using System.Web.Http.Cors;

namespace Servicio_Web_REST_y_Entiy_Framwork_MOTOS.Controllers
{
    public class MotosController : ApiController
    {
        private ContextoMotos db = new ContextoMotos();

        [EnableCors(origins: "*", headers: "*", methods: "*")]

        // GET: api/Motos
        public IQueryable<Motos> GetMotos()
        {
            return db.Motos;
        }

        // GET: api/Motos/5
        [ResponseType(typeof(Motos))]
        public IHttpActionResult GetMotos(int id)
        {
            Motos motos = db.Motos.Find(id);
            if (motos == null)
            {
                return NotFound();
            }

            return Ok(motos);
        }

        // PUT: api/Motos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMotos(int id, Motos motos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motos.ID)
            {
                return BadRequest();
            }

            db.Entry(motos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotosExists(id))
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

        // POST: api/Motos
        [ResponseType(typeof(Motos))]
        public IHttpActionResult PostMotos(Motos motos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Motos.Add(motos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MotosExists(motos.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = motos.ID }, motos);
        }

        // DELETE: api/Motos/5
        [ResponseType(typeof(Motos))]
        public IHttpActionResult DeleteMotos(int id)
        {
            Motos motos = db.Motos.Find(id);
            if (motos == null)
            {
                return NotFound();
            }

            db.Motos.Remove(motos);
            db.SaveChanges();

            return Ok(motos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MotosExists(int id)
        {
            return db.Motos.Count(e => e.ID == id) > 0;
        }
    }
}