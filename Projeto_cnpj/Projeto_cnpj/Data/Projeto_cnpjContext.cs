using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto_cnpj.Data
{
    public class Projeto_cnpjContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Projeto_cnpjContext() : base("name=Projeto_cnpjContext")
        {
        }

        public System.Data.Entity.DbSet<Projeto_cnpj.Models.historico1> historicoes { get; set; }
    }
}
