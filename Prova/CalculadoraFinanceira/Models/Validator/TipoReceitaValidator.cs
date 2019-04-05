using CalculadoraFinanceira.Models.Classes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculadoraFinanceira.Models.Validator
{
    public class TipoReceitaValidator : AbstractValidator<TipoReceita>
    {
        CalculadoraFinanceiraContext db = null;

        public TipoReceitaValidator()
        {
            this.db = new CalculadoraFinanceiraContext();
            RuleFor(tipoDespesa => tipoDespesa.Nome).MaximumLength(255).WithMessage("Máximo de 255 caracteres");
            RuleFor(tipoDespesa => tipoDespesa.Nome).Must(UniqueName).WithMessage("Tipo de Categoria de Despesa Cadastrada");
        }

        private bool UniqueName(String nome)
        {
            var result = this.db.TipoReceitas
                                 .Where(x => x.Nome.ToLower() == nome.ToLower())
                                 .Count();

            return result == 0;
        }

    }


}