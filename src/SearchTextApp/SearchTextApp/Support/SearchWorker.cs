using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchTextApp.Support
{
    public class SearchWorker
    {
        public SearchWorkerState State { get; set; }

        public string Message { get; set; }

        public string DisplayText { get; set; }

        public long TotalCount { get; set; }

        public long Current { get; set; }

        public string Path { get; set; }

        public long HitCount { get; set; }

        public bool Hit { get; set; }

        public Exception Exception { get; set; }
    }
}
