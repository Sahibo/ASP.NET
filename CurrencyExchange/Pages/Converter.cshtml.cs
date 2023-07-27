using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CurrencyExchange.Models;
using CurrencyExchange.Services;
using System.Globalization;


namespace CurrencyExchange.Pages;

public class Converter : PageModel
{
    private readonly ConverterService _converterService;

    public List<ValuteModel> Valutes { get; set; }
    public ValCursModel? Model { get; set; }
    public string? Result { get; set; }
    public decimal Value { get; set; }
    public string? Code { get; set; }

    public Converter()
    {
        _converterService = new ConverterService();
    }

    public async Task<IActionResult> OnGet()
    {
        await LoadData();
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        await LoadData();

        Value = decimal.Parse(Request.Form["Value"]!);
        Code = Request.Form["Code"];

        if (Model != null)
        {
            try
            {
                Result = _converterService.ConvertCurrency(Value, Code, Model).ToString();
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }

        return Page();
    }

    private async Task LoadData()
    {
        var currencyService = new CurrencyService();
        Model = await currencyService.GetConverterInfoAsync();
    }
}