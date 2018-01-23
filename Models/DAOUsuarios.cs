using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models
{
    public class DAOUsuarios:Conexao
    {
        
        public List<Usuarios> Listar(){

            List<Usuarios> usuario = new List<Usuarios>();
            
            try{
                conn = new SqlConnection(Caminho());
                conn.Open();
                cmd = new SqlCommand("Select * from Usuario",conn);
                cmd.Connection = conn;

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
                conn = new SqlConnection(Caminho());
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

        public bool Excluir(int id){
            bool resultado = false;
            try{
                conn = new SqlConnection(Caminho());
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Usuario where idUsuario = @id";
                
                cmd.Parameters.AddWithValue("@id",id);

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

        public string Atualizar(Usuarios usuario){
            string resultado = "";
            try{
                conn = new SqlConnection(Caminho());
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Usuario set nomeUsuario=@n, login=@l, senha=@s, dataCadastro=@d where idUsuario = @id";
                
                cmd.Parameters.AddWithValue("@n",usuario.nomeUsuario);
                cmd.Parameters.AddWithValue("@l",usuario.login);
                cmd.Parameters.AddWithValue("@s",usuario.senha);
                cmd.Parameters.AddWithValue("@id",usuario.idUsuario);
                cmd.Parameters.AddWithValue("@d",DateTime.Now);

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