using System.Net;

namespace Libre.Connect.Domain.Exception;

public class ExceptionBadRequest : BaseException
{
    public ExceptionBadRequest(string message) : base(HttpStatusCode.BadRequest, message){}
    public ExceptionBadRequest(string message, System.Exception innerException) : base(HttpStatusCode.BadRequest, message, innerException) { }
}