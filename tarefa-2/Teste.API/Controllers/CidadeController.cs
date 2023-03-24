using Microsoft.AspNetCore.Mvc;
using Teste.API.DTOs;

namespace Teste.API.Controllers
{

    [Route("api/Cidade/")]
    [ApiController]
    public class CidadeController : ControllerBase
    {

        private readonly ICidade repository;
        RetornoDTO output = new();

        ///
        public CidadeController(ICidade repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Método para adquirir as cidades.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Busca as cidades cadastradas</remarks>
        /// <returns>Retorna as cidades cadastradas</returns>
        /// <response code ="200">Sucesso no retorno</response>
        /// <response code ="400">Campos Obrigatórios</response>
        /// <response code ="500">Erro Interno</response>
        [HttpGet]
        [Produces(typeof(List<CidadeDTO>))]
        public IActionResult Get(long id)
        {
            try
            {
                //
                List<CidadeDTO> dados = repository.BuscaCidade(id);

                //
                return Ok(dados);

            }
            catch (Exception ex)
            {
                output.Status = "E"; //[E]Erro
                output.Descricao = ex.Message.ToString();
                output.DataHora = DateTime.Now;

                return Ok(output);
            }
        }

        /// <summary>
        /// Método para inserir uma nova cidade.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Inclusão de novas cidades</remarks>
        /// <returns></returns>
        /// <response code ="200">Sucesso no retorno</response>
        /// <response code ="400">Campos Obrigatórios</response>
        /// <response code ="500">Erro Interno</response>
        [HttpPost]
        public IActionResult Post(InputCidadeDTO cidade)
        {
            try
            {
                //
                repository.AddCidade(cidade);

                //
                output.Status = "S"; //S]Erro
                output.Descricao = "";
                output.DataHora = DateTime.Now;

            }
            catch (Exception ex)
            {
                output.Status = "E"; //[E]Erro
                output.Descricao = ex.Message.ToString();
                output.DataHora = DateTime.Now;

                //return InternalServerError(ex);
            }


            return Ok(output);
        }

        /// <summary>
        /// Método para alterar uma nova cidade.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Altera os dados da cidade</remarks>
        /// <returns></returns>
        /// <response code ="200">Sucesso no retorno</response>
        /// <response code ="400">Campos Obrigatórios</response>
        /// <response code ="500">Erro Interno</response>
        [HttpPut]
        public IActionResult Put(InputCidadeDTO cidade)
        {
            try
            {
                //
                repository.UpdateCidade(cidade);

                //
                output.Status = "S"; //S]Erro
                output.Descricao = "";
                output.DataHora = DateTime.Now;

            }
            catch (Exception ex)
            {
                output.Status = "E"; //[E]Erro
                output.Descricao = ex.Message.ToString();
                output.DataHora = DateTime.Now;

                //return InternalServerError(ex);
            }

            return Ok(output);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //
                repository.DeleteCidade(id);

                //
                output.Status = "S"; //S]Erro
                output.Descricao = "";
                output.DataHora = DateTime.Now;

            }
            catch (Exception ex)
            {
                output.Status = "E"; //[E]Erro
                output.Descricao = ex.Message.ToString();
                output.DataHora = DateTime.Now;

                //return InternalServerError(ex);
            }

            return Ok(output);
        }

        // <summary>
        // Método para verificar se cidade já existe pelo nome
        // </summary>
        // <param name="id"></param>
        // <remarks>Altera os dados da cidade</remarks>
        // <returns></returns>
        // <response code ="200">Sucesso no retorno</response>
        // <response code ="400">Campos Obrigatórios</response>
        // <response code ="500">Erro Interno</response>
        [HttpGet]
        [Produces(typeof(List<CidadeDTO>))]
        [Route("ExisteCidade")]
        public IActionResult ExisteCidade(string nome)
        {
            try
            {
                //
                List<CidadeDTO> dados = repository.ExisteCidade(nome);

                //
                return Ok(dados);

            }
            catch (Exception ex)
            {
                output.Status = "E"; //[E]Erro
                output.Descricao = ex.Message.ToString();
                output.DataHora = DateTime.Now;

                return Ok(output);
            }
        }

    }
}
