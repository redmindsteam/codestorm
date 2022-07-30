using CodeStorm.Core.Helpers;
using System.Diagnostics;

namespace CodeStorm.Core.Analyzers
{
    internal class MemoryAnalyzer
    {
        private uint totalMemoryUsage;
        private bool isSuccessfull = true;
        private static bool isActive = true;
        private readonly uint memoryLimit;
        public uint TotalMemoryUsage { get => totalMemoryUsage; }
        public bool IsSuccessfull { get => isSuccessfull; }
        public MemoryAnalyzer(uint memoryLimit)
        {
            this.memoryLimit = memoryLimit;
        }

        public void Start(int processId)
        {
            isActive = true;
            Thread thread = new Thread(x => ControlMemoryUsage(processId));
            thread.Start();
        }

        public void Stop()
        {
            if (isActive) isActive = false;
        }

        private void ControlMemoryUsage(int processId)
        {
            try
            {
                while (isActive)
                {
                    Process process = Process.GetProcessById(processId);
                    if (!process.HasExited)
                    {
                        long currentMemory = process.PeakWorkingSet64 / 1024;
                        if (currentMemory >= memoryLimit)
                        {
                            isActive = false;
                            isSuccessfull = false;
                            totalMemoryUsage += (ushort) currentMemory;
                            ProcessHelper.KillAllProcessHierarchy(processId);
                        }
                        else
                        {
                            if (currentMemory > totalMemoryUsage)
                                totalMemoryUsage = (uint)currentMemory;
                        }
                    }
                }
            }
            catch { }
        }        
    }
}
