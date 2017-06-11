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
    public class RetirosController : Controller
    {
        //private CajeroDbContext db = new CajeroDbContext();
        private readonly IUnityOfWork _UnityOfWork;


        public RetirosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: Retiros
        public ActionResult Index()
        {
           // var retiro = _UnityOfWork.Retiros.GetEntity().Include(r => r.Atm).Include(r => r.BaseDatos).Include(r => r.Dispensadorefectivo).Include(r => r.Pantalla).Include(r => r.Teclado);
            return View(_UnityOfWork.Retiros.GetAll());
        }

        // GET: Retiros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retiro retiro = _UnityOfWork.Retiros.Get(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);
        }

        // GET: Retiros/Create
        public ActionResult Create()
        {
            ViewBag.RetiroId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje");
            ViewBag.RetiroId = new SelectList(_UnityOfWork.BaseDatos.GetEntity(), "BaseDatosId", "Administrador");
            ViewBag.RetiroId = new SelectList(_UnityOfWork.DispensadorEfectivos.GetEntity(), "DispensadorefectivoId", "DispensadorefectivoId");
            ViewBag.RetiroId = new SelectList(_UnityOfWork.Pantallas.GetEntity(), "PantallaId", "PantallaId");
            ViewBag.RetiroId = new SelectList(_UnityOfWork.Teclados.GetEntity(), "TecladoId", "Marca");
            return View();
        }

        // POST: Retiros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RetiroId,Monto")] Retiro retiro)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Retiros.Add(retiro);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RetiroId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", retiro.RetiroId);
            ViewBag.RetiroId = new SelectList(_UnityOfWork.BaseDatos.GetEntity(), "BaseDatosId", "Administrador", retiro.RetiroId);
            ViewBag.RetiroId = new SelectList(_UnityOfWork.DispensadorEfectivos.GetEntity(), "DispensadorefectivoId", "DispensadorefectivoId", retiro.RetiroId);
            ViewBag.RetiroId = new SelectList(_UnityOfWork.Pantallas.GetEntity(), "PantallaId", "PantallaId", retiro.RetiroId);
            ViewBag.RetiroId = new SelectList(_UnityOfWork.Teclados.GetEntity(), "TecladoId", "Marca", retiro.RetiroId);
            return View(retiro);
        }

        // GET: Retiros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retiro retiro = _UnityOfWork.Retiros.Get(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            ViewBag.RetiroId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", retiro.RetiroId);
            ViewBag.RetiroId = new SelectList(_UnityOfWork.BaseDatos.GetEntity(), "BaseDatosId", "Administrador", retiro.RetiroId);
            ViewBag.RetiroId = new SelectList(_UnityOfWork.DispensadorEfectivos.GetEntity(), "DispensadorefectivoId", "DispensadorefectivoId", retiro.RetiroId);
            ViewBag.RetiroId = new SelectList(_UnityOfWork.Pantallas.GetEntity(), "PantallaId", "PantallaId", retiro.RetiroId);
            ViewBag.RetiroId = new SelectList(_UnityOfWork.Teclados.GetEntity(), "TecladoId", "Marca", retiro.RetiroId);
            return View(retiro);
        }

        // POST: Retiros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RetiroId,Monto")] Retiro retiro)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(retiro);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RetiroId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", retiro.RetiroId);
            ViewBag.RetiroId = new SelectList(_UnityOfWork.BaseDatos.GetEntity(), "BaseDatosId", "Administrador", retiro.RetiroId);
            ViewBag.RetiroId = new SelectList(_UnityOfWork.DispensadorEfectivos.GetEntity(), "DispensadorefectivoId", "DispensadorefectivoId", retiro.RetiroId);
            ViewBag.RetiroId = new SelectList(_UnityOfWork.Pantallas.GetEntity(), "PantallaId", "PantallaId", retiro.RetiroId);
            ViewBag.RetiroId = new SelectList(_UnityOfWork.Teclados.GetEntity(), "TecladoId", "Marca", retiro.RetiroId);
            return View(retiro);
        }

        // GET: Retiros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retiro retiro = _UnityOfWork.Retiros.Get(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);
        }

        // POST: Retiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Retiro retiro = _UnityOfWork.Retiros.Get(id);
            _UnityOfWork.Retiros.Remove(retiro);
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
