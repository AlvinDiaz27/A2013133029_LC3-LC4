using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using _2013105920_ENT.Entities;
using _2013105920_PER;
using _2013105920_ENT.IRepositories;

namespace _2013105920_API.Controllers
{
    public class CuentasController : ApiController
    {
        //   private CajeroDbContext db = new CajeroDbContext();
        private readonly IUnityOfWork _UnityOfWork;


        public CuentasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }


        /*   // GET: api/Cuentas
           public IQueryable<Cuenta> GetCuenta()
           {
               return _UnityOfWork.Cuenta;
           }
           */

        [HttpGet]
        public IHttpActionResult Get()
        {
            //La capa de persistencia no debe ser modificada, porque es única para todo canal de atencion de la aplicacion
            //por lo tanto, a nivel de controlador se debe de hacer las modificaciones.
            var cuentas = _UnityOfWork.Cuentas.GetAll();

            if (cuentas == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);



            return Ok(cuentas);
        }


        // GET: api/Cuentas/5
        [ResponseType(typeof(Cuenta))]
        public IHttpActionResult GetCuenta(int id)
        {
            Cuenta cuenta = _UnityOfWork.Cuentas.Get(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return Ok(cuenta);
        }

        // PUT: api/Cuentas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuenta(int id, Cuenta cuenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuenta.CuentaId)
            {
                return BadRequest();
            }

            _UnityOfWork.StateModified(cuenta);

            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /*     // POST: api/Cuentas
             [ResponseType(typeof(Cuenta))]
             public IHttpActionResult PostCuenta(Cuenta cuenta)
             {
                 if (!ModelState.IsValid)
                 {
                     return BadRequest(ModelState);
                 }

                 _.Cuenta.Add(cuenta);
                 db.SaveChanges();

                 return CreatedAtRoute("DefaultApi", new { id = cuenta.CuentaId }, cuenta);
             }
             */


        [HttpPost]
        public IHttpActionResult Create(Cuenta Cuentas)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //var floreria = Mapper.Map<FloreriaDto, Florerias>(floreriaDTO);

            _UnityOfWork.Cuentas.Add(Cuentas);

            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CuentaExists(Cuentas.CuentaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = Cuentas.CuentaId }, Cuentas);
        }







        // DELETE: api/Cuentas/5
        [ResponseType(typeof(Cuenta))]
        public IHttpActionResult DeleteCuenta(int id)
        {
            Cuenta cuenta = _UnityOfWork.Cuentas.Get(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            _UnityOfWork.Cuentas.Remove(cuenta);
            _UnityOfWork.SaveChanges();

            return Ok(cuenta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CuentaExists(int id)
        {
            return _UnityOfWork.Cuentas.GetEntity().Count(e => e.CuentaId == id) > 0;
        }
    }
}