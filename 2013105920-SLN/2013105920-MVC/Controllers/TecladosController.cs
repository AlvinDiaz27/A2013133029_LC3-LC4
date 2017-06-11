using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2013105920_ENT.Entities;
using _2013105920_PER;
using _2013105920_ENT.IRepositories;

namespace _2013105920_MVC.Controllers
{
    public class TecladosController : Controller
    {
        //private CajeroDbContext db = new CajeroDbContext();
        private readonly IUnityOfWork _UnityOfWork;


        public TecladosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }


        // GET: Teclados
        public ActionResult Index()
        {
            //var teclado = _UnityOfWork.Teclados.GetEntity().Include(t => t.Atm).Include(t => t.Retiro);
            return View(_UnityOfWork.Teclados.GetAll());
        }

        // GET: Teclados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teclado teclado = _UnityOfWork.Teclados.Get(id);
            if (teclado == null)
            {
                return HttpNotFound();
            }
            return View(teclado);
        }

        // GET: Teclados/Create
        public ActionResult Create()
        {
            ViewBag.TecladoId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje");
            ViewBag.TecladoId = new SelectList(_UnityOfWork.Retiros.GetEntity(), "RetiroId", "Monto");
            return View();
        }

        // POST: Teclados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TecladoId,Marca")] Teclado teclado)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Teclados.Add(teclado);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TecladoId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", teclado.TecladoId);
            ViewBag.TecladoId = new SelectList(_UnityOfWork.Retiros.GetEntity(), "RetiroId", "Monto", teclado.TecladoId);
            return View(teclado);
        }

        // GET: Teclados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teclado teclado = _UnityOfWork.Teclados.Get(id);
            if (teclado == null)
            {
                return HttpNotFound();
            }
            ViewBag.TecladoId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", teclado.TecladoId);
            ViewBag.TecladoId = new SelectList(_UnityOfWork.Retiros.GetEntity(), "RetiroId", "Monto", teclado.TecladoId);
            return View(teclado);
        }

        // POST: Teclados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TecladoId,Marca")] Teclado teclado)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(teclado);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TecladoId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", teclado.TecladoId);
            ViewBag.TecladoId = new SelectList(_UnityOfWork.Retiros.GetEntity(), "RetiroId", "Monto", teclado.TecladoId);
            return View(teclado);
        }

        // GET: Teclados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teclado teclado = _UnityOfWork.Teclados.Get(id);
            if (teclado == null)
            {
                return HttpNotFound();
            }
            return View(teclado);
        }

        // POST: Teclados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teclado teclado = _UnityOfWork.Teclados.Get(id);
            _UnityOfWork.Teclados.Remove(teclado);
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
