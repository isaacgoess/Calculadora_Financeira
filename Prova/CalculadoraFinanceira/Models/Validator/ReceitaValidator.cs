using CalculadoraFinanceira.Models.Classes;
using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace CalculadoraFinanceira.Models.Validator
{
    public class ReceitaValidator : AbstractValidator<Receita>
    {
        CalculadoraFinanceiraContext db = null;

        public ReceitaValidator()
        {
            this.db = new CalculadoraFinanceiraContext();
            RuleFor(receita => receita.Descricao).NotEmpty().WithMessage("Descrição Obrigatória!");
            RuleFor(receita => receita.Valor).GreaterThan(0).WithMessage("Despesa precisa ser maior que zero!");
            RuleFor(receita => receita.DataRecebimento).Must(DataValida).WithMessage("Data inválida!");
            RuleFor(receita => receita.Descricao).Length(255).WithMessage("Máximo de 255 caracteres!");
            RuleFor(receita => receita.Parcela)
                .Must(p => p.FormaReceita == ParcelaReceita.TipoParcela.Unica && p.NumeroParcelas == 1).WithMessage("Receita não parcelada!");

            RuleFor(receita => receita.Parcela)
                .Must(p => p.FormaReceita == ParcelaReceita.TipoParcela.Parcelado && p.NumeroParcelas > 1).WithMessage("Pelo menos 2 parcelas");

        }


        private bool DataValida(DateTime data)
        {
            string expressao = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$";

            Regex rg = new Regex(expressao);
            return rg.IsMatch(data.ToString("dd/MM/yyyy"));
        }

    }


}