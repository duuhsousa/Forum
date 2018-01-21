using System;

namespace Forum.Models
{
    public class Topicos
    {
        public int idTopico { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public DateTime dataCadastro { get; set; }
    }
}