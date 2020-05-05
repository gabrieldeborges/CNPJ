using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_cnpj.Models
{
    public class historico1
    {
        [Key]
        public int id { get; set; }
        public String data_consulta { get; set; }
        public String fantasia { get; set; }
        public String cnpj { get; set; }
    }
}