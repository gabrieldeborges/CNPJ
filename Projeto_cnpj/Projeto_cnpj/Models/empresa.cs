using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_cnpj.Models
{
    public class empresa
    {

        public IList<empresa> lista { get; set; }
        public int numConsulta { get; set; }
        public String nome { get; set; }
        public String pais_origem { get; set; }
        public String bairro { get; set; }
        public String situacao { get; set; }
        public String abertura { get; set; }
        public String municipio { get; set; }

        public String cep { get; set; }
    }
}