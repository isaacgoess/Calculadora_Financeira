using CalculadoraFinanceira.Models.FluentAPI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalculadoraFinanceira.Models
{
    public class CalculadoraFinanceiraContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public CalculadoraFinanceiraContext() : base("name=CalculadoraFinanceiraContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new DespesaMap());
            modelBuilder.Configurations.Add(new ListarDespesaMap());

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<CalculadoraFinanceira.Models.Classes.Cliente> Clientes { get; set; }
        public System.Data.Entity.DbSet<CalculadoraFinanceira.Models.Classes.Despesa> Despesas { get; set; }
        public System.Data.Entity.DbSet<CalculadoraFinanceira.Models.Classes.ListarDespesa> ListarDespesas { get; set; }
    }
}
