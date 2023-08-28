using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominusApi.Models
{
    public class Entrega
    {
        public int Id { get; set; }
        public string Remetente { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataRetirada { get; set; }  
        //public Morador Morador { get; set; }
        //public int IdMorador { get; set; }      
    }
}