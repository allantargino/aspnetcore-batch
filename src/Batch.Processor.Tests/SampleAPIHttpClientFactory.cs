using Batch.Processor.Interfaces;
using Batch.Processor.Utils;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net.Http;

namespace Batch.Processor.Tests
{
    public class SampleAPIHttpClientFactory : IBatchClientFactory
    {
        private readonly WebApplicationFactory<SampleAPI.Startup> _factory;
        private readonly IDictionary<string, string> _globalHeaders;

        public SampleAPIHttpClientFactory(WebApplicationFactory<SampleAPI.Startup> factory, IDictionary<string, string> globalHeaders)
        {
            this._globalHeaders = globalHeaders;
            this._factory = factory;
        }

        public HttpClient CreateClient()
        {
            if (_globalHeaders == null)
                return _factory.CreateClient();
            return _factory.CreateClient().AddHeaders(_globalHeaders);
        }

        public HttpClient CreateClient(IDictionary<string, string> customHeaders)
        {
            if (customHeaders == null)
                return CreateClient();
            return CreateClient().AddHeaders(customHeaders);
        }
    }
}
