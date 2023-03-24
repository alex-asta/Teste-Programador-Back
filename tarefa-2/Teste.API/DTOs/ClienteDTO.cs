namespace Teste.API.DTOs
{


    /// <summary>
    /// Campos que irão retornar ou receber as informações da pessoa
    /// </summary>
    public class ClienteDTO
    {
        /// <summary>
        /// ID da Pessoa
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nome da Pessoa
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Documento (CPF/CNPJ)
        /// </summary>
        public string Documento { get; set; }

        /// <summary>
        /// Nome da Cidade
        /// </summary>
        long IdCidade { get; set; }
        public virtual string NomeCidade { get; set; }

    }

    public class ClienteColetaDTO
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
    }
}

