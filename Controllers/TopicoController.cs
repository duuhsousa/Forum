using System;
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

        [HttpGet("{id}",Name="TopicoAtual")]
        public Topicos Get(int id){
            return daoTopico.Listar().Where(x=>x.idTopico==id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Topicos topico){
            daoTopico.Cadastrar(topico);
            return CreatedAtRoute("TopicoAtual", new {id=topico.idTopico}, topico);
        }

        [HttpDelete("{id}")]
        public void Delete(int id){
            try{
                daoTopico.Excluir(id);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Topicos topico){
            daoTopico.Atualizar(topico);
            return CreatedAtRoute("UsuarioAtual", new {id=topico.idTopico}, topico);
        }
    }
}