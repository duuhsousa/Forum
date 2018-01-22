using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models
{
    public class DAOTopicos
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        string conexao = @"Data Source=localhost,1433;Initial Catalog=Forum;user id=sa;password=DockerSql@2018";

        public List<Topicos> Listar(){
            List<Topicos> topico = new List<Topicos>();
            
            try{
                conn = new SqlConnection();
                conn.ConnectionString = conexao;
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from TopicoForum";

                dr = cmd.ExecuteReader();

                while(dr.Read()){
                    topico.Add(new Topicos(){
                        idTopico = dr.GetInt32(0),
                        titulo = dr.GetString(1),
                        descricao = dr.GetString(2),
                        dataCadastro = dr.GetDateTime(3),
                    });
                }
                
            }catch(SqlException ex){
                throw new Exception(ex.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                conn.Close();
            }

            return topico;
        } 

        public bool Cadastrar(Topicos topico){
            bool resultado = false;
            try{
                conn = new SqlConnection(conexao);
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO TopicoForum (titulo,descricao) values(@t,@d)";
                
                cmd.Parameters.AddWithValue("@t",topico.titulo);
                cmd.Parameters.AddWithValue("@d",topico.descricao);

                int r = cmd.ExecuteNonQuery();

                if(r>0){
                    resultado=true;
                }

                cmd.Parameters.Clear();
            } 
            catch(SqlException ex){
                throw new Exception(ex.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                conn.Close();
            }
            return resultado;
        }
    }
}