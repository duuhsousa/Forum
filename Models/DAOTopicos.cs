using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models
{
    public class DAOTopicos:Conexao
    {

        public List<Topicos> Listar(){
            List<Topicos> topico = new List<Topicos>();
            
            try{
                conn = new SqlConnection();
                conn.ConnectionString = Caminho();
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
                conn = new SqlConnection(Caminho());
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO TopicoForum (titulo,descricao) values('@t','@d')";
                
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

        public string Excluir(int id){
            string resultado = "";
            try{
                conn = new SqlConnection(Caminho());
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from TopicoForum where idTopico = @id";
                
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

        public string Atualizar(Topicos topico){
            string resultado = "";
            try{
                conn = new SqlConnection(Caminho());
                conn.Open();
                cmd=new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update TopicoForum set titulo=@t, descricao=@d where idTopico = @id";
                
                cmd.Parameters.AddWithValue("@t",topico.titulo);
                cmd.Parameters.AddWithValue("@d",topico.descricao);
                cmd.Parameters.AddWithValue("@id",topico.idTopico);

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