using System;
using System.Collections.Generic;
using System.Text;

namespace Batch.Processor.Models
{
    public class Request
    {
        public string Id { get; set; }
        public string Method { get; set; }
        public string Url { get; set; }
        public object Body { get; set; }
        public Headers Headers { get; set; }
        public IEnumerable<string> DependsOn { get; set; }
    }
}
