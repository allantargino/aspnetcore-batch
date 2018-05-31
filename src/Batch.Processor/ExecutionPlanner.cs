using Batch.Processor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Batch.Processor
{
    public class ExecutionPlanner
    {
        private readonly ParallelWorker worker;

        public ExecutionPlanner()
        {
            worker = new ParallelWorker();
        }

        public void Execute(List<Request> remainingRequests, List<Response> responses)
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

            var responseExecutions = worker.Process(requestToExecute);

            responses.AddRange(responseExecutions); // Executed (Successed and Failed)

            remainingRequests = RemoveRequests(remainingRequests, requestToExecute);

            var successExecutions = responseExecutions.Where(r => r.Status == "Success").Select(r => r.Id);
            foreach (var r in remainingRequests)
                r.DependsOn = r.DependsOn.Except(successExecutions);

            var failedExecutions = responseExecutions.Where(r => r.Status == "Failed").Select(r => r.Id);
            var dependentExecution = RemoveAllFailed(remainingRequests, failedExecutions);
            responses.AddRange(dependentExecution);

            Execute(remainingRequests, responses);
        }

        private IEnumerable<Response> RemoveAllFailed(List<Request> requests, IEnumerable<string> failedExecutions)
        {
            var responses = new List<Response>();
            foreach (var id in failedExecutions)
                responses.AddRange(RemoveDependency(requests, id));
            return responses;
        }

        private IEnumerable<Response> RemoveDependency(List<Request> requests, string failedId)
        {
            var dependencies = requests.Where(r => r.DependsOn.Contains(failedId));

            RemoveRequests(requests, dependencies);

            return dependencies.Select(r => new Response() { Id = r.Id, Status = "DependencyFailed" });
        }

        private static List<Request> RemoveRequests(List<Request> requests, IEnumerable<Request> executedRequests)
        {
            return requests.Except(executedRequests).ToList();
        }
    }
}
