using roboapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace roboapi.Controllers
{
    public class RoboController : ApiController
    {
        // GET: api/Robo


        [Route("robo/get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok("ta vivo");
            }
            catch
            {
                throw;
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

        // GET:
        [Route("robo/ContrairBracoDireitoRepouso")]
        [HttpGet]
        public IHttpActionResult ContrairBracoDireitoRepouso()
        {
            try
            {
                return Ok("Contrair Repouso");
            }
            catch
            {
                throw;
            }
        }



        // GET:
        [Route("robo/ContrairBracoDireito")]
        [HttpGet]
        public IHttpActionResult ContrairBracoDireito()
        {
            try
            {
                return Ok("contraiu esquerdo ");
            }
            catch
            {
                throw;
            }
        }

        // GET:
        [Route("robo/DescontrairBracoDireito")]
        [HttpGet]
        public IHttpActionResult DescontrairBracoDireito()
        {
            try
            {
                return Ok("descontraiu esquerdo ");
            }
            catch
            {
                throw;
            }
        }



        //Rotação para -90º
        //Rotação para -45º
        //Em Repouso
        //Rotação para 45º
        //Rotação para 90º
        //Rotação para 135º
        //Rotação para 180º

        // GET:
        [Route("robo/RotacaoBracoDireitoRepouso")]
        [HttpGet]
        public IHttpActionResult RotacaoBracoDireitoRepouso()
        {
            try
            {
                return Ok("rodou esquerdo");
                
            }
            catch
            {
                throw;
            }
        }

        // GET:
        [Route("robo/RotacaoBracoDireito")]
        [HttpGet]
        public IHttpActionResult RotacaoBracoDireito()
        {
            try
            {
                return Ok("rodou esquerdo");
                
            }
            catch
            {
                throw;
            }
        }

        // GET:
        [Route("robo/RotacaoBracoDireitoAtni")]
        [HttpGet]
        public IHttpActionResult RotacaoBracoDireitoAtni()
        {
            try
            {
                return Ok("rodou anti esquerdo");
                
            }
            catch
            {
                throw;
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

        // GET:
        [Route("robo/ContrairBracoEsquerdoRepouso")]
        [HttpGet]
        public IHttpActionResult ContrairBracoEsquerdoRepouso()
        {
            try
            {
                return Ok("Contrair Repouso");
                
            }
            catch
            {
                throw;
            }
        }



        // GET:
        [Route("robo/ContrairBracoEsquerdo")]
        [HttpGet]
        public IHttpActionResult ContrairBracoEsquerdo()
        {
            try
            {
                return Ok("contraiu esquerdo");
                
            }
            catch
            {
                throw;
            }
        }

        // GET:
        [Route("robo/DescontrairBracoEsquerdo")]
        [HttpGet]
        public IHttpActionResult DescontrairBracoEsquerdo()
        {
            try
            {
                return Ok("descontraiu esquerdo");
            }
            catch
            {
                throw;
            }
        }



        //Rotação para -90º
        //Rotação para -45º
        //Em Repouso
        //Rotação para 45º
        //Rotação para 90º
        //Rotação para 135º
        //Rotação para 180º

        // GET:
        [Route("robo/RotacaoBracoEsquerdoRepouso")]
        [HttpGet]
        public IHttpActionResult RotacaoBracoEsquerdoRepouso()
        {
            try
            {
                return Ok("rodou esquerdo");
            }
            catch
            {
                throw;
            }
        }

        // GET:
        [Route("robo/RotacaoBracoEsquerdo")]
        [HttpGet]
        public IHttpActionResult RotacaoBracoEsquerdo()
        {
            try
            {
                return Ok("rodou esquerdo");
            }
            catch
            {
                throw;
            }
        }

        // GET:
        [Route("robo/RotacaoBracoEsquerdoAtni")]
        [HttpGet]
        public IHttpActionResult RotacaoBracoEsquerdoAtni()
        {
            try
            {
                return Ok("rodou anti esquerdo");
            }
            catch
            {
                throw;
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


        // GET:
        [Route("robo/RotacaoCabecaRepouso")]
        [HttpGet]
        public IHttpActionResult RotacaoCabecaRepouso()
        {
            try
            {
                return Ok("Rotacao Cabeca Repouso");
            }
            catch
            {
                throw;
            }
        }

        // GET:
        [Route("robo/RotacaoCabeca")]
        [HttpGet]
        public IHttpActionResult RotacaoCabeca()
        {
            try
            {
                return Ok("rodou Cabeca");
            }
            catch
            {
                throw;
            }
        }

        // GET:
        [Route("robo/RotacaoCabecaAtni")]
        [HttpGet]
        public IHttpActionResult RotacaoCabecaAtni()
        {
            try
            {
                return Ok("rodou anti Cabeca");
            }
            catch
            {
                throw;
            }
        }


        //Para Cima
        //Em Repouso
        //Para Baixo


        // GET:
        [Route("robo/InclinacaoCabecaRepouso")]
        [HttpGet]
        public IHttpActionResult InclinacaoCabecaRepouso()
        {
            try
            {
                return Ok("Inclinacao Cabeca Repouso");
            }
            catch
            {
                throw;
            }
        }

        // GET:
        [Route("robo/InclinacaoCabecaCima")]
        [HttpGet]
        public IHttpActionResult InclinacaoCabecaCima()
        {
            try
            {
                return Ok("Inclinacao Cabeca Cima");
            }
            catch
            {
                throw;
            }
        }

        // GET:
        [Route("robo/InclinacaoCabecaBaixo")]
        [HttpGet]
        public IHttpActionResult InclinacaoCabecaBaixo()
        {
            try
            {
                return Ok("Inclinacao Cabeca Baixo");
            }
            catch
            {
                throw;
            }
        }

        // GET: api/Robo/1
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Robo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Robo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Robo/5
        public void Delete(int id)
        {
        }
    }
}
