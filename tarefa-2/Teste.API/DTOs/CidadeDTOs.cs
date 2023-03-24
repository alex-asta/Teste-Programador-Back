using System.ComponentModel.DataAnnotations;

namespace Teste.API.DTOs
{

    /// <summary>
    /// Campos que irão retornar ou receber as informações da cidade
    /// </summary>
    public class CidadeDTO
    { 
        /// <summary>
        /// ID da Cidade
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da Cidade
        /// </summary>
        public string Nome { get; set; }
            
        /// <summary>
        /// Id do Estado
        /// </summary>
        public int Id_Estado { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public virtual string Estado { get; set; }

        /// <summary>
        /// Sigla do Estado
        /// </summary>
        public virtual string Sigla { get; set; }
    }

    public class InputCidadeDTO
    {
        /// <summary>
        /// ID da Cidade
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da Cidade
        /// </summary>
        [Required]
        [Range(1, 100)]
        public string Nome { get; set; }

        /// <summary>
        /// Sigla do Estado
        /// </summary>
        [Required]
        [Range(2, 2)]
        public string SiglaEstado { get; set; }
    }

    public class CidadeColetaDTO
    {
        public string Nome { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public virtual string Estado { get; set; }

        /// <summary>
        /// Sigla do Estado
        /// </summary>
        public virtual string Sigla { get; set; }
    }

}
