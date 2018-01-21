using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models
{
    public class DAOUsuarios
    {
        
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        string conexao = @"Data Source=localhost,1433;Initial Catalog=Forum;user id=sa;password=DockerSql@2018";
        public List<Usuarios> Listar(){
            List<Usuarios> usuario = new List<Usuarios>();
            
            try{
                conn = new SqlConnection();
                conn.ConnectionString = conexao;
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Usuario";

                dr = cmd.ExecuteReader();

                while(dr.Read()){
                    usuario.Add(new Usuarios(){
                        idUsuario = dr.GetInt32(0),
                        nomeUsuario = dr.GetString(1),
                        login = dr.GetString(2),
                        senha = dr.GetString(3),
                        dataCadastro = dr.GetDateTime(4),
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

            return usuario;
        }

        public bool Cadastrar(Usuarios usuario){
            bool resultado = false;
            try{
                conn = new SqlConnection(conexao);
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Usuario (nomeUsuario,login,senha) values(@n,@l,@s)";
                
                cmd.Parameters.AddWithValue("@n",usuario.nomeUsuario);
                cmd.Parameters.AddWithValue("@l",usuario.login);
                cmd.Parameters.AddWithValue("@s",usuario.senha);

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

        public string Excluir(int id){
            string resultado = "";
            try{
                conn = new SqlConnection(conexao);
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Usuario where idUsuario = @id";
                
                cmd.Parameters.AddWithValue("@id",id);

                int r = cmd.ExecuteNonQuery();

                if(r>0){
                    resultado="OK";
                }

                cmd.Parameters.Clear();
            } 
            catch(SqlException ex){
                resultado = ex.Message;
            }
            catch(Exception ex){
                resultado = ex.Message;
            }
            finally{
                conn.Close();
            }

            return resultado;
        }

        public string Atualizar(Usuarios usuario){
            string resultado = "";
            try{
                conn = new SqlConnection(conexao);
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Usuario set nomeUsuario=@n, login=@l, senha=@s where idUsuario = @id";
                
                cmd.Parameters.AddWithValue("@n",usuario.nomeUsuario);
                cmd.Parameters.AddWithValue("@l",usuario.login);
                cmd.Parameters.AddWithValue("@s",usuario.senha);
                cmd.Parameters.AddWithValue("@id",usuario.idUsuario);

                int r = cmd.ExecuteNonQuery();

                if(r>0){
                    resultado="OK";
                }

                cmd.Parameters.Clear();
            } 
            catch(SqlException ex){
                resultado = ex.Message;
            }
            catch(Exception ex){
                resultado = ex.Message;
            }
            finally{
                conn.Close();
            }

            return resultado;
        }
    }
}