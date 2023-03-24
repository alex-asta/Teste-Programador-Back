using System.Data;
using System.Text;
using Teste.API.DAO;

namespace Teste.API.DTOs
{
    public class ColetaRepository : IColeta
    {

        public List<ColetaDTO> PorEstado(string sigla = "")
        {
            try
            {
                List<ColetaDTO> listaDados = new();

                StringBuilder sql = new();
                sql.Append(string.Concat("SELECT CI.nome nomeCidade, CE.sigla, CE.nome nomeEstado, PE.nome nomeCliente, PE.documento, CO.id, CO.data_solicitacao, CO.data_coleta, CO.data_entrega"));

                sql.Append(string.Concat(" FROM ", Conexao.DATABASE, ".COLETA CO"));
                sql.Append(string.Concat(", ", Conexao.DATABASE, ".CLIENTE PE"));
                sql.Append(string.Concat(", ", Conexao.DATABASE, ".CIDADE CI"));
                sql.Append(string.Concat(", ", Conexao.DATABASE, ".ESTADO CE"));

                sql.Append(string.Concat(" WHERE PE.id = CO.id_cliente"));
                sql.Append(string.Concat(" AND CI.id = CO.id_cidade"));
                sql.Append(string.Concat(" AND CE.id = CI.id_estado"));
                if (sigla != "") { sql.Append(string.Concat(" AND CE.sigla = '", sigla.ToUpper(), "'")); }

                //        
                DataTable dt = new Conexao().ExecutaSQL(sql.ToString());

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ColetaDTO info = new();


                    info.Id = (int)dt.Rows[i]["id"];
                    info.DataSolicitacao = (DateTime)dt.Rows[i]["data_solicitacao"];
                    if (dt.Rows[i]["data_coleta"].ToString() != "") { info.DataColeta = (DateTime)dt.Rows[i]["data_coleta"]; }
                    if (dt.Rows[i]["data_entrega"].ToString() != "") { info.DataEntrega = (DateTime)dt.Rows[i]["data_entrega"]; }

                    info.Cliente.Nome = (string)dt.Rows[i]["nomeCliente"];
                    info.Cliente.Documento = (string)dt.Rows[i]["documento"];
                    info.Cidade.Nome = (string)dt.Rows[i]["nomeCidade"];
                    info.Cidade.Estado = (string)dt.Rows[i]["nomeEstado"];
                    info.Cidade.Sigla = (string)dt.Rows[i]["sigla"];
                    listaDados.Add(info);
                }

                return listaDados;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
