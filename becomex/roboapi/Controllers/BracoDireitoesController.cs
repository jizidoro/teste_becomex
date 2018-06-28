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
    public class BracoDireitoesController : ApiController
    {
        private context db = new context();

        // GET: api/BracoDireitoes
        public IQueryable<BracoDireito> GetBracoDireitoes()
        {
            return db.BracoDireitoes;
        }

        // GET: api/BracoDireitoes/5
        [ResponseType(typeof(BracoDireito))]
        public async Task<IHttpActionResult> GetBracoDireito(int id)
        {
            BracoDireito bracoDireito = await db.BracoDireitoes.FindAsync(id);
            if (bracoDireito == null)
            {
                return NotFound();
            }

            return Ok(bracoDireito);
        }

        // PUT: api/BracoDireitoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBracoDireito(int id, BracoDireito bracoDireito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bracoDireito.Id)
            {
                return BadRequest();
            }

            db.Entry(bracoDireito).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BracoDireitoExists(id))
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

        // POST: api/BracoDireitoes
        [ResponseType(typeof(BracoDireito))]
        public async Task<IHttpActionResult> PostBracoDireito(BracoDireito bracoDireito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BracoDireitoes.Add(bracoDireito);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bracoDireito.Id }, bracoDireito);
        }

        // DELETE: api/BracoDireitoes/5
        [ResponseType(typeof(BracoDireito))]
        public async Task<IHttpActionResult> DeleteBracoDireito(int id)
        {
            BracoDireito bracoDireito = await db.BracoDireitoes.FindAsync(id);
            if (bracoDireito == null)
            {
                return NotFound();
            }

            db.BracoDireitoes.Remove(bracoDireito);
            await db.SaveChangesAsync();

            return Ok(bracoDireito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BracoDireitoExists(int id)
        {
            return db.BracoDireitoes.Count(e => e.Id == id) > 0;
        }
    }
}