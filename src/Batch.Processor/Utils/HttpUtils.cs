using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Batch.Processor.Utils
{
    public static class HttpUtils
    {
        public static HttpClient AddHeaders(this HttpClient client, IDictionary<string, string> customHeaders)
        {
            foreach (var header in customHeaders)
                if (!client.DefaultRequestHeaders.Contains(header.Key))
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
            return client;
        }

        public static HttpMethod GetHttpMethod(string incomingMethod)
        {
            return new HttpMethod(incomingMethod.ToUpper());
        }
    }
}
