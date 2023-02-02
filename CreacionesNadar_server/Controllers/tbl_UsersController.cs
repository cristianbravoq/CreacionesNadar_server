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
using CreacionesNadar_server.Models;

namespace CreacionesNadar_server.Controllers
{
    public class tbl_UsersController : ApiController
    {
        private Model1 db = new Model1();

        //En el controlador programamos las peticiones que se realizaran en nuestra api,
        //en nuestro caso tenemos la posibilidades de traer todos los datos, obtener un dato por id,
        //crear un nuevo usuario en nuestra tabla, modificar un dato y eliminarlo, de la misma manera que
        //lo enumeramos en este texto, lo podras encontrar en el mismo orden en este archivo

        //Esta api rest se realizo con entityFramework que nos ayuda a modelar cualquier tabla creada en alguna base de datos
        //de la misma manera el controlador lo podemos crear creando una conexion que apunte a nuestra tabla en la base de datos.

        // GET: api/tbl_Users
        public IQueryable<tbl_Users> Gettbl_Users()
        {
            return db.tbl_Users;
        }

        // GET: api/tbl_Users/5
        [ResponseType(typeof(tbl_Users))]
        public IHttpActionResult Gettbl_Users(int id)
        {
            tbl_Users tbl_Users = db.tbl_Users.Find(id);
            if (tbl_Users == null)
            {
                return NotFound();
            }

            return Ok(tbl_Users);
        }

        // PUT: api/tbl_Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Users(int id, tbl_Users tbl_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Users.id_DataUser)
            {
                return BadRequest();
            }

            db.Entry(tbl_Users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_UsersExists(id))
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

        // POST: api/tbl_Users
        [ResponseType(typeof(tbl_Users))]
        public IHttpActionResult Posttbl_Users(tbl_Users tbl_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Users.Add(tbl_Users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Users.id_DataUser }, tbl_Users);
        }

        // DELETE: api/tbl_Users/5
        [ResponseType(typeof(tbl_Users))]
        public IHttpActionResult Deletetbl_Users(int id)
        {
            tbl_Users tbl_Users = db.tbl_Users.Find(id);
            if (tbl_Users == null)
            {
                return NotFound();
            }

            db.tbl_Users.Remove(tbl_Users);
            db.SaveChanges();

            return Ok(tbl_Users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_UsersExists(int id)
        {
            return db.tbl_Users.Count(e => e.id_DataUser == id) > 0;
        }
    }
}