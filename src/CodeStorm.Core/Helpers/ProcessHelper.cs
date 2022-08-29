using CodeStorm.Domain.Exceptions;
using System.Diagnostics;
using System.Management;

namespace CodeStorm.Core.Helpers
{
    internal class ProcessHelper
    {
        public static void KillAllProcessHierarchy(int processId)
        {
            if (OperatingSystem.IsWindows())
            {
                ManagementObjectSearcher processSearcher = new ManagementObjectSearcher
                ("Select * From Win32_Process Where ParentProcessID=" + processId);
                ManagementObjectCollection processCollection = processSearcher.Get();

                try
                {
                    Process proc = Process.GetProcessById(processId);
                    if (!proc.HasExited) proc.Kill();
                }
                catch (ArgumentException exception)
                {
                    //throw new SpecificSystemException("ProcessHelper", "There is an errer with ProcessHelper to killAllProcessHierarchy", exception);
                }

                if (processCollection is not null)
                {
                    foreach (ManagementObject mo in processCollection)
                        KillAllProcessHierarchy(Convert.ToInt32(mo["ProcessID"]));
                }
            }
            else if (OperatingSystem.IsLinux())
            {
                try
                {
                    Process proc = Process.GetProcessById(processId);
                    if (!proc.HasExited) proc.Kill();
                }
                catch (ArgumentException exception)
                {
                    throw new SpecificSystemException("ProcessHelper", "There is an errer with ProcessHelper to killAllProcessHierarchy", exception);
                }
            }
            else throw new NotImplementedException("KillAllProcessHierarchy doesn't impliment for other operation system");
        }
    }
} 
