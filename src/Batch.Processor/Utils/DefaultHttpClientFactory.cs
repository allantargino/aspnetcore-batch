using Batch.Processor.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Batch.Processor.Utils
{
    public class DefaultHttpClientFactory : IBatchClientFactory
    {
        private readonly IDictionary<string, string> _globalHeaders;

        public DefaultHttpClientFactory(IDictionary<string, string> globalHeaders)
        {
            this._globalHeaders = globalHeaders;
        }

        public HttpClient CreateClient()
        {
            return new HttpClient().AddHeaders(_globalHeaders);
        }

        public HttpClient CreateClient(IDictionary<string, string> customHeaders)
        {
            if (customHeaders == null)
                return CreateClient();
            return CreateClient().AddHeaders(customHeaders);
        }
    }
}
