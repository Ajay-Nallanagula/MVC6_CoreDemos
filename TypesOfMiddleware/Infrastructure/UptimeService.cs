using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TypesOfMiddleware.Infrastructure
{
    public class UptimeService
    {

        /// <summary>
        /// The stopwatch
        /// </summary>
        private readonly Stopwatch stopwatch;

        /// <summary>
        /// Initializes a new instance of the <see cref="UptimeService"/> class.
        /// </summary>
        public UptimeService()
        {
            stopwatch = Stopwatch.StartNew();
        }

        public long Uptime() => stopwatch.ElapsedMilliseconds;
    }
}
