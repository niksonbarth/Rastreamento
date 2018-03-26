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
    [EnableCors(origins: "http://localhost:3000,http://localhost:3001", headers: "*", methods: "*")]
    //[EnableCors(origins: "http://192.168.0.14", headers: "*", methods: "*")]
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
        [Route("Acessos/{email}")]
        [ResponseType(typeof(Acesso))]
        public IQueryable<Acesso> GetAcessoes(string email)
        {
            return db.Acessoes.Where(x => x.VisitanteEmail.Replace(".com",string.Empty).Replace(".com.br",string.Empty) == email);
        }

        // POST: api/Acessos
        [Route("Acessos")]
        [ResponseType(typeof(Acesso))]
        public HttpResponseMessage PostAcesso(Acesso acesso)
        {
            if(acesso == null || string.IsNullOrEmpty(acesso.Pagina))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var url = acesso.Pagina.Replace("/", string.Empty);
            if (string.IsNullOrEmpty(url))
                url = "Home";

            acesso.Pagina = url;

            try
            {
                db.Acessoes.Add(acesso);
                db.SaveChanges();

                var result = acesso;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(System.Exception e)
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