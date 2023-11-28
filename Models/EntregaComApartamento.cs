using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CondominusApi.Models
{
    [NotMapped]
    public class EntregaComApartamento
    {
        public int Id { get; set; }
        public string Destinatario { get; set; }
        public DateTime? DataEntrega { get; set; }
        public DateTime? DataRetirada { get; set; }
        public int IdApartamento { get; set; }

        // Número do apartamento
        public string NumeroApartamento { get; set; }
    }
}