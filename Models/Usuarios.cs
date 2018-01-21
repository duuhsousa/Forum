using System;

namespace Forum.Models
{
    public class Usuarios
    {
        public int idUsuario { get; set; }
        public string nomeUsuario { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public DateTime dataCadastro { get; set; }
    }
}