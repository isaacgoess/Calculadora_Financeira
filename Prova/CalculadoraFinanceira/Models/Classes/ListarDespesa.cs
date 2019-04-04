using System;
using System.Collections.Generic;

namespace CalculadoraFinanceira.Models.Classes
{
    public class ListarDespesa
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public Boolean Situacao { get; set; }
        public ICollection<Despesa> Despesass { get; set; }
    }
}