using CalculadoraFinanceira.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CalculadoraFinanceira.Models.FluentAPI
{
    public class DespesaMap : EntityTypeConfiguration<Despesa>
    {
        public DespesaMap()
        {
            ToTable("TB_DESPESA");
            HasKey(despesa => despesa.Id).
                    Property(despesa => despesa.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //one-to-many
            HasRequired<ListarDespesa>(despesa => despesa.ListarDespesa)
                .WithMany(tipoDespesa => tipoDespesa.Despesass)
                .HasForeignKey<int>(despesa => despesa.TipoDespesaId);

            Property(despesa => despesa.Descricao).HasMaxLength(255).IsRequired().HasColumnType("Varchar");
            Property(despesa => despesa.Caracteristica).IsRequired().HasColumnType("int");
            Property(despesa => despesa.Situacao).IsRequired().HasColumnType("bit");
        }
    }
}