namespace Teste.API.DTOs
{
    public class RetornoDTO
    {
        public string Status { get; set; } //Status [S]Sucesso ou [E]Erro
        public DateTime DataHora { get; set; } //Data e hora da geração do retorno
        public string Descricao { get; set; } //Texto do retorno, quando houver erros

    }
}
