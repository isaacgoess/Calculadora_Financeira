﻿using CalculadoraFinanceira.Models.Classes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CalculadoraFinanceira.Models.Validator
{
    public class ListarDespesaValidator : AbstractValidator<ListarDespesa>
    {
      //  CalculadoraFinanceiraContext db = null;

        public ListarDespesaValidator()
        {
        //    this.db = new CalculadoraFinanceiraContext();
            RuleFor(listarDespesa => listarDespesa.Nome).MaximumLength(255).WithMessage("Máximo de 255 caracteres");
           // RuleFor(listarDespesa => listarDespesa.Nome).Must(UniqueName).WithMessage("Tipo de Categoria de Despesa Cadastrada");
        }


        //private bool UniqueName(String nome)
        //{
        //    var result = this.db.ListarDespesas
        //                         .Where(x => x.Nome.ToLower() == nome.ToLower())
        //                         .Count();

        //    return result == 0;
        //}

    }
}