using System.Data.Entity.ModelConfiguration;
using WebRastreamento.Domain;

namespace WebRastreamento.Infra.Mappings
{
    public class AcessoMap : EntityTypeConfiguration<Acesso>
    {
        public AcessoMap()
        {
            ToTable("Acesso");

            HasKey(x => x.Id);

            Property(x => x.Data).IsRequired();
            Property(x => x.Pagina).IsRequired();

            HasRequired(x => x.Visitante);
        }
    }
}
