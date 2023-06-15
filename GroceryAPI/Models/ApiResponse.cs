using System.Net;

namespace GroceryAPI.Models
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Message = new();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Message { get; set; }
        public object Result { get; set; }
    }
}
