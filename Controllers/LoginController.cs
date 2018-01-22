using Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController:Controller
    {
        DAOLogin daoLogin = new DAOLogin();

        [HttpPost]
        public bool Post([FromBody] Login sessao){
            var resultado = daoLogin.Validar(sessao);
            return sessao.status;
        }
        
    }
}