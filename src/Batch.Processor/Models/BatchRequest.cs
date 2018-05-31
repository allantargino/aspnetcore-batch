using System;
using System.Collections.Generic;
using System.Text;

namespace Batch.Processor.Models
{
    public class BatchRequest
    {
        public IDictionary<string,string> Headers { get; set; }
        public IEnumerable<Request> Requests { get; set; }
    }
}
