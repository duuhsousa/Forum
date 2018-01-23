using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    public class PostagemController:Controller
    {
        DAOPostagem daoPostagem = new DAOPostagem();

        [HttpGet]
        public IEnumerable<Postagens> Get(){
            return daoPostagem.Listar();
        }

        [HttpGet("{id}",Name="PostagemAtual")]
        public Postagens Get(int id){
            return daoPostagem.Listar().Where(x=>x.idPostagem==id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Postagens postagem){
            daoPostagem.Cadastrar(postagem);
            return CreatedAtRoute("PostagemAtual", new {id=postagem.idPostagem}, postagem);
        }

        [HttpDelete("{id}")]
        public void Delete(int id){
            try{
                daoPostagem.Excluir(id);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Postagens postagem){
            daoPostagem.Atualizar(postagem);
            return CreatedAtRoute("PostagemAtual", new {id=postagem.idPostagem}, postagem);
        }
    }
}