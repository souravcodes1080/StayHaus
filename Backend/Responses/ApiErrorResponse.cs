namespace Backend.Responses
{
    public class ApiErrorResponse(int statusCode, string message, string? details = null)
    {
        public bool Success { get; set; } = false;
        public string Message{ get; set; } = message;
        public int StatusCode{ get; set; } = statusCode;
        public string? Details{ get; set; } = details;
    }
}