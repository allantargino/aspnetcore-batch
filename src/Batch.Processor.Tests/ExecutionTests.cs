using Batch.Processor.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Batch.Processor.Tests
{
    public class ExecutionTests: IClassFixture<WebApplicationFactory<SampleAPI.Startup>>
    {
        private readonly WebApplicationFactory<SampleAPI.Startup> _Samplefactory;

        public ExecutionTests(WebApplicationFactory<SampleAPI.Startup> factory)
        {
            _Samplefactory = factory;
        }

        private static BatchRequest GenerateSampleDataWithFail()
        {
            return new BatchRequest()
            {
                Headers = new Dictionary<string, string>(),
                Requests = new List<Request>()
                {
                    new Request("1", "GET", "/api/values"),
                    new Request("2", "GET", "/api/nonexist"),
                    new Request("3", "GET", "/api/values", new string[]{ "2" }),
                    new Request("4", "POST", "/api/values", new string[]{ "3" }),
                    new Request("5", "POST", "/api/values", new string[]{ "1" })
                }
            };
        }

        private static BatchRequest GenerateSampleData()
        {
            return new BatchRequest()
            {
                Headers = new Dictionary<string, string>(),
                Requests = new List<Request>()
                {
                    new Request("1", "GET", "/api/values"),
                    new Request("2", "GET", "/api/values", new string[]{ "1" }),
                    new Request("3", "POST", "/api/values", new string[]{ "2" }),
                    new Request("4", "POST", "/api/values", new string[]{ "1" })
                }
            };
        }

        [Fact]
        public async Task VerifyResponsesCount()
        {
            BatchRequest batchRequest = GenerateSampleData();

            var responses = await GetExecutor(batchRequest).Execute(batchRequest);

            Assert.Equal(batchRequest.Requests.Count(), responses.Responses.Count());
        }

        [Fact]
        public async Task VerifyResponsesCountWithFail()
        {
            BatchRequest batchRequest = GenerateSampleDataWithFail();

            var responses = await GetExecutor(batchRequest).Execute(batchRequest);

            Assert.Equal(batchRequest.Requests.Count(), responses.Responses.Count());
        }

        private ExecutionPlanner GetExecutor(BatchRequest batchRequest)
        {
            var factory = new SampleAPIHttpClientFactory(_Samplefactory, batchRequest.Headers);
            var processor = new RequestProcessor(factory);
            var executor = new ExecutionPlanner(processor);
            return executor;
        }
    }
}
