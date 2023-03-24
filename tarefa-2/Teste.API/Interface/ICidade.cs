namespace Teste.API.DTOs
{
    public interface ICidade
    {

        bool AddCidade(InputCidadeDTO cidade);
        bool UpdateCidade(InputCidadeDTO cidade);
        bool DeleteCidade(long id);
        List<CidadeDTO> BuscaCidade(long id = 0);
        List<CidadeDTO> ExisteCidade(string nome);
    }
}
