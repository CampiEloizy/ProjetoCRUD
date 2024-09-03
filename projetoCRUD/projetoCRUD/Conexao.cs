using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projetoCRUD
{
    internal class Conexao
    {
        static MySqlConnection conexao; //objeto responsável por controlar a conexão com a base
        public static MySqlConnection Conectar()
        {

            try
            {
                string strconexao = "server=localhost;port=3306;uid=root;pwd=root;database=bdProjetoCRUD";
                conexao = new MySqlConnection(strconexao);
                conexao.Open();
            }
            catch (Exception ex)
            {
                throw new Exception($"\n Erro ao conectar com o Banco de Dados {ex.Message}");
            } 
            
            return conexao;
        }

        public static void FecharConexao()
        {
            conexao.Close();
        }
    }
}
