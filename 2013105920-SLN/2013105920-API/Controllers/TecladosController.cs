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
    public class TecladosController : ApiController
    {
        //  private CajeroDbContext db = new CajeroDbContext();
        private readonly IUnityOfWork _UnityOfWork;


        public TecladosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        /*
                // GET: api/Teclados
                public IQueryable<Teclado> GetTeclado()
                {
                    return db.Teclado;
                }
            */
        [HttpGet]
        public IHttpActionResult Get()
        {
            //La capa de persistencia no debe ser modificada, porque es única para todo canal de atencion de la aplicacion
            //por lo tanto, a nivel de controlador se debe de hacer las modificaciones.
            var teclados = _UnityOfWork.Teclados.GetAll();

            if (teclados == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);



            return Ok(teclados);
        }

        // GET: api/Teclados/5
        [ResponseType(typeof(Teclado))]
        public IHttpActionResult GetTeclado(int id)
        {
            Teclado teclado = _UnityOfWork.Teclados.Get(id);
            if (teclado == null)
            {
                return NotFound();
            }

            return Ok(teclado);
        }

        // PUT: api/Teclados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeclado(int id, Teclado teclado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teclado.TecladoId)
            {
                return BadRequest();
            }

            _UnityOfWork.StateModified(teclado);

            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TecladoExists(id))
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

        // POST: api/Teclados
        [ResponseType(typeof(Teclado))]
        public IHttpActionResult PostTeclado(Teclado teclado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _UnityOfWork.Teclados.Add(teclado);
            _UnityOfWork.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teclado.TecladoId }, teclado);
        }

        // DELETE: api/Teclados/5
        [ResponseType(typeof(Teclado))]
        public IHttpActionResult DeleteTeclado(int id)
        {
            Teclado teclado = _UnityOfWork.Teclados.Get(id);
            if (teclado == null)
            {
                return NotFound();
            }

            _UnityOfWork.Teclados.Remove(teclado);
            _UnityOfWork.SaveChanges();

            return Ok(teclado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TecladoExists(int id)
        {
            return _UnityOfWork.Teclados.GetEntity().Count(e => e.TecladoId == id) > 0;
        }
    }
}