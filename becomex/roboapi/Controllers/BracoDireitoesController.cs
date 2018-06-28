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



        /////////////////////////////////////////////////////////////////////
        //                                                                 //
        //                                                                 //
        //                           braco direito                         //
        //                                                                 //
        //                                                                 //
        //                                                                 //
        /////////////////////////////////////////////////////////////////////

        // 0 = Em Repouso
        // 1 = Levemente Contraído
        // 2 = Contraído
        // 3 = Fortemente Contraído


        /////////////////////////////////////////////////////////////////////
        //                                                                 //
        //                                                                 //
        //                        Cotovelo direito                         //
        //                                                                 //
        //                                                                 //
        //                                                                 //
        /////////////////////////////////////////////////////////////////////



        [Route("robo/ContrairBracoDireito")]
        [HttpPost]
        public async Task<IHttpActionResult> ContrairBracoDireito()
        {
            try
            {
                var bDireito = db.BracoDireitoes.ToList().LastOrDefault();
                if (bDireito.Cotovelo <= 2)
                {
                    BracoDireito item = new BracoDireito();
                    item.Cotovelo = bDireito.Cotovelo + 1;
                    item.Pulso = bDireito.Pulso;
                    db.BracoDireitoes.Add(item);
                    await db.SaveChangesAsync();
                    return Ok(GetSituacaoAtual());
                }
                return BadRequest();
            }
            catch (WebException we)
            {
                return BadRequest(we.Message);
            }
        }


        [Route("robo/DescontrairBracoDireito")]
        [HttpPost]
        public async Task<IHttpActionResult> DescontrairBracoDireito()
        {
            try
            {
                var bDireito = db.BracoDireitoes.ToList().LastOrDefault();
                if (bDireito.Cotovelo >= 1)
                {
                    BracoDireito item = new BracoDireito();
                    item.Cotovelo = bDireito.Cotovelo - 1;
                    item.Pulso = bDireito.Pulso;
                    db.BracoDireitoes.Add(item);
                    await db.SaveChangesAsync();
                    return Ok(GetSituacaoAtual());
                }
                return BadRequest();
            }
            catch (WebException we)
            {
                return BadRequest(we.Message);
            }
        }



        //Rotação para -90º
        //Rotação para -45º
        //Em Repouso
        //Rotação para 45º
        //Rotação para 90º
        //Rotação para 135º
        //Rotação para 180º

        /////////////////////////////////////////////////////////////////////
        //                                                                 //
        //                                                                 //
        //                           pulso direito                         //
        //                                                                 //
        //                                                                 //
        //                                                                 //
        /////////////////////////////////////////////////////////////////////


        [Route("robo/RotacaoBracoDireito")]
        [HttpPost]
        public async Task<IHttpActionResult> RotacaoBracoDireito()
        {
            try
            {
                var bDireito = db.BracoDireitoes.ToList().LastOrDefault();
                if (bDireito.Cotovelo == 3 && bDireito.Pulso < 180)
                {
                    BracoDireito item = new BracoDireito();
                    item.Cotovelo = bDireito.Cotovelo;
                    item.Pulso = bDireito.Pulso + 45;
                    db.BracoDireitoes.Add(item);
                    await db.SaveChangesAsync();
                    return Ok(GetSituacaoAtual());
                }
                return BadRequest();

            }
            catch (WebException we)
            {
                return BadRequest(we.Message);
            }
        }


        [Route("robo/RotacaoBracoDireitoAtni")]
        [HttpPost]
        public async Task<IHttpActionResult> RotacaoBracoDireitoAtni()
        {
            try
            {
                var bDireito = db.BracoDireitoes.ToList().LastOrDefault();
                if (bDireito.Cotovelo == 3 && bDireito.Pulso > -90)
                {
                    BracoDireito item = new BracoDireito();
                    item.Cotovelo = bDireito.Cotovelo;
                    item.Pulso = bDireito.Pulso - 45;
                    db.BracoDireitoes.Add(item);
                    await db.SaveChangesAsync();
                    return Ok(GetSituacaoAtual());
                }
                return BadRequest();
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