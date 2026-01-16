using System.Net;

namespace Libre.Connect.Domain.Exception;

public class DomainException : BaseException
{
    public DomainException(string message) : base(HttpStatusCode.NotFound, message){}
    public DomainException(string message, System.Exception innerException) : base(HttpStatusCode.BadRequest, message, innerException) { }
}