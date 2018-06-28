using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace becomex.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        /*
        public async Task<JsonResult> ContrairDireitoRepousoAsync()
        {
            try
            {
                if (value > 0)
                {
                    Uri uri = new Uri("http://localhost:15300/robo/get");
                    HttpClient cliente = new HttpClient();
                    cliente.BaseAddress = uri;
                    var resposta = await cliente.GetAsync("");
                    var dados = await resposta.Content.ReadAsStringAsync();

                    var Result = JsonConvert.DeserializeObject<List<string>>(dados);
                    
                    return Json(new { success = true, text = "texto"}, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        */


        public bool ComunicarRobo(Uri uri)
        {
            try
            {
                HttpWebRequest myWebRequest = (HttpWebRequest)HttpWebRequest.Create(uri);

                var myHttpWebRequest = myWebRequest;
                myHttpWebRequest.PreAuthenticate = true;
                myHttpWebRequest.Accept = "application/json";

                var myWebResponse = myWebRequest.GetResponse();
                var responseStream = myWebResponse.GetResponseStream();

                var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                var json = myStreamReader.ReadToEnd();

                responseStream.Close();
                myWebResponse.Close();

                //var Result = JsonConvert.DeserializeObject<List<string>>(json);
                var Result = JsonConvert.DeserializeObject<string>(json);

                if (string.IsNullOrEmpty(Result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public JsonResult ContrairBracoDireitoRepouso(){
            try{
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/ContrairBracoDireitoRepouso"));

                if (movimento){
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else{
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex){
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ContrairBracoDireito()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/ContrairBracoDireito"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DescontrairBracoDireito()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/DescontrairBracoDireito"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RotacaoBracoDireitoRepouso()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/RotacaoBracoDireitoRepouso"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RotacaoBracoDireito()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/RotacaoBracoDireito"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RotacaoBracoDireitoAtni()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/RotacaoBracoDireitoAtni"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ContrairBracoEsquerdoRepouso()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/ContrairBracoEsquerdoRepouso"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ContrairBracoEsquerdo()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/ContrairBracoEsquerdo"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DescontrairBracoEsquerdo()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/DescontrairBracoEsquerdo"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RotacaoBracoEsquerdoRepouso()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/RotacaoBracoEsquerdoRepouso"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RotacaoBracoEsquerdo()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/RotacaoBracoEsquerdo"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RotacaoBracoEsquerdoAtni()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/RotacaoBracoEsquerdoAtni"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RotacaoCabecaRepouso()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/RotacaoCabecaRepouso"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RotacaoCabeca()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/RotacaoCabeca"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RotacaoCabecaAtni()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/RotacaoCabecaAtni"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult InclinacaoCabecaRepouso()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/InclinacaoCabecaRepouso"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult InclinacaoCabecaCima()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/InclinacaoCabecaCima"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult InclinacaoCabecaBaixo()
        {
            try
            {
                var movimento = ComunicarRobo(new Uri("http://localhost:15300/robo/InclinacaoCabecaBaixo"));

                if (movimento)
                {
                    return Json(new { success = true, text = "texto" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}