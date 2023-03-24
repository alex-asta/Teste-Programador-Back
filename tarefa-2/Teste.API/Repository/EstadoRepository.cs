using System.Data;
using System.Text;
using Teste.API.DAO;

namespace Teste.API.DTOs
{
    public class EstadoRepository : IEstado
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<EstadoDTO> BuscaEstado(int id = 0)
        {            

            try
            {

                List<EstadoDTO> listaDados = new();

                //
                StringBuilder sql = new();
                sql.Append(string.Concat("SELECT *"));
                sql.Append(string.Concat(" FROM ", Conexao.DATABASE, ".ESTADO"));
                if (id != 0) { sql.Append(string.Concat(" WHERE id = ", id)); }
                DataTable dt = new Conexao().ExecutaSQL(sql.ToString());

                //Alimenta o objeto com os dados do dataTable
                listaDados = (from rw in dt.AsEnumerable()
                                select new EstadoDTO()
                                {
                                    Id = (int)rw["id"],
                                    Nome = (string)rw["nome"],
                                    Sigla = (string)rw["Sigla"]
                                }).ToList();

                //
                return listaDados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            //
            
        }

        /// <summary>
        /// Rotina para adquirir o id do estado
        /// </summary>
        /// <param name="sigla">Siga do Estado</param>
        /// <returns></returns>
        public int GetIdEstado(string sigla)
        {
            try
            {
                int idEstado = 0;

                StringBuilder sql = new();
                sql.Append(string.Concat("SELECT id"));
                sql.Append(string.Concat(" FROM ", Conexao.DATABASE, ".ESTADO"));
                sql.Append(string.Concat(" WHERE sigla = '", sigla, "'"));
                DataTable dt = new Conexao().ExecutaSQL(sql.ToString());
                if (dt.Rows.Count > 0)
                {
                    idEstado = (int)dt.Rows[0]["id"];
                }

                //
                return idEstado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
