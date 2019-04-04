using CalculadoraFinanceira.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CalculadoraFinanceira.Models.FluentAPI
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {

            ToTable("TB_CLIENTE");
            HasKey(c => c.Id).
                    Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nome).HasMaxLength(255).IsRequired().HasColumnType("VarChar");
            Property(c => c.DataAniversario).IsRequired().HasColumnType("Datetime2");
            Property(c => c.Email).HasMaxLength(255).IsRequired().HasColumnType("Varchar");
            Ignore(c => c.ConfirmarSenha);
            Ignore(c => c.ConfirmarEmail);
        }
    }
}