using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRastreamento.Domain;
using WebRastreamento.Infra.Mappings;

namespace WebRastreamento.Infra.DataContext
{
    public class WebRastreamentoDataContext : DbContext
    {
        public WebRastreamentoDataContext() : base("WebRastreamentoConnectionString")
        {
            Database.SetInitializer<WebRastreamentoDataContext>(new WebRastreamentoDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VisitanteMap());
            modelBuilder.Configurations.Add(new AcessoMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Visitante> Visitantes { get; set; }

        public System.Data.Entity.DbSet<WebRastreamento.Domain.Acesso> Acessoes { get; set; }
    }

    public class WebRastreamentoDataContextInitializer : DropCreateDatabaseIfModelChanges<WebRastreamentoDataContext>
    {
        protected override void Seed(WebRastreamentoDataContext context)
        {
            context.Visitantes.Add(new Visitante { Email = "niksonbarth@gmail.com" });
            context.Visitantes.Add(new Visitante { Email = "usuario@gmail.com"});
            context.SaveChanges();

            context.Acessoes.Add(new Acesso { VisitanteEmail = "niksonbarth@gmail.com", Pagina = "Home", Data = DateTime.Now });
            context.Acessoes.Add(new Acesso { VisitanteEmail = "niksonbarth@gmail.com", Pagina = "Contacts", Data = DateTime.Now });
            context.Acessoes.Add(new Acesso { VisitanteEmail = "niksonbarth@gmail.com", Pagina = "About", Data = DateTime.Now });
            context.Acessoes.Add(new Acesso { VisitanteEmail = "usuario@gmail.com", Pagina = "Home", Data = DateTime.Now });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
