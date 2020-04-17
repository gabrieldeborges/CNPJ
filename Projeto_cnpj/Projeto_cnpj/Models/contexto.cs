using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto_cnpj.Models
{
    public class contexto: DbContext
    {
        public DbSet<historico> Historicos { get; set; }

    }
}