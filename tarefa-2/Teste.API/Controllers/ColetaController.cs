using Microsoft.AspNetCore.Mvc;
using Teste.API.DTOs;

namespace Teste.API.Controllers
{

    [Route("api/Coleta/")]
    [ApiController]
    public class ColetaController : ControllerBase
    {

        private readonly IColeta repository;
        RetornoDTO output = new();

        ///
        public ColetaController(IColeta repo)
        {
            repository = repo;
        }

        // <summary>
        // Método para verificar as coletas por estado.
        // </summary>
        // <param name="Sigla"></param>
        // <remarks>Adquire as coletas por estado</remarks>
        // <returns></returns>
        // <response code ="200">Sucesso no retorno</response>
        // <response code ="400">Campos Obrigatórios</response>
        // <response code ="500">Erro Interno</response>
        [HttpGet]
        [Produces(typeof(List<ColetaDTO>))]
        [Route("PorEstado/")]
        public IActionResult ColetaPorEstado(string sigla="")
        {
            try
            {
                //
                List<ColetaDTO> dados = repository.PorEstado(sigla );

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


        // <summary>
        // Método para verificar as coletas por estado.
        // </summary>
        // <param name="Sigla"></param>
        // <remarks>Adquire as coletas por estado</remarks>
        // <returns></returns>
        // <response code ="200">Sucesso no retorno</response>
        // <response code ="400">Campos Obrigatórios</response>
        // <response code ="500">Erro Interno</response>
        [HttpGet]
        [Produces(typeof(List<ColetaDTO>))]
        [Route("ColetaPorEstadoPaginado/")]
        public IActionResult ColetaPorEstadoPaginado( int pagina, int qtdRegistros, string sigla = "")
        {
            try
            {
                //
                List<ColetaDTO> dados = repository.PorEstado(sigla);

                var paginacao = dados.ToArray().OrderBy(m => m.Id).Skip(qtdRegistros * (pagina - 1)).Take(qtdRegistros);

                //
                return Ok(paginacao);

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
