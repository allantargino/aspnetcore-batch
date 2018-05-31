using System;
using System.Collections.Generic;
using System.Text;

namespace Batch.Processor.Models
{
    public class BatchResponse
    {
        public IEnumerable<Response> Responses { get; set; }

    }
}
