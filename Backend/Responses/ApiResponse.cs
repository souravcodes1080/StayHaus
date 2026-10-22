namespace Backend.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }       
        public int? StatusCode { get; set; }        
        public string? Details  { get; set; }   

        public ApiResponse(bool success, string message, T? data)
        {
            Success = success;
            Message = message;
            Data = data;
            StatusCode = 200; 

        }    
        public ApiResponse(int statusCode, string message, string? details = null)
        {
            Success = false;
            Message = message;
            StatusCode = statusCode; 
            Details = details;
        }    
    }
}