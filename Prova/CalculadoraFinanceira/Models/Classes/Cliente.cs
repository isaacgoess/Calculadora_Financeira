using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalculadoraFinanceira.Models.Classes
{
    public class Cliente
    {
        public int Id { get; set; }

        [Display(Name = "Nome de Usuário")]
        public String Nome { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true,
            DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Aniversário")]
        public DateTime DataAniversario { get; set; }

        [Display (Name = "E-mail")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Digite um email valido")]
        public String Email { get; set; }

        [Display(Name = "Confirmação do Email")]
        [EmailAddress]
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Os emails não se coincidem!")]
        public String ConfirmarEmail { get; set; }

        public String Senha { get; set; }

        [Display(Name = "Confirmação de Senha")]
        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage = "As senhas não se coincidem!")]
        public String ConfirmarSenha { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!this.Senha.Equals(this.ConfirmarSenha))
            {
                yield return
              new ValidationResult("Senhas precisam ser diferentes",
                                new[] { "Senha", "ConfirmacaoSenha" });
            }
            if (!this.Email.Equals(this.ConfirmarEmail))
            {
                yield return
                    new ValidationResult("Email são diferentes", new[] { "Email", "Confirmar Email" });
            }
        }
    }

}