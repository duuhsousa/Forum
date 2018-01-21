using Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    public class LoginController:Controller
    {
        DAOLogin daoLogin = new DAOLogin();

        [HttpPost]
        public string Post([FromBody] Login sessao){
            string resultado = daoLogin.Validar(sessao);
            return resultado;
        }
        
    }
}