using System.Net;

namespace backend.Exceptions;

public class FlightGeneratorException : Exception
{
    private const HttpStatusCode status = HttpStatusCode.BadRequest;
    public FlightGeneratorException(string message) : base(message) { }
}