using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using roboapi.Models;

namespace roboapi.Controllers
{
    public class CabecasController : ApiController
    {
        private context db = new context();

        // GET: api/Cabecas
        [Route("robo/GetAllCabecaTeste")]
        [HttpGet]
        public IQueryable<Cabeca> GetCabecas()
        {
            return db.Cabecas;
        }

        // GET: api/Cabecas/5
        [ResponseType(typeof(Cabeca))]
        public async Task<IHttpActionResult> GetCabeca(int id)
        {
            Cabeca cabeca = await db.Cabecas.FindAsync(id);
            if (cabeca == null)
            {
                return NotFound();
            }

            return Ok(cabeca);
        }

        // PUT: api/Cabecas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCabeca(int id, Cabeca cabeca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cabeca.Id)
            {
                return BadRequest();
            }

            db.Entry(cabeca).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabecaExists(id))
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

        // POST: api/dbCabeca
        [Route("robo/PostCabecaTeste")]
        [HttpPost]
        public async Task<IHttpActionResult> PostCabecaTeste()
        {
            Cabeca teste = new Cabeca();
            teste.Inclinacao = 0;
            teste.Rotacao = 1;
            db.Cabecas.Add(teste);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = teste.Id }, teste);
        }

        // POST: api/Cabecas
        [ResponseType(typeof(Cabeca))]
        public async Task<IHttpActionResult> PostCabeca(Cabeca cabeca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cabecas.Add(cabeca);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cabeca.Id }, cabeca);
        }

        // DELETE: api/Cabecas/5
        [ResponseType(typeof(Cabeca))]
        public async Task<IHttpActionResult> DeleteCabeca(int id)
        {
            Cabeca cabeca = await db.Cabecas.FindAsync(id);
            if (cabeca == null)
            {
                return NotFound();
            }

            db.Cabecas.Remove(cabeca);
            await db.SaveChangesAsync();

            return Ok(cabeca);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CabecaExists(int id)
        {
            return db.Cabecas.Count(e => e.Id == id) > 0;
        }
    }
}