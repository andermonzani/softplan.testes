using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using  CalculoJuros.Api.Domain.Services;

namespace CalculoJuros.Api.Domain.Services
{
    public class TaxaJurosService: ITaxaJurosService
    {
        public async Task<double> PegarTaxaJuros()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:5001/api/taxajuros");

                response.EnsureSuccessStatusCode();

                string valor = await response.Content.ReadAsStringAsync();

                return double.Parse(valor.Replace('.', ','));
            }
        }
    }
}