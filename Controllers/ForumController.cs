using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Forum.Models;
using System;

namespace Forum.Controllers
{

    [Route("api/Usuario")]
    [Produces("application/json")]
    public class ForumController:Controller
    {
        DAOUsuarios daoUsuario = new DAOUsuarios();

        [HttpGet]
        public IEnumerable<Usuarios> Get(){
            return daoUsuario.Listar();
        }

        [HttpGet("{id}",Name="UsuarioAtual")]
        public IActionResult Get(int id){
            var rs = new JsonResult(daoUsuario.Listar().Where(x=>x.idUsuario==id).FirstOrDefault());
            rs.ContentType = "application/json";
            if(rs.Value==null){
                rs.StatusCode = 204;
                rs.Value = "O ID "+id+" não foi encontrado.";
            }else{
                rs.StatusCode = 200;
            }
            return Json(rs);
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