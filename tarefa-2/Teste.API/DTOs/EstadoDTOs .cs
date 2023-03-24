namespace Teste.API.DTOs
{

    /// <summary>
    /// Campos que irão retornar ou receber as informações do estado
    /// </summary>
    public class EstadoDTO
    {

        /// <summary>
        /// ID da Cidade
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nome da Cidade
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public string Sigla { get; set; }
    }

}
