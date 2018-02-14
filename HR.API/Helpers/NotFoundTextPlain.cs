using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace HR.API
{
    public class NotFoundTextPlain : IHttpActionResult
    {
        public string Message { get; private set; }
        public HttpRequestMessage Request { get; private set; }

        public NotFoundTextPlain(string message, HttpRequestMessage request)
        {
            Message = message ?? throw new ArgumentNullException("message");
            Request = request ?? throw new ArgumentNullException("request");
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        public HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(Message), // Put the message in the response body (text/plain content).
                RequestMessage = Request
            };
            return response;
        }
    }

    public static class ApiControllerExtensions
    {
        public static NotFoundTextPlain NotFound(this ApiController controller, string message)
        {
            return new NotFoundTextPlain(message, controller.Request);
        }
    }
}