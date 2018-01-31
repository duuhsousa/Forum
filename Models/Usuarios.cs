using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class Usuarios
    {
        [Key]
        public int idUsuario { get; set; }

        [Display(Name="Nome do cidadão")]
        [Required(ErrorMessage="Se esse campo existe é para preenher")]
        [MinLength(2,ErrorMessage="Esse é seu nome mesmo ?")]
        [MaxLength(20,ErrorMessage="Por acaso isso é um livro?")]
        public string nomeUsuario { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        public string login { get; set; }
        
        [MinLength(8)]
        [MaxLength(12)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$",ErrorMessage="Digite ao menos 8 caracteres, entre eles minúsculas, maiúsculas, especiais e números")]
        public string senha { get; set; }
        public DateTime dataCadastro { get; set; }
    }
}