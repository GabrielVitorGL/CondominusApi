using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominusApi.Models
{
    public class UsuarioPessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string RedefinicaoSenha { get; set; }
        public DateTime DataEnvioCodigo { get; set; }
        public Condominio Condominio { get; set; }
        public int IdCondominio { get; set; }
    }
}