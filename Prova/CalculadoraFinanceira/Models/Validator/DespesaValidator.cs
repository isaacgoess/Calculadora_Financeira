using CalculadoraFinanceira.Models.Classes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculadoraFinanceira.Models.Validator
{
    public class DespesaValidator : AbstractValidator<Despesa>
    {
        CalculadoraFinanceiraContext db = null;

        public DespesaValidator()
        {
            this.db = new CalculadoraFinanceiraContext();
            RuleFor(listarDespesa => listarDespesa.Descricao).NotEmpty().WithMessage("Descrição Obrigatória!");
            RuleFor(listarDespesa => listarDespesa.Valor).GreaterThan(0).WithMessage("Despesa precisa ser maior que zero!");
            RuleFor(listarDespesa => listarDespesa.TipoDespesaId).Must(NotExistsTipoDespesa).WithMessage("Tipo de Despesa inexistente!");
        }

        private bool UniqueName(String nome)
        {
            var result = this.db.ListarDespesas
                                 .Where(x => x.Nome.ToLower() == nome.ToLower())
                                 .Count();

            return result == 0;
        }


        /// <summary>
        /// Método que valida se existe um tipo de despesa
        /// </summary>
        /// <param name="tipoDespesaId">Id único de uma despesa</param>
        /// <returns></returns>
        private bool NotExistsTipoDespesa(int tipoDespesaId)
        {
            var result = this.db.ListarDespesas
                                 .Where(x => x.Id == tipoDespesaId)
                                 .Count();

            return result > 0;
        }
    }
}

