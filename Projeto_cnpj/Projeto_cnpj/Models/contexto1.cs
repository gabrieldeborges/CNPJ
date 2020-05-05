using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto_cnpj.Models
{
    public class contexto1 : DbContext
    {
        public DbSet<historico1> H { get; set; }

    }
}