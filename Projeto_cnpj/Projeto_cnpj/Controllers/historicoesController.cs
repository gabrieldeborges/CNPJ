using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto_cnpj.Models;

namespace Projeto_cnpj.Controllers
{
    public class historicoesController : Controller
    {
        private contexto db = new contexto();

        // GET: historicoes
        public ActionResult Index()
        {
            return View(db.Historicos.ToList());
        }

        // GET: historicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historico historico = db.Historicos.Find(id);
            if (historico == null)
            {
                return HttpNotFound();
            }
            return View(historico);
        }


        public ActionResult Adicionar(historico his)
        {
            db.Set<historico>().Add(his);
            return View();
        }
        // GET: historicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: historicoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,data_consulta,cnpj,nome")] historico historico)
        {
            if (ModelState.IsValid)
            {
                db.Historicos.Add(historico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historico);
        }

        // GET: historicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historico historico = db.Historicos.Find(id);
            if (historico == null)
            {
                return HttpNotFound();
            }
            return View(historico);
        }

        // POST: historicoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,data_consulta,cnpj,nome")] historico historico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historico);
        }

        // GET: historicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historico historico = db.Historicos.Find(id);
            if (historico == null)
            {
                return HttpNotFound();
            }
            return View(historico);
        }

        // POST: historicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            historico historico = db.Historicos.Find(id);
            db.Historicos.Remove(historico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
