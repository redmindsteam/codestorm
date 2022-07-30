using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStorm.Core.Helpers
{
    public class MemoryHelper
    {
        ushort TotalMemoryUsage;
        private static bool isAvtive = true;
        public static void Start(int processId, ushort memoryLimit)
        {
            isAvtive = true;
            Thread thread = new Thread(x => ControlMemoryUsage(processId, memoryLimit));
            thread.Start();
        }

        public static void Stop()
        {
            if (isAvtive) isAvtive = false; 
        }
        private static void ControlMemoryUsage(int processId, ushort memoryLimit)
        {
            try
            {
                while (isAvtive)
                {
                    Process process = Process.GetProcessById(processId);
                    long currentMemory = process.PrivateMemorySize64;

                }
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
            }
        }
    }
}
