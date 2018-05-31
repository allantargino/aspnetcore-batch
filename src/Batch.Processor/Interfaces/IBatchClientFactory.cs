using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Batch.Processor.Interfaces
{
    public interface IBatchClientFactory
    {
        HttpClient CreateClient();
        HttpClient CreateClient(IDictionary<string,string> customHeaders);
    }
}
