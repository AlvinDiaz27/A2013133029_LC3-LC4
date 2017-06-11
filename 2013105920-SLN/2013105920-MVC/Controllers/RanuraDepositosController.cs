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
    public class RanuraDepositosController : Controller
    {
        // private CajeroDbContext db = new CajeroDbContext();
        private readonly IUnityOfWork _UnityOfWork;


        public RanuraDepositosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }


        // GET: RanuraDepositos
        public ActionResult Index()
        {
            var ranuraDeposito = _UnityOfWork.RanuraDepositos.GetEntity().Include(r => r.Atm);
            return View(_UnityOfWork.RanuraDepositos.GetEntity());
        }

        // GET: RanuraDepositos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RanuraDeposito ranuraDeposito = _UnityOfWork.RanuraDepositos.Get(id);
            if (ranuraDeposito == null)
            {
                return HttpNotFound();
            }
            return View(ranuraDeposito);
        }

        // GET: RanuraDepositos/Create
        public ActionResult Create()
        {
            ViewBag.RanuraDepositoId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje");
            return View();
        }

        // POST: RanuraDepositos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RanuraDepositoId")] RanuraDeposito ranuraDeposito)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.RanuraDepositos.Add(ranuraDeposito);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RanuraDepositoId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", ranuraDeposito.RanuraDepositoId);
            return View(ranuraDeposito);
        }

        // GET: RanuraDepositos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RanuraDeposito ranuraDeposito = _UnityOfWork.RanuraDepositos.Get(id);
            if (ranuraDeposito == null)
            {
                return HttpNotFound();
            }
            ViewBag.RanuraDepositoId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", ranuraDeposito.RanuraDepositoId);
            return View(ranuraDeposito);
        }

        // POST: RanuraDepositos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RanuraDepositoId")] RanuraDeposito ranuraDeposito)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(ranuraDeposito);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RanuraDepositoId = new SelectList(_UnityOfWork.ATMs.GetEntity(), "AtmId", "Mensaje", ranuraDeposito.RanuraDepositoId);
            return View(ranuraDeposito);
        }

        // GET: RanuraDepositos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RanuraDeposito ranuraDeposito = _UnityOfWork.RanuraDepositos.Get(id);
            if (ranuraDeposito == null)
            {
                return HttpNotFound();
            }
            return View(ranuraDeposito);
        }

        // POST: RanuraDepositos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RanuraDeposito ranuraDeposito = _UnityOfWork.RanuraDepositos.Get(id);
            _UnityOfWork.RanuraDepositos.Remove(ranuraDeposito);
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
