using System.Globalization;
using CurrencyExchange.Models;

namespace CurrencyExchange.Services;

public class ConverterService
{
    public decimal ConvertCurrency(decimal value, string code, ValCursModel valCursModel)
    {
        ValuteModel valute = valCursModel.ValTypes
            .SelectMany(valType => valType.Valutes)
            .FirstOrDefault(val => val.Code == code);

        if (valute != null)
        {
            decimal rate = decimal.Parse(valute.Value, CultureInfo.InvariantCulture);
            decimal result = Math.Round(value / rate, 2, MidpointRounding.AwayFromZero);
            return result;
        }

        throw new ArgumentException("Invalid currency code.");
    }
}