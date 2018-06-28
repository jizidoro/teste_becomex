using roboapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace roboapi.Controllers
{
    public class RoboController : ApiController
    {
        private context db = new context();

        [Route("robo/get")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var allCabeca = db.Cabecas.ToList();
                var allBEsquerdo = db.BracoDireitoes.ToList();
                var allBDireito = db.BracoEsquerdoes.ToList();

                if (allCabeca.Count == 0)
                {
                    Cabeca item = new Cabeca();
                    item.Inclinacao = 0;
                    item.Rotacao = 0;
                    db.Cabecas.Add(item);
                    await db.SaveChangesAsync();
                }

                if (allBEsquerdo.Count == 0)
                {
                    BracoEsquerdo item = new BracoEsquerdo();
                    item.Cotovelo = 0;
                    item.Pulso = 0;
                    db.BracoEsquerdoes.Add(item);
                    await db.SaveChangesAsync();
                }

                if (allBDireito.Count == 0)
                {
                    BracoDireito item = new BracoDireito();
                    item.Cotovelo = 0;
                    item.Pulso = 0;
                    db.BracoDireitoes.Add(item);
                    await db.SaveChangesAsync();
                }

                var cabeca = db.Cabecas.ToList().LastOrDefault();
                var bDireito = db.BracoDireitoes.ToList().LastOrDefault();
                var bEsquerdo = db.BracoEsquerdoes.ToList().LastOrDefault();

                Robo robo = new Robo();
                robo.cabeca = cabeca;
                robo.bracoDireito = bDireito;
                robo.bracoEsquerdo = bEsquerdo;
                return Ok(robo);
            }
            catch (WebException we)
            {
                return BadRequest(we.Message);
            }
        }

        [Route("robo/reseta")]
        [HttpPost]
        public async Task<IHttpActionResult> Reseta()
        {
            try
            {
                foreach (var item in db.Cabecas)
                {
                    db.Cabecas.Remove(item);
                }

                foreach (var item in db.BracoDireitoes)
                {
                    db.BracoDireitoes.Remove(item);
                }

                foreach (var item in db.BracoEsquerdoes)
                {
                    db.BracoEsquerdoes.Remove(item);
                }

                await db.SaveChangesAsync();

                var cabeca = db.Cabecas.ToList();
                var bEsquerdo = db.BracoDireitoes.ToList();
                var bDireito = db.BracoEsquerdoes.ToList();

                if (cabeca.Count == 0)
                {
                    Cabeca item = new Cabeca();
                    item.Inclinacao = 0;
                    item.Rotacao = 0;
                    db.Cabecas.Add(item);
                    await db.SaveChangesAsync();
                }

                if (bEsquerdo.Count == 0)
                {
                    BracoEsquerdo item = new BracoEsquerdo();
                    item.Cotovelo = 0;
                    item.Pulso = 0;
                    db.BracoEsquerdoes.Add(item);
                    await db.SaveChangesAsync();
                }

                if (bDireito.Count == 0)
                {
                    BracoDireito item = new BracoDireito();
                    item.Cotovelo = 0;
                    item.Pulso = 0;
                    db.BracoDireitoes.Add(item);
                    await db.SaveChangesAsync();
                }


                return Ok(GetSituacaoAtual());
            }
            catch (WebException we)
            {
                return BadRequest(we.Message);
            }
        }

        public Robo GetSituacaoAtual()
        {
            var cabeca = db.Cabecas.ToList().LastOrDefault();
            var bDireito = db.BracoDireitoes.ToList().LastOrDefault();
            var bEsquerdo = db.BracoEsquerdoes.ToList().LastOrDefault();

            Robo robo = new Robo();
            robo.cabeca = cabeca;
            robo.bracoDireito = bDireito;
            robo.bracoEsquerdo = bEsquerdo;
            return robo;
        }
    }
}
