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
    public class RetirosController : ApiController
    {
        //private CajeroDbContext db = new CajeroDbContext();
        private readonly IUnityOfWork _UnityOfWork;


        public RetirosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }



        /*     // GET: api/Retiros
             public IQueryable<Retiro> GetRetiro()
             {
                 return _UnityOfWork.Retiro;
             }
             */

        [HttpGet]
        public IHttpActionResult Get()
        {
            var retiros = _UnityOfWork.Retiros.GetAll();

            if (retiros == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);



            return Ok(retiros);
        }




        // GET: api/Retiros/5
        [ResponseType(typeof(Retiro))]
        public IHttpActionResult GetRetiro(int id)
        {
            Retiro retiro = _UnityOfWork.Retiros.Get(id);
            if (retiro == null)
            {
                return NotFound();
            }

            return Ok(retiro);
        }

        // PUT: api/Retiros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRetiro(int id, Retiro retiro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != retiro.RetiroId)
            {
                return BadRequest();
            }

            _UnityOfWork.StateModified(retiro);

            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RetiroExists(id))
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

        /*   // POST: api/Retiros
           [ResponseType(typeof(Retiro))]
           public IHttpActionResult PostRetiro(Retiro retiro)
           {
               if (!ModelState.IsValid)
               {
                   return BadRequest(ModelState);
               }

               _UnityOfWork.Retiros.Add(retiro);
               _UnityOfWork.SaveChanges();

               return CreatedAtRoute("DefaultApi", new { id = retiro.RetiroId }, retiro);
           }


       */

        [HttpPost]
        public IHttpActionResult Create(Retiro retiros)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //var floreria = Mapper.Map<FloreriaDto, Florerias>(floreriaDTO);

            _UnityOfWork.Retiros.Add(retiros);

            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RetiroExists(retiros.RetiroId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = retiros.RetiroId }, retiros);
        }





        // DELETE: api/Retiros/5
        [ResponseType(typeof(Retiro))]
        public IHttpActionResult DeleteRetiro(int id)
        {
            Retiro retiro = _UnityOfWork.Retiros.Get(id);
            if (retiro == null)
            {
                return NotFound();
            }

            _UnityOfWork.Retiros.Remove(retiro);
            _UnityOfWork.SaveChanges();

            return Ok(retiro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RetiroExists(int id)
        {
            return _UnityOfWork.Retiros.GetEntity().Count(e => e.RetiroId == id) > 0;
        }
    }
}