using System.Data.SqlClient;
using System.Linq;

namespace Forum.Models
{
    public class DAOLogin
    {
        DAOUsuarios daoUsuario = new DAOUsuarios();
        public Login Validar(Login sessao){
            sessao.status = false;
            Usuarios usuario = new Usuarios();
            usuario = daoUsuario.Listar().Where(x=>x.login==sessao.login).FirstOrDefault();
            if(usuario.senha == sessao.senha){
                sessao.status = true;
            }
            return sessao;
        }
    }
}