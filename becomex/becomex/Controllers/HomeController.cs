using Newtonsoft.Json;
using roboapi.Models;
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
                    
                    return Json(new { success = true, robo = movimento}, JsonRequestBehavior.AllowGet);
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


        public Robo ComunicarRoboGet(Uri uri)
        {
            try
            {
                HttpWebRequest myWebRequest = (HttpWebRequest)HttpWebRequest.Create(uri);

                var myHttpWebRequest = myWebRequest;
                myHttpWebRequest.PreAuthenticate = true;
                myHttpWebRequest.Method = "GET";
                myHttpWebRequest.Accept = "application/json";

                var myWebResponse = myWebRequest.GetResponse();
                var responseStream = myWebResponse.GetResponseStream();

                var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                var json = myStreamReader.ReadToEnd();

                responseStream.Close();
                myWebResponse.Close();

                //var Result = JsonConvert.DeserializeObject<List<string>>(json);
                var Result = JsonConvert.DeserializeObject<Robo>(json);

                if (Result == null)
                {
                    return null;
                }

                return Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Robo ComunicarRoboPost(Uri uri)
        {
            try
            {
                HttpWebRequest myWebRequest = (HttpWebRequest)HttpWebRequest.Create(uri);

                var myHttpWebRequest = myWebRequest;
                myHttpWebRequest.PreAuthenticate = true;
                myHttpWebRequest.Method = "POST";
                myHttpWebRequest.ContentLength = 0;
                myHttpWebRequest.Accept = "application/json";

                var myWebResponse = myWebRequest.GetResponse();
                var responseStream = myWebResponse.GetResponseStream();

                var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                var json = myStreamReader.ReadToEnd();

                responseStream.Close();
                myWebResponse.Close();

                //var Result = JsonConvert.DeserializeObject<List<string>>(json);
                var Result = JsonConvert.DeserializeObject<Robo>(json);

                if (Result == null)
                {
                    return null;
                }

                return Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public JsonResult GetAtualWebApi()
        {
            try
            {
                var movimento = ComunicarRoboGet(new Uri("http://localhost:15300/robo/get"));
                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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

        public JsonResult ResetaRoboWebApi()
        {
            try
            {
                var movimento = ComunicarRoboPost(new Uri("http://localhost:15300/robo/reseta"));
                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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


        public JsonResult ContrairBracoDireito()
        {
            try
            {
                var movimento = ComunicarRoboPost(new Uri("http://localhost:15300/robo/ContrairBracoDireito"));

                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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
                var movimento = ComunicarRoboPost(new Uri("http://localhost:15300/robo/DescontrairBracoDireito"));

                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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
                var movimento = ComunicarRoboPost(new Uri("http://localhost:15300/robo/RotacaoBracoDireito"));

                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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
                var movimento = ComunicarRoboPost(new Uri("http://localhost:15300/robo/RotacaoBracoDireitoAtni"));

                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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
                var movimento = ComunicarRoboPost(new Uri("http://localhost:15300/robo/ContrairBracoEsquerdo"));

                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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
                var movimento = ComunicarRoboPost(new Uri("http://localhost:15300/robo/DescontrairBracoEsquerdo"));

                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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
                var movimento = ComunicarRoboPost(new Uri("http://localhost:15300/robo/RotacaoBracoEsquerdo"));

                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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
                var movimento = ComunicarRoboPost(new Uri("http://localhost:15300/robo/RotacaoBracoEsquerdoAtni"));

                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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
                var movimento = ComunicarRoboPost(new Uri("http://localhost:15300/robo/RotacaoCabeca"));

                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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
                var movimento = ComunicarRoboPost(new Uri("http://localhost:15300/robo/RotacaoCabecaAtni"));

                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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
                var movimento = ComunicarRoboPost(new Uri("http://localhost:15300/robo/InclinacaoCabecaCima"));

                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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
                var movimento = ComunicarRoboPost(new Uri("http://localhost:15300/robo/InclinacaoCabecaBaixo"));

                if (movimento != null)
                {
                    return Json(new { success = true, robo = movimento }, JsonRequestBehavior.AllowGet);
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