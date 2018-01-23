using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models
{
    public class DAOPostagem:Conexao
    {

        public List<Postagens> Listar(){
            List<Postagens> postagem = new List<Postagens>();
            
            try{
                conn = new SqlConnection();
                conn.ConnectionString = Caminho();
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Postagem";

                dr = cmd.ExecuteReader();

                while(dr.Read()){
                    postagem.Add(new Postagens(){
                        idPostagem = dr.GetInt32(0),
                        idTopico = dr.GetInt32(1),
                        idUsuario = dr.GetInt32(2),
                        mensagem = dr.GetString(3),
                        dataPublicacao = dr.GetDateTime(4)
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

            return postagem;
        } 

        public bool Cadastrar(Postagens postagem){
            bool resultado = false;
            try{
                conn = new SqlConnection(Caminho());
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Postagem (idTopico,idUsuario,mensagem) values(@idT,@idU,'@m')";
                
                cmd.Parameters.AddWithValue("@idT",postagem.idTopico);
                cmd.Parameters.AddWithValue("@idU",postagem.idUsuario);
                cmd.Parameters.AddWithValue("@m",postagem.mensagem);

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
                conn = new SqlConnection(Caminho());
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Postagem where idPostagem = @id";
                
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

        public string Atualizar(Postagens postagem){
            string resultado = "";
            try{
                conn = new SqlConnection(Caminho());
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Postagem set idTopico=@idT, idUsuario=@idU, mensagem=@m where idPostagem = @idP";
            
                cmd.Parameters.AddWithValue("@idP",postagem.idPostagem);
                cmd.Parameters.AddWithValue("@idT",postagem.idTopico);
                cmd.Parameters.AddWithValue("@idU",postagem.idUsuario);
                cmd.Parameters.AddWithValue("@m",postagem.mensagem);

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