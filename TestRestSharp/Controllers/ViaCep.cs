using Microsoft.AspNetCore.Mvc;
using TestRest.Applications.UseCases.ViaCep;
using TestRest.Communications.Responses;
using TestRest.Exceptions.ExceptionsBase;

namespace TestRestSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ViaCep : ControllerBase
{
    private readonly GetCityByCep _getCityByCep;
    public ViaCep(GetCityByCep getCityByCep)
    {
        _getCityByCep = getCityByCep;
    }
    
    [HttpGet("hello")]
    public IActionResult Index()
    {
        return Ok("Hello");
    }

    [HttpGet]
    [Route("{cep}")]
    [ProducesResponseType(typeof(Cep), 200)]
    [ProducesResponseType( 404)]
    public async Task<IActionResult> Get([FromRoute] string cep)
    {
        try
        {
            var res = await _getCityByCep.Execute(cep);
            return Ok(res);
        }
        catch(ErrorInCep ex)
        {
            return BadRequest("error na chamada");
        }
        
    }
}