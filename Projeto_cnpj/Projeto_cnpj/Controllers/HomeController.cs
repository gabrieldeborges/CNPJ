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
    {   //guarda a consulta nova
      
      
    

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



        public ActionResult salva(String fantasia, String cnpj1)
        {
            
             if (cnpj1 != "") { 
                historico1 atualConsulta = new historico1();
                atualConsulta.cnpj = cnpj1;
                atualConsulta.data_consulta = DateTime.Now.ToString("dd/MM/yyyy");
                atualConsulta.fantasia = fantasia;

                contexto1 con = new contexto1();

                con.H.Add(atualConsulta);
                con.SaveChanges();

                ViewData["verifica"] = 1;

                return View("Index");
             }
             else
             {
                ViewData["verifica"] = 0;
                return View("Index");
             }
         
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
                    ViewBag.cnpj = cnpj;

                    ViewBag.situacao = em.situacao;

                    ViewBag.bairro = em.bairro;

                    ViewBag.situacao = em.situacao;

                    ViewBag.abertura = em.abertura;

                    ViewBag.nome = em.fantasia;

                    ViewBag.cep = em.cep;

                    ViewBag.cidade = em.municipio;
                    

                    
                    ViewBag.erro = "Não encontrado";
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