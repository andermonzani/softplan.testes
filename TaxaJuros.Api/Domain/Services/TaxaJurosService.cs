using System.Threading.Tasks;

namespace TaxaJuros.Api.Domain.Services
{
    public class TaxaJurosService: ITaxaJurosService
    {
        private const double Taxa = 0.01;
        
        public double PegarTaxaJuros()
        {
            return Taxa;
        }
    }
}