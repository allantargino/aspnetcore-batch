using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Batch.Processor.Models
{
    [DebuggerDisplay("{Id}: {Status}")]
    public class Response
    {
        public string Id { get; set; }
        public string Status { get; set; } 
        public object Body { get; set; }

    }
}
