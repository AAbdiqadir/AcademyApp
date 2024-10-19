namespace Bckend.errors;

public class ApiException(int statusCode, string message, string? detail)
{
    public string Message { get; set; } = message;
    public int StatusCode { get; set; } = statusCode;
    public string? Detail { get; set; } = detail;
    
}