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
    public class historico1Controller : Controller
    {
        private contexto1 db = new contexto1();

        // GET: historico1
        public ActionResult Index()
        {
            return View(db.H.ToList());
        }

        // GET: historico1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historico1 historico1 = db.H.Find(id);
            if (historico1 == null)
            {
                return HttpNotFound();
            }
            return View(historico1);
        }

        // GET: historico1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: historico1/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,data_consulta,fantasia,cnpj")] historico1 historico1)
        {
            if (ModelState.IsValid)
            {
                db.H.Add(historico1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historico1);
        }

        // GET: historico1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historico1 historico1 = db.H.Find(id);
            if (historico1 == null)
            {
                return HttpNotFound();
            }
            return View(historico1);
        }

        // POST: historico1/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,data_consulta,fantasia,cnpj")] historico1 historico1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historico1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historico1);
        }

        // GET: historico1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historico1 historico1 = db.H.Find(id);
            if (historico1 == null)
            {
                return HttpNotFound();
            }
            return View(historico1);
        }

        // POST: historico1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            historico1 historico1 = db.H.Find(id);
            db.H.Remove(historico1);
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
