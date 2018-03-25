using System;
using System.Collections.Generic;
using System.Text;

namespace Batch.Processor.Models
{
    public class Response
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public object Body { get; set; }

    }
}
