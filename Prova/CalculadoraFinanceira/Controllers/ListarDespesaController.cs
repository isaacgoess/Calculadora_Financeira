using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CalculadoraFinanceira.Models;
using CalculadoraFinanceira.Models.Classes;

namespace CalculadoraFinanceira.Controllers
{
    public class ListarDespesaController : Controller
    {
        private CalculadoraFinanceiraContext db = new CalculadoraFinanceiraContext();

        // GET: TipoDespesa
        public ActionResult Index(string busca)
        {
            if (String.IsNullOrEmpty(busca))
            {
                return View(db.ListarDespesas.ToList());
            }

            var result = db.ListarDespesas.Where(tipo => tipo.Nome.ToLower().Contains(busca) && tipo.Situacao == true);
            return View(result.ToList());
        }

        // GET: TipoDespesa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListarDespesa tipoDespesa = db.ListarDespesas.Where(tipo => tipo.Situacao == true && tipo.Id == id).SingleOrDefault<ListarDespesa>();

            if (tipoDespesa == null)
            {
                return HttpNotFound();
            }
            return View(tipoDespesa);
        }

        // GET: TipoDespesa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDespesa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Situacao")] ListarDespesa tipoDespesa)
        {
            if (ModelState.IsValid)
            {
                db.ListarDespesas.Add(tipoDespesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDespesa);
        }

        // GET: TipoDespesa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListarDespesa tipoDespesa = db.ListarDespesas.Find(id);
            if (tipoDespesa == null)
            {
                return HttpNotFound();
            }
            return View(tipoDespesa);
        }

        // POST: TipoDespesa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Situacao")] ListarDespesa tipoDespesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDespesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDespesa);
        }

        // GET: TipoDespesa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListarDespesa tipoDespesa = db.ListarDespesas.Find(id);
            if (tipoDespesa == null)
            {
                return HttpNotFound();
            }
            return View(tipoDespesa);
        }

        // POST: TipoDespesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListarDespesa tipoDespesa = db.ListarDespesas.Find(id);
            tipoDespesa.Situacao = false;
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
