using CalculadoraFinanceira.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CalculadoraFinanceira.Models.Classes
{
    public class TipoReceita : IValidatableObject
    {
        public TipoReceita()
        {
            this.Receitas = new HashSet<Receita>();
        }
        public int Id { get; set; }
        public String Nome { get; set; }
        public virtual ICollection<Receita> Receitas { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            var validator = new TipoReceitaValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(erro => new ValidationResult(erro.ErrorMessage, new[] { erro.PropertyName }));
        }
    }
}