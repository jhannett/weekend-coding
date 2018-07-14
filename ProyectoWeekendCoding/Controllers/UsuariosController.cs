using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ProyectoWeekendCoding.Models;

namespace ProyectoWeekendCoding.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly ProyectoWeekendCodingContext datos = new ProyectoWeekendCodingContext();

        // GET: api/Usuarios
        public IQueryable<Usuario> GetUsuarios()
        {
            return this.datos.Usuarios;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = this.datos.Usuarios.Find(id);
            if (usuario == null)
            {
                return this.NotFound();
            }

            return this.Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != usuario.Id)
            {
                return this.BadRequest();
            }

            this.datos.Entry(usuario).State = EntityState.Modified;

            try
            {
                this.datos.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.UsuarioExists(id))
                {
                    return this.NotFound();
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Usuarios
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.datos.Usuarios.Add(usuario);
            this.datos.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario usuario = this.datos.Usuarios.Find(id);
            if (usuario == null)
            {
                return this.NotFound();
            }

            this.datos.Usuarios.Remove(usuario);
            this.datos.SaveChanges();

            return this.Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.datos.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return this.datos.Usuarios.Count(e => e.Id == id) > 0;
        }
    }
}