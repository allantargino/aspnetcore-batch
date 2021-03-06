﻿using Batch.Processor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch.Processor
{
    public class ExecutionPlanner
    {
        private readonly RequestProcessor _processor;

        public ExecutionPlanner(RequestProcessor processor)
        {
            _processor = processor;
        }

        public async Task<BatchResponse> Execute(BatchRequest batchRequest)
        {
            var requests = batchRequest.Requests;

            var responses = await Execute(requests);

            return new BatchResponse()
            {
                Responses = responses
            };
        }

        public async Task<IEnumerable<Response>> Execute(IEnumerable<Request> requests)
        {
            var responses = new List<Response>();

            await Execute(requests.ToList(), responses);

            return responses;
        }

        private async Task Execute(List<Request> remainingRequests, List<Response> responses)
        {
            if (remainingRequests.Count == 0)
                return;

            var requestToExecute = remainingRequests.Where(r => r.DependsOn.Count() == 0);
            if (requestToExecute.Count() == 0 && remainingRequests.Count > 0)
            {
                var notExecuted = remainingRequests.Select(r => new Response() { Id = r.Id, Status = "NotExecuted" }).ToList();
                responses.AddRange(notExecuted); // Not Executed
                return;
            }

            var responseExecutions = await _processor.Process(requestToExecute);

            responses.AddRange(responseExecutions); // Executed (Successed and Failed)

            remainingRequests = RemoveRequests(remainingRequests, requestToExecute);

            var successExecutions = responseExecutions.Where(r => r.Status == "Success").Select(r => r.Id);
            foreach (var r in remainingRequests)
                r.DependsOn = r.DependsOn.Except(successExecutions);

            var failedExecutions = responseExecutions.Where(r => r.Status == "Failed").Select(r => r.Id);
            var failedDependencies = GetAllFailedDependency(remainingRequests, failedExecutions);
            responses.AddRange(failedDependencies.Select(r => new Response() { Id = r.Id, Status = "DependencyFailed" }));

            remainingRequests = RemoveRequests(remainingRequests, failedDependencies);


            await Execute(remainingRequests, responses);
        }

        private IEnumerable<Request> GetAllFailedDependency(List<Request> requests, IEnumerable<string> failedExecutions)
        {
            var failedRequests = new List<Request>();
            foreach (var id in failedExecutions)
                RemoveDependentRequest(requests, failedRequests, id);
            return failedRequests;
        }

        private void RemoveDependentRequest(List<Request> requests, List<Request> failedRequests, string failedId)
        {
            var dependencies = requests.Where(r => r.DependsOn.Contains(failedId));

            failedRequests.AddRange(dependencies);

            foreach (var d in dependencies)
                RemoveDependentRequest(requests, failedRequests, d.Id);
        }

        private static List<Request> RemoveRequests(List<Request> requests, IEnumerable<Request> executedRequests)
        {
            return requests.Except(executedRequests).ToList();
        }
    }
}
