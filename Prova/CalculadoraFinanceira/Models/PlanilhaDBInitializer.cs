using CalculadoraFinanceira.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalculadoraFinanceira.Models
{
    public class PlanilhaDBInitializer : DropCreateDatabaseAlways<CalculadoraFinanceiraContext>
    {
        protected override void Seed(CalculadoraFinanceiraContext context)
        {
            using (var dbTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    IList<ListarDespesa> listarDespesas = new List<ListarDespesa>();

                    listarDespesas.Add(new ListarDespesa() { Nome = "Alimentação", Situacao = true });
                    listarDespesas.Add(new ListarDespesa() { Nome = "Educação", Situacao = true });
                    listarDespesas.Add(new ListarDespesa() { Nome = "Saúde", Situacao = true });

                    context.ListarDespesas.AddRange(listarDespesas);

                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    dbTransaction.Rollback();
                    throw;
                }
                finally
                {
                    dbTransaction.Commit();
                }
            }
            base.Seed(context);
        }
    }
}