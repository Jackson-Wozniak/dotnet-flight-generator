using backend.Dto;
using backend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/Flights")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly FlightFactory _flightFactory;

    public FlightController(FlightFactory flightFactory)
    {
        _flightFactory = flightFactory;
    }
    
    [HttpGet]
    public ActionResult<FlightDto> CreateFlight()
    {
        var flight = _flightFactory.Generate();

        return Ok(new FlightDto(flight));
    }
}