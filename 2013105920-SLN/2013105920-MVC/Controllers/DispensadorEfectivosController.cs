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
    public class DispensadorEfectivosController : Controller
    {
      //  private CajeroDbContext db = new CajeroDbContext();
        private readonly IUnityOfWork _UnityOfWork;


        public DispensadorEfectivosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: DispensadorEfectivos
        public ActionResult Index()
        {
         //   var dispensadorEfectivo = _UnityOfWork.DispensadorEfectivos.GetEntity().Include(d => d.Atm).Include(d => d.Retiro);
            return View(_UnityOfWork.DispensadorEfectivos.GetAll());
        }

        // GET: DispensadorEfectivos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispensadorEfectivo dispensadorEfectivo = _UnityOfWork.DispensadorEfectivos.Get(id);
            if (dispensadorEfectivo == null)
            {
                return HttpNotFound();
            }
            return View(dispensadorEfectivo);
        }

        // GET: DispensadorEfectivos/Create
        public ActionResult Create()
        {
            ViewBag.DispensadorefectivoId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje");
            ViewBag.DispensadorefectivoId = new SelectList(_UnityOfWork.Retiros.GetEntity(), "RetiroId", "Monto");
            return View();
        }

        // POST: DispensadorEfectivos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DispensadorefectivoId,contador")] DispensadorEfectivo dispensadorEfectivo)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.DispensadorEfectivos.Add(dispensadorEfectivo);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DispensadorefectivoId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", dispensadorEfectivo.DispensadorefectivoId);
            ViewBag.DispensadorefectivoId = new SelectList(_UnityOfWork.Retiros.GetEntity(), "RetiroId", "Monto", dispensadorEfectivo.DispensadorefectivoId);
            return View(dispensadorEfectivo);
        }

        // GET: DispensadorEfectivos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispensadorEfectivo dispensadorEfectivo = _UnityOfWork.DispensadorEfectivos.Get(id);
            if (dispensadorEfectivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.DispensadorefectivoId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", dispensadorEfectivo.DispensadorefectivoId);
            ViewBag.DispensadorefectivoId = new SelectList(_UnityOfWork.Retiros.GetEntity(), "RetiroId", "Monto", dispensadorEfectivo.DispensadorefectivoId);
            return View(dispensadorEfectivo);
        }

        // POST: DispensadorEfectivos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DispensadorefectivoId,contador")] DispensadorEfectivo dispensadorEfectivo)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(dispensadorEfectivo);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DispensadorefectivoId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", dispensadorEfectivo.DispensadorefectivoId);
            ViewBag.DispensadorefectivoId = new SelectList(_UnityOfWork.Retiros.GetEntity(), "RetiroId", "Monto", dispensadorEfectivo.DispensadorefectivoId);
            return View(dispensadorEfectivo);
        }

        // GET: DispensadorEfectivos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispensadorEfectivo dispensadorEfectivo = _UnityOfWork.DispensadorEfectivos.Get(id);
            if (dispensadorEfectivo == null)
            {
                return HttpNotFound();
            }
            return View(dispensadorEfectivo);
        }

        // POST: DispensadorEfectivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DispensadorEfectivo dispensadorEfectivo = _UnityOfWork.DispensadorEfectivos.Get(id);
            _UnityOfWork.DispensadorEfectivos.Remove(dispensadorEfectivo);
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
