using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projetoCRUD.Models;
using MySql.Data.MySqlClient;

namespace projetoCRUD.DAO
{
    internal class DespesaDAO
    {

        public void Insert(Despesa despesa)
        {
            try
            {

                string sql = "INSERT INTO Despesa(valor_des, data_pag_des, data_venc_des, status_des, id_cai_fk) " +
                    "VALUES(@valorDespesa,@dataPag,@dataVenc,@status,@idCaixaFK)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                comando.Parameters.AddWithValue("@valorDespesa", despesa.valorDespesa);
                comando.Parameters.AddWithValue("@dataPag", despesa.dataPag);
                comando.Parameters.AddWithValue("@dataVenc", despesa.dataVenc);
                comando.Parameters.AddWithValue("@status", despesa.status);
                comando.Parameters.AddWithValue("@idCaixaFK", despesa.idCaixaFK);
                comando.ExecuteNonQuery();

                Console.WriteLine("Despesa cadastrada com sucesso.");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception($"\n Erro ao inserir Despesa {ex.Message}");
            }
        }

        public void Delete(Despesa despesa)
        {
            try
            {
                string sql = "DELETE FROM despesa WHERE id_des = @idDespesa";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                comando.Parameters.AddWithValue("@idDespesa", despesa.idDespesa);
                comando.ExecuteNonQuery();

                Console.WriteLine("\n Despesa excluída.");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception($"\n Erro ao deletar Despesa {ex.Message}");
            }
        }

        public void Update(Despesa despesa)
        {
            try
            {
                string sql = "UPDATE Despesa SET valor_des = @valorDespesa, data_pag_des = @dataPag, data_venc_des = @dataVenc, status_des = @status, id_cai_fk = @idCaixaFK " +
                    "WHERE id_des = @idDespesa";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                comando.Parameters.AddWithValue("@valorDespesa", despesa.valorDespesa);
                comando.Parameters.AddWithValue("@dataPag", despesa.dataPag);
                comando.Parameters.AddWithValue("@dataVenc", despesa.dataVenc);
                comando.Parameters.AddWithValue("@status", despesa.status);
                comando.Parameters.AddWithValue("@idCaixaFK", despesa.idCaixaFK);
                comando.Parameters.AddWithValue("@idDespesa", despesa.idDespesa);

                comando.ExecuteNonQuery();
                Console.WriteLine("\n Despesa atualizada com sucesso.");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception($"\n Erro ao atualizar Despesa {ex.Message}");
            }
        }

        public List<Despesa> List()
        {
            List<Despesa> despesas = new List<Despesa>();

            try
            {
                var sql = "SELECT * FROM despesa ORDER BY status_des";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Despesa des = new Despesa();
                        des.idDespesa = dr.GetInt32("id_des");
                        des.valorDespesa = dr.GetInt32("valor_des");
                        des.dataPag = dr.GetDateTime(dr.GetOrdinal("data_pag_des"));
                        des.dataVenc = dr.GetDateTime(dr.GetOrdinal("data_venc_des"));
                        des.status = dr.GetString("status_des");
                        des.idCaixaFK = dr.GetInt32("id_cai_fk");
                        despesas.Add(des);
                    }
                }
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception($"\n Erro ao listar Despesa {ex.Message}");
            }
            return despesas;
        }


        public List<Caixa> ListaCaixa()
        {
            List<Caixa> caixa = new List<Caixa>();

            try
            {
                var sql = "SELECT id_cai, f.nome_func FROM Caixa INNER JOIN Funcionario as f ON id_func_fk = id_func ORDER BY id_cai";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Caixa cai = new Caixa();
                        cai.IdCai = dr.GetInt32("id_cai");
                        cai.NomeFun = dr.GetString("nome_func");
                        caixa.Add(cai);
                    }
                }
                Conexao.FecharConexao();s
            }
            catch (Exception ex)
            {
                throw new Exception($"\n Erro ao listar Funcionário {ex.Message}");
            }
            return caixa;
        }
    }
}
