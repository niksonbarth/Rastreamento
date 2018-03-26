using System.Data.Entity;
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
    //[EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    [EnableCors(origins: "http://192.168.0.14", headers: "*", methods: "*")]
    public class AcessosController : ApiController
    {
        private WebRastreamentoDataContext db = new WebRastreamentoDataContext();

        // GET: api/Acessos
        [Route("Acessos")]
        public IQueryable<Acesso> GetAcessoes()
        {
            return db.Acessoes;
        }

        // GET: api/Acessos/5
        [Route("Acessos/{id}")]
        [ResponseType(typeof(Acesso))]
        public IHttpActionResult GetAcesso(int id)
        {
            Acesso acesso = db.Acessoes.Find(id);
            if (acesso == null)
            {
                return NotFound();
            }

            return Ok(acesso);
        }

        // POST: api/Acessos
        [Route("Acessos")]
        [ResponseType(typeof(Acesso))]
        public HttpResponseMessage PostAcesso(Acesso acesso)
        {
            if(acesso == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Acessoes.Add(acesso);
                db.SaveChanges();

                var result = acesso;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir acesso");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AcessoExists(int id)
        {
            return db.Acessoes.Count(e => e.Id == id) > 0;
        }
    }
}