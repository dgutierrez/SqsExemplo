using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }
        [Required]
        public float Altura { get; set; }
    }
}
