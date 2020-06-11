using System;

namespace CalculoJuros.Api.Domain.Services
{
    public class CalculaJurosService : ICalculaJurosService
    {
        public decimal CalcularJuros(decimal valorInicial, int meses, double taxaJuros)
        {
            return Math.Round(valorInicial * Convert.ToDecimal(Math.Pow(1 + taxaJuros, meses)), 2);
        }
    }
}