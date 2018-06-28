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
        public IHttpActionResult Get()
        {
            try
            {
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
                    item.Pulso = bDireito.Pulso +45;
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
    }
}
