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
    public class PantallasController : Controller
    {
        // private CajeroDbContext db = new CajeroDbContext();
        private readonly IUnityOfWork _UnityOfWork;


        public PantallasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }


        // GET: Pantallas
        public ActionResult Index()
        {
            var pantalla = _UnityOfWork.Pantallas.GetEntity().Include(p => p.Atm).Include(p => p.Retiro);
            return View(pantalla.ToList());
        }

        // GET: Pantallas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pantalla pantalla = _UnityOfWork.Pantallas.Get(id);
            if (pantalla == null)
            {
                return HttpNotFound();
            }
            return View(pantalla);
        }

        // GET: Pantallas/Create
        public ActionResult Create()
        {
            ViewBag.PantallaId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje");
            ViewBag.PantallaId = new SelectList(_UnityOfWork.Retiros.GetEntity(), "RetiroId", "Monto");
            return View();
        }

        // POST: Pantallas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PantallaId,AtmId,RetiroId")] Pantalla pantalla)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Pantallas.Add(pantalla);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PantallaId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", pantalla.PantallaId);
            ViewBag.PantallaId = new SelectList(_UnityOfWork.Retiros.GetEntity(), "RetiroId", "Monto", pantalla.PantallaId);
            return View(pantalla);
        }

        // GET: Pantallas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pantalla pantalla = _UnityOfWork.Pantallas.Get(id);
            if (pantalla == null)
            {
                return HttpNotFound();
            }
            ViewBag.PantallaId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", pantalla.PantallaId);
            ViewBag.PantallaId = new SelectList(_UnityOfWork.Retiros.GetEntity(), "RetiroId", "Monto", pantalla.PantallaId);
            return View(pantalla);
        }

        // POST: Pantallas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PantallaId,AtmId,RetiroId")] Pantalla pantalla)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(pantalla);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PantallaId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", pantalla.PantallaId);
            ViewBag.PantallaId = new SelectList(_UnityOfWork.Retiros.GetEntity(), "RetiroId", "Monto", pantalla.PantallaId);
            return View(pantalla);
        }

        // GET: Pantallas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pantalla pantalla = _UnityOfWork.Pantallas.Get(id);
            if (pantalla == null)
            {
                return HttpNotFound();
            }
            return View(pantalla);
        }

        // POST: Pantallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pantalla pantalla = _UnityOfWork.Pantallas.Get(id);
            _UnityOfWork.Pantallas.Remove(pantalla);
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
