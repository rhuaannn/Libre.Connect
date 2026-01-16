using System.Net;

namespace Libre.Connect.Domain.Exception;

public class ExceptionNotFound : BaseException
{
    public ExceptionNotFound(string message) : base(HttpStatusCode.NotFound, message) { }
    public ExceptionNotFound(string message, System.Exception innerException) : base(HttpStatusCode.NotFound, message, innerException) { }
}