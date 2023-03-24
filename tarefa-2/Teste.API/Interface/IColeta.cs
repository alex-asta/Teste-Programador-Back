namespace Teste.API.DTOs
{
    public interface IColeta
    {

        List<ColetaDTO> PorEstado(string sigla = "");

    }
}
