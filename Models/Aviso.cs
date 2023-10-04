using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominusApi.Models
{
    public class Aviso
    {
        public int Id { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}