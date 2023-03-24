using System.Data;
using System.Text;
using Teste.API.DAO;

namespace Teste.API.DTOs
{
    public class CidadeRepository : ICidade
    {

        RetornoDTO output = new RetornoDTO();

        /// <summary>
        /// Método para adicionar uma nova cidade
        /// </summary>
        /// <param name="cidade">Dados da Cidade</param>
        /// <returns></returns>
        /// <exception cref="Exception">Excess</exception>
        public bool AddCidade(InputCidadeDTO cidade)
        {
            try
            {

                int idEstado = 0;

                //Verifica se informou o id da Cidade
                if (cidade.Nome == "") { throw new Exception("Favor informar o nome da cidade!"); }
                if (cidade.SiglaEstado == "") { throw new Exception("Favor informar a UF da cidade!"); }
                else
                {
                    idEstado = new EstadoRepository().GetIdEstado(cidade.SiglaEstado.ToUpper());
                    if (idEstado == 0) { throw new Exception("Favor informar um estado válido!"); }
                }

                //Realiza a ação
                StringBuilder sql = new();
                sql.Append(string.Concat("INSERT INTO ", Conexao.DATABASE, ".CIDADE (nome, id_estado)"));
                sql.Append(string.Concat(" VALUES ('", cidade.Nome.ToUpper(), "'"));
                sql.Append(string.Concat(",", idEstado));
                sql.Append(string.Concat(" )"));
                new Conexao().ExecutaSQL(sql.ToString());

                //
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool UpdateCidade(InputCidadeDTO cidade)
        {
            try
            {

                long idEstado = 0;

                //Verifica se informou o id da Cidade
                if (cidade.Id == 0) { throw new Exception("Favor informar o id da cidade!"); }
                if (cidade.Nome == "") { throw new Exception("Favor informar o nome da cidade!"); }
                if (cidade.SiglaEstado == "") { throw new Exception("Favor informar a UF da cidade!"); }
                else
                {
                    idEstado = new EstadoRepository().GetIdEstado(cidade.SiglaEstado.ToUpper());
                }

                //Realiza a alteração no banco de dados
                StringBuilder sql = new();
                sql.Append(string.Concat("UPDATE ", Conexao.DATABASE, ".CIDADE"));
                sql.Append(string.Concat(" SET nome = '", cidade.Nome.ToUpper(), "'"));
                sql.Append(string.Concat(", id_estado = ", idEstado));
                sql.Append(string.Concat(" WHERE id = ", cidade.Id));
                new Conexao().ExecutaSQL(sql.ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteCidade(long id)
        {
            try
            {

                StringBuilder sql = new();
                sql.Append(string.Concat("DELETE FROM ", Conexao.DATABASE, ".CIDADE"));
                sql.Append(string.Concat(" WHERE id = ", id));
                new Conexao().ExecutaSQL(sql.ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CidadeDTO> BuscaCidade(long id = 0)
        {

            List<CidadeDTO> listaDados = new();

            try
            {

                //
                StringBuilder sql = new();
                sql.Append(string.Concat("SELECT C.id, C.nome, C.id_estado, E.nome Estado, E.Sigla"));
                sql.Append(string.Concat(" FROM ", Conexao.DATABASE, ".CIDADE C"));
                sql.Append(string.Concat(", ", Conexao.DATABASE, ".ESTADO E"));
                sql.Append(string.Concat(" WHERE E.id = C.id_estado"));
                if (id != 0) { sql.Append(string.Concat(" AND C.id = ", id)); }
                sql.Append(string.Concat(" ORDER BY C.nome"));
                DataTable dt = new Conexao().ExecutaSQL(sql.ToString());

                //Alimenta o objeto com os dados do dataTable
                listaDados = (from rw in dt.AsEnumerable()
                              select new CidadeDTO()
                              {
                                  Id = (int)rw["id"],
                                  Nome = (string)rw["nome"],
                                  Id_Estado = (int)rw["id_estado"],
                                  Estado = (string)rw["Estado"],
                                  Sigla = (string)rw["Sigla"]
                              }).ToList();


                return listaDados;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<CidadeDTO> ExisteCidade(string nome)
        {
            List<CidadeDTO> listaDados = new();

            try
            {

                //
                StringBuilder sql = new();
                sql.Append(string.Concat("SELECT C.id, C.nome, C.id_estado, E.nome Estado, E.Sigla"));
                sql.Append(string.Concat(" FROM ", Conexao.DATABASE, ".CIDADE C"));
                sql.Append(string.Concat(", ", Conexao.DATABASE, ".ESTADO E"));
                sql.Append(string.Concat(" WHERE E.id = C.id_estado"));
                sql.Append(string.Concat(" AND C.nome Like '%", nome.ToUpper(), "%'"));
                sql.Append(string.Concat(" ORDER BY C.nome"));
                DataTable dt = new Conexao().ExecutaSQL(sql.ToString());

                //Alimenta o objeto com os dados do dataTable
                listaDados = (from rw in dt.AsEnumerable()
                              select new CidadeDTO()
                              {
                                  Id = (int)rw["id"],
                                  Nome = (string)rw["nome"],
                                  Id_Estado = (int)rw["id_estado"],
                                  Estado = (string)rw["Estado"],
                                  Sigla = (string)rw["Sigla"]
                              }).ToList();


                return listaDados;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

