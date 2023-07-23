using CurrencyExchange.Models;
using System.Xml.Serialization;


namespace CurrencyExchange.Services;

public class CurrencyService
{
    public async Task<CurrencyModel.CurrencyRate> GetRateInfoAsync()
    {
        DateTime dateTime = DateTime.Now;

        string shortDate = dateTime.ToString("dd.MM.yyyy");

        HttpClient client = new();
        HttpResponseMessage message = await client.GetAsync($"https://www.cbar.az/currencies/{shortDate}.xml");
        if (message.IsSuccessStatusCode)
        {
            string result = await message.Content.ReadAsStringAsync();
            if (result != null)
            {
                XmlSerializer xml_serializer = new(typeof(CurrencyModel.CurrencyRate));
                using (TextReader reader = new StringReader(result))
                {
                    CurrencyModel.CurrencyRate info = (CurrencyModel.CurrencyRate)xml_serializer.Deserialize(reader);
                    return info;
                }
            }
            throw new NullReferenceException();
        }
        throw new HttpRequestException();
    }
}