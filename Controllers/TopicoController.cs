using System.Collections.Generic;
using System.Linq;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    public class TopicoController:Controller
    {
        DAOTopicos daoTopico = new DAOTopicos();

        [HttpGet]
        public IEnumerable<Topicos> Get(){
            return daoTopico.Listar();
        }

        [HttpGet("{id}",Name="UsuarioAtual")]
        public Topicos Get(int id){
            return daoTopico.Listar().Where(x=>x.idTopico==id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Topicos topico){
            daoTopico.Cadastrar(topico);
            return CreatedAtRoute("UsuarioAtual", new {id=topico.idTopico}, topico);
        }
    }
}