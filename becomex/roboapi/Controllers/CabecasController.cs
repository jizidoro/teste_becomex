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


        /////////////////////////////////////////////////////////////////////
        //                                                                 //
        //                                                                 //
        //                           cabeca                                //
        //                                                                 //
        //                                                                 //
        //                                                                 //
        /////////////////////////////////////////////////////////////////////


        //Rotação -90º
        //Rotação -45º
        //Em Repouso
        //Rotação 45º
        //Rotação 90º

        /////////////////////////////////////////////////////////////////////
        //                                                                 //
        //                                                                 //
        //                  rotacao cabeca                                 //
        //                                                                 //
        //                                                                 //
        //                                                                 //
        /////////////////////////////////////////////////////////////////////



        [Route("robo/RotacaoCabeca")]
        [HttpPost]
        public async Task<IHttpActionResult> RotacaoCabeca()
        {
            try
            {
                var cabeca = db.Cabecas.ToList().LastOrDefault();
                if (cabeca.Inclinacao > -1 && cabeca.Rotacao < 90)
                {
                    Cabeca item = new Cabeca();
                    item.Inclinacao = cabeca.Inclinacao;
                    item.Rotacao = cabeca.Rotacao + 45;
                    db.Cabecas.Add(item);
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


        [Route("robo/RotacaoCabecaAtni")]
        [HttpPost]
        public async Task<IHttpActionResult> RotacaoCabecaAtni()
        {
            try
            {
                var cabeca = db.Cabecas.ToList().LastOrDefault();
                if (cabeca.Inclinacao > -1 && cabeca.Rotacao > -90)
                {
                    Cabeca item = new Cabeca();
                    item.Inclinacao = cabeca.Inclinacao;
                    item.Rotacao = cabeca.Rotacao - 45;
                    db.Cabecas.Add(item);
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


        //Para Cima
        //Em Repouso
        //Para Baixo

        /////////////////////////////////////////////////////////////////////
        //                                                                 //
        //                                                                 //
        //                   Inclinacao cabeca                             //
        //                                                                 //
        //                                                                 //
        //                                                                 //
        /////////////////////////////////////////////////////////////////////



        [Route("robo/InclinacaoCabecaCima")]
        [HttpPost]
        public async Task<IHttpActionResult> InclinacaoCabecaCima()
        {
            try
            {
                var cabeca = db.Cabecas.ToList().LastOrDefault();
                if (cabeca.Inclinacao < 1)
                {
                    Cabeca item = new Cabeca();
                    item.Inclinacao = cabeca.Inclinacao + 1;
                    item.Rotacao = cabeca.Rotacao;
                    db.Cabecas.Add(item);
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


        [Route("robo/InclinacaoCabecaBaixo")]
        [HttpPost]
        public async Task<IHttpActionResult> InclinacaoCabecaBaixo()
        {
            try
            {
                var cabeca = db.Cabecas.ToList().LastOrDefault();
                if (cabeca.Inclinacao > -1)
                {
                    Cabeca item = new Cabeca();
                    item.Inclinacao = cabeca.Inclinacao - 1;
                    item.Rotacao = cabeca.Rotacao;
                    db.Cabecas.Add(item);
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