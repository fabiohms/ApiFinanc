using System;
using System.Collections.Generic;
using System.Configuration;
using ApiFinanc.Models;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ApiFinanc.Models
{
    public class DalHelper
    {
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["connexaoSQLServer"].ConnectionString;
        }

        #region Perguntas
        public static List<Pergunta> GetPerguntas()
        {
            List<Pergunta> _perguntas = new List<Pergunta>();
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tb_perguntas", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var pergunta = new Pergunta(Convert.ToInt32(dr["idt_pergunta"]), dr["des_pergunta"].ToString() );
                                _perguntas.Add(pergunta);
                            }
                        }
                    }
                }
            }

            return _perguntas;
        }
        #endregion

        #region Respostas
        public static List<Resposta> GetRespostas(int id)
        {
            List<Resposta> _repostas = new List<Resposta>();
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tb_Respostas WHERE idt_resposta = " + id, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var resposta = new Resposta(Convert.ToInt32(dr["idt_pergunta"]), Convert.ToInt32(dr["idt_resposta"]), dr["des_resposta"].ToString(), Convert.ToInt32(dr["peso"]));
                                _repostas.Add(resposta);
                            }
                        }
                    }
                }
            }
            return _repostas;
        }
        #endregion

        #region Formulario
        public static int GetSeqForm()
        {
            int seq_form = 0;

            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT MAX(idt_formulario) FROM tb_Formulario", con))
                {
                    if (cmd.ExecuteScalar() != DBNull.Value)
                        seq_form = Convert.ToInt32(cmd.ExecuteScalar());
                    else
                        seq_form = 0;
                }
                return seq_form + 1;
            }
        }
    
        public static List<Formulario> GetFormularios(int id)
        {
            List<Formulario> _formularios = new List<Formulario>();
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tb_Formulario WHERE idt_formulario = " + id, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var formulario = new Formulario(Convert.ToInt32(dr["idt_formulario"]), Convert.ToInt32(dr["idt_pergunta"]), Convert.ToInt32(dr["idt_resposta"]));
                                _formularios.Add(formulario);
                            }
                        }
                    }
                }
            }
            return _formularios;
        }

        public static int GetResultado(int id)
        {
            int resultado = 0;

            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select Sum (resp.peso) from	tb_formulario form inner join tb_Respostas resp on form.idt_resposta = resp.idt_resposta and form.idt_pergunta = resp.idt_pergunta where form.idt_formulario = " + id, con))
                {
                    if (cmd.ExecuteScalar() != DBNull.Value)
                        resultado = Convert.ToInt32(cmd.ExecuteScalar());
                    else
                        resultado = 0;
                }
            }
            return resultado;
        }

        public static int InsertFormulario(Formulario formulario)
        {
            int nrows = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string exec = "Insert into tb_Formulario (idt_formulario, idt_pergunta, idt_resposta) values (@id_formulario, @id_pergunta, @id_resposta)";
                using (SqlCommand cmd = new SqlCommand(exec, con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_formulario", formulario.id_formulario);
                    cmd.Parameters.AddWithValue("@id_pergunta", formulario.id_pergunta);
                    cmd.Parameters.AddWithValue("@id_resposta", formulario.id_resposta);

                    con.Open();
                    nrows = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return nrows;
        }
        #endregion

        #region Perfil

        public static string calculaPerfil(int resultado)
        {
            string perfil = "";
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT perfil FROM tb_Perfil WHERE minimo <= " + resultado + " AND maximo > " + resultado, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                perfil = dr["perfil"].ToString();
                            }
                        }
                    }
                }
            }
            return perfil;
        }
        #endregion
    }
}