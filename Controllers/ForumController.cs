using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Forum.Models;
using System;

namespace Forum.Controllers
{

    [Route("api/[controller]")]
    public class ForumController:Controller
    {
        DAOUsuarios daoUsuario = new DAOUsuarios();

        [HttpGet]
        public IEnumerable<Usuarios> Get(){
            return daoUsuario.Listar();
        }

        [HttpGet("{id}",Name="UsuarioAtual")]
        public Usuarios Get(int id){
            return daoUsuario.Listar().Where(x=>x.idUsuario==id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuarios usuario){
            daoUsuario.Cadastrar(usuario);
            return CreatedAtRoute("UsuarioAtual", new {id=usuario.idUsuario}, usuario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id){
            try{
                daoUsuario.Excluir(id);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Usuarios usuario){
            daoUsuario.Atualizar(usuario);
            return CreatedAtRoute("UsuarioAtual", new {id=usuario.idUsuario}, usuario);
        }
    }
}