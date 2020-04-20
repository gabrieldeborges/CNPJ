using Newtonsoft.Json;
using Projeto_cnpj.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projeto_cnpj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();


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

        public ActionResult Adicionar() { 
       

            return View("Index");
    } 
       
        public ActionResult busca(string cnpj)
        {
            Console.WriteLine("Hello World!");
            Boolean ehnumero;

            var requisicaoWeb = WebRequest.CreateHttp("https://www.receitaws.com.br/v1/cnpj/" + cnpj);
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";

            try
            {
                double.Parse(cnpj);
                ehnumero = true;
            }
            catch
            {
                ehnumero = false;
            }


            if (cnpj != null && ehnumero==true)
            {
                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    String JsonCanovertido = reader.ReadToEnd();
                    empresa em = JsonConvert.DeserializeObject<empresa>(JsonCanovertido);


                    ViewBag.situacao = em.situacao;

                    ViewBag.bairro = em.bairro;

                    ViewBag.situacao = em.situacao;

                    ViewBag.abertura = em.abertura;

                    ViewBag.nome = em.fantasia;

                    ViewBag.cep = em.cep;

                    ViewBag.cidade = em.municipio;

                    historico his = new historico();
                    his.cnpj = cnpj;
                    his.data_consulta = DateTime.Now.DayOfYear;
                    his.nome = em.fantasia;
                    contexto con = new contexto();
                    con.Historicos.Add(his);
                    con.SaveChanges();

                    return View("Index");
                    
               
                }
            }
            else
            {
                ViewData["alerta"] = true;
                return View("Index");
            }
        }



    }
}