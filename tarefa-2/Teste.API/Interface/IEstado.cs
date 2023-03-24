namespace Teste.API.DTOs
{
    public interface IEstado
    {

        List<EstadoDTO> BuscaEstado(int id = 0);
        int GetIdEstado(string sigla);
    }
}
