using System.Net;

namespace Libre.Connect.Model;
public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public List<string> ErrorMessages { get; set; } = new();

    public ApiResponse(T data)
    {
        Success = true;
        Data = data;
        ErrorMessages = new List<string>();
    }
    
    public ApiResponse()
    {
    }
    public static ApiResponse<T> SuccessResponse(T data)
    {
        return new ApiResponse<T>(data);
    }
    public static ApiResponse<T> ErrorResponse(List<string> errorMessages)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Data = default,
            ErrorMessages = errorMessages
        };
    }
    }
