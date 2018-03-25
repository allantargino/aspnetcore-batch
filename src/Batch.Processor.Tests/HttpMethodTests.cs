using System;
using System.Net.Http;
using Xunit;

namespace Batch.Processor.Tests
{
    public class HttpMethodTests
    {
        private readonly ParallelWorker worker;

        public HttpMethodTests()
        {
            worker = new ParallelWorker();
        }

        [Theory]
        [InlineData("GET")]
        [InlineData("get")]
        [InlineData("GeT")]
        public void GetUpper(string method)
        {
            var httpMethod = worker.GetHttpMethod(method);
            Assert.Equal(HttpMethod.Get, httpMethod);
        }
    }
}
