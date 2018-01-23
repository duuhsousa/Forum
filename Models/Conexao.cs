using System.Data.SqlClient;

namespace Forum.Models
{
    public abstract class Conexao
    {
        /// <summary>
        /// Objeto Utilizado para estabelecer a conexão com o
        /// servidor de banco de dados.
        /// </summary>
        protected SqlConnection conn = null;
        /// <summary>
        /// Objeto utilizado para executar comandos de SQL, como SELECT, UPDATE, etc
        /// </summary>
        protected SqlCommand cmd = null;
        /// <summary>
        /// Objeto utilizado para guardar os retornos do select realizados
        /// nas tabelas do banco de dados
        /// </summary>
        protected SqlDataReader dr = null;
        /// <summary>
        /// O m´todo caminho retorna o local do banco de dados
        /// </summary>
        /// <returns>Retorna uma string de conexão com o banco</returns>
        protected static string Caminho(){
            return @"Data Source=localhost,1433;Initial Catalog=Forum;user id=sa;password=DockerSql@2018";
        }
    }
}