using System.ComponentModel;
using Csharp_Task_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Csharp_Task_3.Controllers;

[ApiController]
[Route("pin")]
public class PinController
{
    private readonly IPinService _pinService;

    private const int _maxDigits = 8;

    public PinController(IPinService pinService)
    {
        _pinService = pinService;
    }

    [HttpGet(Name = "GetPinSolution")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<string>))]
    public IActionResult Get(string observed)
    {
        if(string.IsNullOrEmpty(observed)) return new BadRequestResult();

        if (!int.TryParse(observed, out var result)) return new BadRequestResult();
        
        if (result is < 0 || observed.Length > _maxDigits) return new BadRequestResult();

        var pins = observed.ToCharArray();
        return new OkObjectResult(_pinService.GetPINs(Array.ConvertAll(pins, c => (int)Char.GetNumericValue(c)).ToList())); 
    }
}