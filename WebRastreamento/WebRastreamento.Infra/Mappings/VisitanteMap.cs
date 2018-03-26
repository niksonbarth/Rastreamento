using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRastreamento.Domain;

namespace WebRastreamento.Infra.Mappings
{
    public class VisitanteMap : EntityTypeConfiguration<Visitante>
    {
        public VisitanteMap()
        {
            ToTable("Visitante");

            HasKey(x => x.Email );
            
        }
    }
}
