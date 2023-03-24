namespace Teste.API.DTOs
{


    /// <summary>
    /// Campos que irão retornar ou receber as informações das coletas
    /// </summary>
    public class ColetaDTO
    {
        public ColetaDTO()
        {
            Cliente = new ClienteColetaDTO();
            Cidade = new CidadeColetaDTO();
        }

        /// <summary>
        /// ID da Coleta
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Data da Solicitação
        /// </summary>
        public DateTime DataSolicitacao { get; set; }

        /// <summary>
        /// Data da Coleta
        /// </summary>
        public DateTime? DataColeta { get; set; }

        /// <summary>
        /// Data da Entrega
        /// </summary>
        public DateTime? DataEntrega { get; set; }
        public virtual ClienteColetaDTO Cliente { get; set; }
        public virtual CidadeColetaDTO Cidade { get; set; }


    }
}

