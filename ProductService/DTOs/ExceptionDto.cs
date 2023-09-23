using System.Net;

namespace ProductService.DTOs
{
    public class ExceptionDto
    {
        public HttpStatusCode statusCode { get; set; }
        public string message { get; set; }

        public ExceptionDto(HttpStatusCode status,string message)
        {
            this.statusCode=status;
            this.message=message;
        }
    }
}
