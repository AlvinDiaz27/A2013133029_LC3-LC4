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
    public class RanuraDepositosController : ApiController
    {
        // private CajeroDbContext db = new CajeroDbContext();
        private readonly IUnityOfWork _UnityOfWork;


        public RanuraDepositosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        /*
                // GET: api/RanuraDepositos
                public IQueryable<RanuraDeposito> GetRanuraDeposito()
                {
                    return _UnityOfWork.RanuraDepositos;
                }
        */

        [HttpGet]
        public IHttpActionResult Get()
        {
            //La capa de persistencia no debe ser modificada, porque es única para todo canal de atencion de la aplicacion
            //por lo tanto, a nivel de controlador se debe de hacer las modificaciones.
            var ranuras = _UnityOfWork.RanuraDepositos.GetAll();

            if (ranuras == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);



            return Ok(ranuras);
        }




        // GET: api/RanuraDepositos/5
        [ResponseType(typeof(RanuraDeposito))]
        public IHttpActionResult GetRanuraDeposito(int id)
        {
            RanuraDeposito ranuraDeposito = _UnityOfWork.RanuraDepositos.Get(id);
            if (ranuraDeposito == null)
            {
                return NotFound();
            }

            return Ok(ranuraDeposito);
        }

        // PUT: api/RanuraDepositos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRanuraDeposito(int id, RanuraDeposito ranuraDeposito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ranuraDeposito.RanuraDepositoId)
            {
                return BadRequest();
            }

            _UnityOfWork.StateModified(ranuraDeposito);

            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RanuraDepositoExists(id))
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
                // POST: api/RanuraDepositos
                [ResponseType(typeof(RanuraDeposito))]
                public IHttpActionResult PostRanuraDeposito(RanuraDeposito ranuraDeposito)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    _UnityOfWork.RanuraDepositos.Add(ranuraDeposito);
                    _UnityOfWork.SaveChanges();

                    return CreatedAtRoute("DefaultApi", new { id = ranuraDeposito.RanuraDepositoId }, ranuraDeposito);
                }

            */


        [HttpPost]
        public IHttpActionResult Create(RanuraDeposito ranura)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //var floreria = Mapper.Map<FloreriaDto, Florerias>(floreriaDTO);

            _UnityOfWork.RanuraDepositos.Add(ranura);

            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RanuraDepositoExists(ranura.RanuraDepositoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ranura.RanuraDepositoId }, ranura);
        }



        // DELETE: api/RanuraDepositos/5
        [ResponseType(typeof(RanuraDeposito))]
        public IHttpActionResult DeleteRanuraDeposito(int id)
        {
            RanuraDeposito ranuraDeposito = _UnityOfWork.RanuraDepositos.Get(id);
            if (ranuraDeposito == null)
            {
                return NotFound();
            }

            _UnityOfWork.RanuraDepositos.Remove(ranuraDeposito);
            _UnityOfWork.SaveChanges();

            return Ok(ranuraDeposito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RanuraDepositoExists(int id)
        {
            return _UnityOfWork.RanuraDepositos.GetEntity().Count(e => e.RanuraDepositoId == id) > 0;
        }
    }
}