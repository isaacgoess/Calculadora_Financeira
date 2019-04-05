using CalculadoraFinanceira.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;

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
                    #region Tipo Despesas
                    IList<ListarDespesa> tipoDespesas = new List<ListarDespesa>();

                    tipoDespesas.Add(new ListarDespesa() { Nome = "Alimentação", Situacao = true, Caracteristica = "a" });
                    tipoDespesas.Add(new ListarDespesa() { Nome = "Educação", Situacao = true, Caracteristica = "a" });
                    tipoDespesas.Add(new ListarDespesa() { Nome = "Saúde", Situacao = true, Caracteristica = "a" });
                    tipoDespesas.Add(new ListarDespesa() { Nome = "Moradia", Situacao = true, Caracteristica = "a" });

                    context.ListarDespesas.AddRange(tipoDespesas);
                    context.SaveChanges();
                    #endregion

                    #region  Tipo Receitas
                    IList<TipoReceita> tipoReceitas = new List<TipoReceita>();
                    tipoReceitas.Add(new TipoReceita() { Nome = "Salário" });
                    tipoReceitas.Add(new TipoReceita() { Nome = "Restituição IR" });
                    tipoReceitas.Add(new TipoReceita() { Nome = "Indenização" });
                    tipoReceitas.Add(new TipoReceita() { Nome = "Transferência entre Contas" });

                    context.TipoReceitas.AddRange(tipoReceitas);
                    context.SaveChanges();
                    #endregion


                    #region Despesas
                    List<Despesa> despesas = new List<Despesa>();
                    Despesa despesa = new Despesa();
                    despesa.Caracteristica = Despesa.CaracteristicaDespesa.Fixa;
                    despesa.Descricao = "Energia - ENERGISA";
                    despesa.Situacao = true;
                    despesa.ListarDespesa = tipoDespesas[3];
                    despesa.TipoDespesaId = tipoDespesas[3].Id;
                    despesa.Valor = 400;

                    despesas.Add(despesa);

                    despesa = new Despesa();
                    despesa.Caracteristica = Despesa.CaracteristicaDespesa.Fixa;
                    despesa.Descricao = "Água - DESO";
                    despesa.Situacao = true;
                    despesa.ListarDespesa = tipoDespesas[3];
                    despesa.TipoDespesaId = tipoDespesas[3].Id;
                    despesa.Valor = 140;

                    despesas.Add(despesa);

                    despesa = new Despesa();
                    despesa.Caracteristica = Despesa.CaracteristicaDespesa.Fixa;
                    despesa.Descricao = "Condomínio";
                    despesa.Situacao = true;
                    despesa.ListarDespesa = tipoDespesas[3];
                    despesa.TipoDespesaId = tipoDespesas[3].Id;
                    despesa.Valor = 500;

                    despesas.Add(despesa);

                    despesa = new Despesa();
                    despesa.Caracteristica = Despesa.CaracteristicaDespesa.Fixa;
                    despesa.Descricao = "Supermercado";
                    despesa.Situacao = true;
                    despesa.ListarDespesa = tipoDespesas[0];
                    despesa.TipoDespesaId = tipoDespesas[0].Id;
                    despesa.Valor = 1000;

                    despesas.Add(despesa);
                    context.Despesas.AddRange(despesas);
                    context.SaveChanges();
                }

                //Comitando a transação
                //                    db();
                #endregion
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