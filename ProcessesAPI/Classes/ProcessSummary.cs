using System;
using System.Diagnostics;

namespace WebserviceTest.Classes
{
    /// <summary>
    /// Summary of a <code>System.Diagnostics.Process</code> object
    /// </summary>
    public class ProcessSummary
    {
        public int Id { get; }
        public string Name { get; }
        /// <summary>
        /// Working set memory in megabytes
        /// </summary>
        public double WorkingSet { get; }

        /// <summary>
        /// Creates a process summary from a <code>System.Diagnostics.Process</code>
        /// </summary>
        public ProcessSummary(Process process)
        {
            if (process == null)
                throw new ArgumentNullException(nameof(process));

            Id = process.Id;
            Name = process.ProcessName;
            WorkingSet = process.WorkingSet64 / 1024d / 1024d;
        }
    }
}
