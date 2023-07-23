using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CurrencyExchange.Models;
using CurrencyExchange.Services;
using System.Globalization;

namespace CurrencyExchange.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    [BindProperty(Name = "result")]
    public string Result { get; set; }
    [BindProperty(Name = "userInput")]
    public string UserInput { get; set; }
    [BindProperty(Name = ("currencySelectionLeft"))]
    public string CurrencySelectionLeft { get; set; }
    [BindProperty(Name = ("currencySelectionRight"))]
    public string CurrencySelectionRight { get; set; }

    public CurrencyModel.CurrencyRate Response { get; set; } = new();
    private CurrencyService _currencyService;

    public IndexModel(CurrencyService converterService)
    {
        _currencyService = converterService;
    }

    public async Task<IActionResult> OnGet()
    {
        try
        {
            Response = await _currencyService.GetRateInfoAsync();

        }
        catch (Exception e)
        { 
            return RedirectToPage("/Error");
        }

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        Response = await _currencyService.GetRateInfoAsync();
        if (UserInput != null)
        {
            try
            {
                double userInputValue = Convert.ToDouble(UserInput);
                double resultValue = ConvertCurrency(userInputValue, CurrencySelectionLeft, CurrencySelectionRight);
                Result = resultValue.ToString();
                TempData["ConversionResult"] = Result;
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }
        }
        return Page();
    }
    
    private double ConvertCurrency(double value, string fromCurrency, string toCurrency)
    {
        string toCurrencyValue = String.Empty;
        if (fromCurrency != toCurrency)
        {
            for (int i = 0; i < Response.ValTypes.Count; i++)
            {
                for (int j = 0; j < Response.ValTypes[i].Valutes.Count; j++)
                {
                    if (Response.ValTypes[i].Valutes[j].Code == toCurrency)
                    {
                        toCurrencyValue = Response.ValTypes[i].Valutes[j].Value;
                        break;
                    }
                }
            }
            double result;
            Double.TryParse(toCurrencyValue, NumberStyles.Float, CultureInfo.InvariantCulture, out result);

            return result * value;
        }
        return value;

    }
}