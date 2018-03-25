using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Batch.Processor
{
    public class HttpMethodNotAllowed : HttpMethod
    {
        private static string MethodName => "NotAllowed";

        public HttpMethodNotAllowed() : base(MethodName)
        {
        }
    }
}
