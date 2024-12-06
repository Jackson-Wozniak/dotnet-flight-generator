using backend.Dto;
using backend.Models;
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
    public ActionResult<FlightDto> CreateFlight([FromQuery(Name = "max_distance")] double maxDistance = -1.0)
    {
        Flight flight;
        if (maxDistance.Equals(-1.0))
        {
            flight = _flightFactory.Generate();

            return Ok(new FlightDto(flight));
        }
        
        flight = _flightFactory.Generate(maxDistance);

        return Ok(new FlightDto(flight));
    }
}