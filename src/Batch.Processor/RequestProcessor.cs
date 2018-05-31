using Batch.Processor.Interfaces;
using Batch.Processor.Models;
using Batch.Processor.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Batch.Processor
{
    public class RequestProcessor
    {
        private readonly IBatchClientFactory _httpFactory;

        public RequestProcessor(IBatchClientFactory httpFactory)
        {
            this._httpFactory = httpFactory;
        }

        public async Task<IEnumerable<Response>> Process(IEnumerable<Request> requests)
        {
            var responses = new List<Response>();
            foreach (var request in requests)
            {
                var url = request.Service;
                var method = HttpUtils.GetHttpMethod(request.Method);

                var message = new HttpRequestMessage(method, url);

                try
                {
                    using (var client = _httpFactory.CreateClient(request.Headers))
                    {
                        var res = await client.SendAsync(message);
                        res.EnsureSuccessStatusCode();
                        responses.Add(new Response() { Id = request.Id, Status = "Success", Body = await res.Content.ReadAsStringAsync() });
                    }
                }
                catch (Exception ex)
                {
                    responses.Add(new Response() { Id = request.Id, Status = "Failed", Body = ex.ToString()});
                }
            }

            return responses;
        }
    }
}
