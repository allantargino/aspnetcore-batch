using Batch.Processor.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Batch.Processor
{
    public class ParallelWorker
    {
        public IEnumerable<Response> Process(IEnumerable<Request> requests)
        {
            var responses = new List<Response>();
            foreach (var request in requests)
            {
                string url = request.Service;
                var method = GetHttpMethod(request.Method);

                using (var client = new HttpClient())
                {
                }

                responses.Add(new Response() {Id = request.Id, Status = "Success" });
            }

            return responses;
        }

        public HttpMethod GetHttpMethod(string incomingMethod)
        {
            var method = incomingMethod.ToUpper();
            switch (method)
            {
                case "DELETE":
                    return HttpMethod.Delete;
                case "GET":
                    return HttpMethod.Get;
                case "POST":
                    return HttpMethod.Post;
                case "PUT":
                    return HttpMethod.Put;
                default:
                    return new HttpMethod(method);
            }
        }
    }
}
