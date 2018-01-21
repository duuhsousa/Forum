using System.Data.SqlClient;
using System.Linq;

namespace Forum.Models
{
    public class DAOLogin
    {
        DAOUsuarios daoUsuario = new DAOUsuarios();
        public string Validar(Login sessao){
            string resultado = "Falha no Login";
            Usuarios usuario = new Usuarios();
            usuario = daoUsuario.Listar().Where(x=>x.login==sessao.login).FirstOrDefault();
            if(usuario.senha == sessao.senha){
                resultado = "Sucesso!";
            }
            return resultado;
        }
    }
}