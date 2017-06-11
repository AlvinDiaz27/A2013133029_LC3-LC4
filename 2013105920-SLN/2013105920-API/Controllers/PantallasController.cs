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
    public class PantallasController : ApiController
    {
        // private CajeroDbContext db = new CajeroDbContext();
        private readonly IUnityOfWork _UnityOfWork;


        public PantallasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        /*
                // GET: api/Pantallas
                public IQueryable<Pantalla> GetPantalla()
                {
                    return db.Pantalla;
                }
                */


        [HttpGet]
        public IHttpActionResult Get()
        {
            //La capa de persistencia no debe ser modificada, porque es única para todo canal de atencion de la aplicacion
            //por lo tanto, a nivel de controlador se debe de hacer las modificaciones.
            var pantallas = _UnityOfWork.Pantallas.GetAll();

            if (pantallas == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);



            return Ok(pantallas);
        }


        // GET: api/Pantallas/5
        [ResponseType(typeof(Pantalla))]
        public IHttpActionResult GetPantalla(int id)
        {
            Pantalla pantalla = _UnityOfWork.Pantallas.Get(id);
            if (pantalla == null)
            {
                return NotFound();
            }

            return Ok(pantalla);
        }

        // PUT: api/Pantallas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPantalla(int id, Pantalla pantalla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pantalla.PantallaId)
            {
                return BadRequest();
            }

            _UnityOfWork.StateModified(pantalla);

            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PantallaExists(id))
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



        /*
        // POST: api/Pantallas
        [ResponseType(typeof(Pantalla))]
        public IHttpActionResult PostPantalla(Pantalla pantalla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _UnityOfWork.Pantallas.Add(pantalla);
            _UnityOfWork.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pantalla.PantallaId }, pantalla);
        }
            */

        [HttpPost]
        public IHttpActionResult Create(Pantalla pantallas)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //var floreria = Mapper.Map<FloreriaDto, Florerias>(floreriaDTO);

            _UnityOfWork.Pantallas.Add(pantallas);

            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PantallaExists(pantallas.PantallaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pantallas.PantallaId }, pantallas);
        }




        // DELETE: api/Pantallas/5
        [ResponseType(typeof(Pantalla))]
        public IHttpActionResult DeletePantalla(int id)
        {
            Pantalla pantalla = _UnityOfWork.Pantallas.Get(id);
            if (pantalla == null)
            {
                return NotFound();
            }

            _UnityOfWork.Pantallas.Remove(pantalla);
            _UnityOfWork.SaveChanges();

            return Ok(pantalla);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PantallaExists(int id)
        {
            return _UnityOfWork.Pantallas.GetEntity().Count(e => e.PantallaId == id) > 0;
        }
    }
}