using System;

namespace Forum.Models
{
    public class Postagens
    {
        public int idPostagem { get; set; }
        public int idTopico { get; set; }
        public int idUsuario { get; set; }
        public string mensagem { get; set; }
        public DateTime dataPublicacao { get; set; }
    }
}