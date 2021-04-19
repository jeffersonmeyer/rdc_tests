using System;
using System.ComponentModel.DataAnnotations;

namespace RDC.Tests.PersonalFinances.Models
{
    public class Lancamento
    {
        [Required]
        public DateTime Data { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(50)]
        public string Conta { get; set; }

        [Required]
        [AtributoTipoConta]
        public string Tipo { get; set; }
    }
}
