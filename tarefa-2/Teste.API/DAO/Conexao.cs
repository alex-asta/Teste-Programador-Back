using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace Teste.API.DAO
{
    public class Conexao : IDisposable
    {
        public const string DATABASE = "TESTE_API";

        private static readonly string cnnString = new(string.Concat("Server = localhost; Database=", Conexao.DATABASE, "; UserID = root; Password=root;"));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramSQL"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DataTable ExecutaSQL(string paramSQL)
        {
            
            try
            {

                bool AcaoSelect = paramSQL.ToUpper().Substring(0, 6).Equals("SELECT"); //Apura se será uma instrução select
                DataTable retornoSql = new(); // Armazena os dados de retorno do select
                MySqlDataAdapter dataAdapter = new();

                //Instancia uma nova conexão com o banco de dados
                MySqlConnection connection = new(cnnString);

                //Abre a conexão com o banco de dados
                var con = new MySqlConnection(cnnString);
                con.Open();

                //
                var cmd = new MySqlCommand
                {
                    Connection = con
                };

                //Apura a ação desejada
                if (AcaoSelect == true)
                {
                    dataAdapter = new(paramSQL, connection);
                    dataAdapter.Fill(retornoSql);
                }
                else
                {
                    cmd.CommandText = paramSQL;
                    cmd.ExecuteNonQuery();
                }

                //Finaliza a conexão com o banco de dados
                con.Close();

                //Retorno
                return retornoSql;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("[Conexao : ExecutaSQL] ", Environment.NewLine, Environment.NewLine, ex.Message.ToString()));
            }
  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
