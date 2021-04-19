using System.Collections.Generic;

namespace RDC.Tests.PersonalFinances.Models
{
    public class Totalizacao
    {
        public object Totalizadores { get; set; }
        public IEnumerable<Lancamento> Lancamentos { get; set; }
    }
}
