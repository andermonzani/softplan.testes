using System.Threading.Tasks;

namespace CalculoJuros.Api.Domain.Services
{
    public interface ITaxaJurosService
    {
        Task<double> PegarTaxaJuros();
    }
}