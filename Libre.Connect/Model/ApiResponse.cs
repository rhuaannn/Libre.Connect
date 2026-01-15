namespace Libre.Connect.Model;

public class ApiResponse
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = true;

        public Response(T data, string message = "Operação realizada com sucesso.")
        {
            Data = data;
            Message = message;
            Success = true;
        }

        public Response(string errorMessage)
        {
            Success = false;
            Message = errorMessage;
            Data = default;
        }
    }
}