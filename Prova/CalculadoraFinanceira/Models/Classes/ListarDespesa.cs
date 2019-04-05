using CalculadoraFinanceira.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalculadoraFinanceira.Models.Classes
{
    public class ListarDespesa // : IValidatableObject
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public Boolean Situacao { get; set; }
        public string Caracteristica { get; set; }
        public ICollection<Despesa> Despesass { get; set; }


     /*   public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new ListarDespesaValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(erro => new ValidationResult(erro.ErrorMessage, new[] { erro.PropertyName }));
        } */
        
    }
}