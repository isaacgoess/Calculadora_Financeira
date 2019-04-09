using CalculadoraFinanceira.Models.Classes;
using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace CalculadoraFinanceira.Models.Validator
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Email).EmailAddress().WithMessage("E-mail inválido!");
            RuleFor(cliente => cliente.Email).Equal(cliente => cliente.ConfirmarEmail).WithMessage("Os e-mails precisam ser iguais!");
            RuleFor(cliente => cliente.Senha).NotEmpty().WithMessage("Senha Obrigatória");
            RuleFor(cliente => cliente.Senha).Equal(cliente => cliente.ConfirmarSenha).WithMessage("Senhas precisam ser Iguais");
            RuleFor(cliente => cliente.DataAniversario).Must(ValidarData).WithMessage("Data inválida");
        }

        private bool ValidarData(DateTime date)
        {
            string expressao = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$";

            Regex rg = new Regex(expressao);
            return rg.IsMatch(date.ToString("dd/MM/yyyy"));
        }
    }
}