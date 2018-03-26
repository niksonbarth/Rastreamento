using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRastreamento.Domain
{
    public class Acesso
    {
        public int Id { get; set; }
        public string Pagina { get; set; }
        public DateTime Data { get; set; }
        public string VisitanteEmail { get; set; }
        public virtual Visitante Visitante { get; set; }
    }
}
