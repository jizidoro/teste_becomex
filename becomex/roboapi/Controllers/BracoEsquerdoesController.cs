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


        /////////////////////////////////////////////////////////////////////
        //                                                                 //
        //                                                                 //
        //                           braco esquerdo                        //
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
        //                        cotovelo esquerdo                        //
        //                                                                 //
        //                                                                 //
        //                                                                 //
        /////////////////////////////////////////////////////////////////////

        [Route("robo/ContrairBracoEsquerdo")]
        [HttpPost]
        public async Task<IHttpActionResult> ContrairBracoEsquerdo()
        {
            try
            {
                var bEsquerdo = db.BracoEsquerdoes.ToList().LastOrDefault();

                if (bEsquerdo.Cotovelo <= 2)
                {
                    BracoEsquerdo item = new BracoEsquerdo();
                    item.Cotovelo = bEsquerdo.Cotovelo + 1;
                    item.Pulso = bEsquerdo.Pulso;
                    db.BracoEsquerdoes.Add(item);
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


        [Route("robo/DescontrairBracoEsquerdo")]
        [HttpPost]
        public async Task<IHttpActionResult> DescontrairBracoEsquerdo()
        {
            try
            {
                var bEsquerdo = db.BracoEsquerdoes.ToList().LastOrDefault();
                if (bEsquerdo.Cotovelo >= 1)
                {
                    BracoEsquerdo item = new BracoEsquerdo();
                    item.Cotovelo = bEsquerdo.Cotovelo - 1;
                    item.Pulso = bEsquerdo.Pulso;
                    db.BracoEsquerdoes.Add(item);
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
        //                        pulso esquerdo                           //
        //                                                                 //
        //                                                                 //
        //                                                                 //
        /////////////////////////////////////////////////////////////////////


        [Route("robo/RotacaoBracoEsquerdo")]
        [HttpPost]
        public async Task<IHttpActionResult> RotacaoBracoEsquerdo()
        {
            try
            {
                var bEsquerdo = db.BracoEsquerdoes.ToList().LastOrDefault();
                if (bEsquerdo.Cotovelo == 3 && bEsquerdo.Pulso < 180)
                {
                    BracoEsquerdo item = new BracoEsquerdo();
                    item.Cotovelo = bEsquerdo.Cotovelo;
                    item.Pulso = bEsquerdo.Pulso + 45;
                    db.BracoEsquerdoes.Add(item);
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


        [Route("robo/RotacaoBracoEsquerdoAtni")]
        [HttpPost]
        public async Task<IHttpActionResult> RotacaoBracoEsquerdoAtni()
        {
            try
            {
                var bEsquerdo = db.BracoEsquerdoes.ToList().LastOrDefault();
                if (bEsquerdo.Cotovelo == 3 && bEsquerdo.Pulso > -90)
                {
                    BracoEsquerdo item = new BracoEsquerdo();
                    item.Cotovelo = bEsquerdo.Cotovelo;
                    item.Pulso = bEsquerdo.Pulso - 45;
                    db.BracoEsquerdoes.Add(item);
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