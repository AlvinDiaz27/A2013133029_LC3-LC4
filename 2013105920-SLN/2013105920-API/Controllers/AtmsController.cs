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
    public class AtmsController : ApiController
    {
        //  private CajeroDbContext db = new CajeroDbContext();
        private readonly IUnityOfWork _UnityOfWork;


        public AtmsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
      

          
        // GET: api/Atms
        /*  public IQueryable<Atm> GetAtm()
          {
              return db.Atm;
          }
          */


        [HttpGet]
        public IHttpActionResult Get()
        {
            var atm = _UnityOfWork.ATMs.GetAll();

            if (atm == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);



            return Ok(atm);
        }




        // GET: api/Atms/5
        [ResponseType(typeof(Atm))]
        public IHttpActionResult GetAtm(int id)
        {
            Atm atm = _UnityOfWork.ATMs.Get(id);
            if (atm == null)
            {
                return NotFound();
            }

            return Ok(atm);
        }

        // PUT: api/Atms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtm(int id, Atm atm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atm.AtmId)
            {
                return BadRequest();
            }

            _UnityOfWork.StateModified(atm);

            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtmExists(id))
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

        // POST: api/Atms
        [ResponseType(typeof(Atm))]
        public IHttpActionResult PostAtm(Atm atm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _UnityOfWork.ATMs.Add(atm);
            _UnityOfWork.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = atm.AtmId }, atm);
        }

        // DELETE: api/Atms/5
        [ResponseType(typeof(Atm))]
        public IHttpActionResult DeleteAtm(int id)
        {
            Atm atm = _UnityOfWork.ATMs.Get(id);
            if (atm == null)
            {
                return NotFound();
            }

            _UnityOfWork.ATMs.Remove(atm);
            _UnityOfWork.SaveChanges();

            return Ok(atm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AtmExists(int id)
        {
            return _UnityOfWork.ATMs.GetEntity().Count(e => e.AtmId == id) > 0;
        }
    }
}