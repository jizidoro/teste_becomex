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
    public class BracoEsquerdoesController : ApiController
    {
        private context db = new context();

        // GET: api/BracoEsquerdoes
        public IQueryable<BracoEsquerdo> GetBracoEsquerdoes()
        {
            return db.BracoEsquerdoes;
        }

        // GET: api/BracoEsquerdoes/5
        [ResponseType(typeof(BracoEsquerdo))]
        public async Task<IHttpActionResult> GetBracoEsquerdo(int id)
        {
            BracoEsquerdo bracoEsquerdo = await db.BracoEsquerdoes.FindAsync(id);
            if (bracoEsquerdo == null)
            {
                return NotFound();
            }

            return Ok(bracoEsquerdo);
        }

        // PUT: api/BracoEsquerdoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBracoEsquerdo(int id, BracoEsquerdo bracoEsquerdo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bracoEsquerdo.Id)
            {
                return BadRequest();
            }

            db.Entry(bracoEsquerdo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BracoEsquerdoExists(id))
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

        // POST: api/BracoEsquerdoes
        [ResponseType(typeof(BracoEsquerdo))]
        public async Task<IHttpActionResult> PostBracoEsquerdo(BracoEsquerdo bracoEsquerdo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BracoEsquerdoes.Add(bracoEsquerdo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bracoEsquerdo.Id }, bracoEsquerdo);
        }

        // DELETE: api/BracoEsquerdoes/5
        [ResponseType(typeof(BracoEsquerdo))]
        public async Task<IHttpActionResult> DeleteBracoEsquerdo(int id)
        {
            BracoEsquerdo bracoEsquerdo = await db.BracoEsquerdoes.FindAsync(id);
            if (bracoEsquerdo == null)
            {
                return NotFound();
            }

            db.BracoEsquerdoes.Remove(bracoEsquerdo);
            await db.SaveChangesAsync();

            return Ok(bracoEsquerdo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BracoEsquerdoExists(int id)
        {
            return db.BracoEsquerdoes.Count(e => e.Id == id) > 0;
        }
    }
}