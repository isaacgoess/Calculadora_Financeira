using CalculadoraFinanceira.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CalculadoraFinanceira.Models.FluentAPI
{
    public class ListarDespesaMap : EntityTypeConfiguration<ListarDespesa>
    {
        public ListarDespesaMap()
        {
            ToTable("TB_LISTAR_DESPESA");
            HasKey(tipo => tipo.Id).
                    Property(Cliente => Cliente.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(tipo => tipo.Nome).HasMaxLength(255).IsRequired().HasColumnType("Varchar");
            Property(tipo => tipo.Situacao).IsRequired().HasColumnType("bit");
        }
    }
}