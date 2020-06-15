namespace CalculoJuros.Api.Domain.Services
{
    public interface ICalculaJurosService
    {
        decimal CalcularJuros(decimal valorInicial, int meses, double taxaJuros);
    }
}