using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace Projeto_cnpj.Models
{
    public class historico
    {
        [Key]
        public int id { get; set; }
        public int data_consulta { get; set; }


        public String cnpj { get; set; }
        public String nome { get; set; }

    }
}