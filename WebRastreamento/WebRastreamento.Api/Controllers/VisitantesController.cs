using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebRastreamento.Domain;
using WebRastreamento.Infra.DataContext;

namespace WebRastreamento.Api.Controllers
{
    [EnableCors(origins: "http://localhost:3000,http://localhost:3001", headers: "*", methods: "*")]
    //[EnableCors(origins: "http://192.168.0.14", headers: "*", methods: "*")]
    public class VisitantesController : ApiController
    {
        private WebRastreamentoDataContext db = new WebRastreamentoDataContext();

        // GET: api/Visitantes
        [Route("Visitantes")]
        public IQueryable<Visitante> GetVisitantes()
        {
            return db.Visitantes;
        }

        // GET: api/Visitantes/5
        [Route("Visitantes/{id}")]
        [ResponseType(typeof(Visitante))]
        public IHttpActionResult GetVisitante(string id)
        {
            Visitante visitante = db.Visitantes.Find(id);
            if (visitante == null)
            {
                return NotFound();
            }

            return Ok(visitante);
        }

        // POST: api/Visitantes
        [Route("Visitantes")]
        [ResponseType(typeof(Visitante))]
        public HttpResponseMessage PostVisitante(Visitante visitante)
        {
            if(visitante == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Visitantes.Add(visitante);
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VisitanteExists(visitante.Email))
                {
                    return Request.CreateResponse(HttpStatusCode.Conflict, "E-mail já cadastrado");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir visitante");
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, visitante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitanteExists(string id)
        {
            return db.Visitantes.Count(e => e.Email == id) > 0;
        }
    }
}