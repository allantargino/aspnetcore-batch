using Batch.Processor.Models;
using System;
using System.Collections.Generic;
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

        [Fact]
        public void Execute()
        {
            var requests = new List<Request>()
            {
                new Request("1", "GET", "serviceA"),
                new Request("2", "GET", "serviceB"),
                new Request("3", "POST", "serviceC", new string[]{ "1" }),
                new Request("4", "POST", "serviceD", new string[]{ "3" }),
                new Request("5", "POST", "serviceD", new string[]{ "10" })
            };

            var executor = new ExecutionPlanner();
            var responses = new List<Response>();
            executor.Execute(requests, responses);
        }
    }
}
