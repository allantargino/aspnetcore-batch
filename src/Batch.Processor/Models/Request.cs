using System;
using System.Collections.Generic;
using System.Text;

namespace Batch.Processor.Models
{
    public class Request
    {
        public string Id { get; set; }
        public string Method { get; set; }
        public string Service { get; set; }
        public object Body { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public IEnumerable<string> DependsOn { get; set; }


        public Request(string id, string method, string service)
            : this(id, method, service, null, new Dictionary<string, string>(), new List<string>())
        {
        }

        public Request(string id, string method, string service, IEnumerable<string> dependsOn)
            : this(id, method, service, null, new Dictionary<string, string>(), dependsOn)
        {
        }

        public Request(string id, string method, string service, object body, IDictionary<string, string> headers, IEnumerable<string> dependsOn)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException(nameof(id));
            if (string.IsNullOrWhiteSpace(method)) throw new ArgumentException(nameof(method));
            if (string.IsNullOrWhiteSpace(service)) throw new ArgumentException(nameof(service));

            Id = id;
            Method = method;
            Service = service;
            Body = body;
            Headers = headers;
            DependsOn = dependsOn;
        }
    }
}
