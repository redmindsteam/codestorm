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
                catch (ArgumentException)
                {
                    // Process already exited.
                }

                if (processCollection != null)
                {
                    foreach (ManagementObject mo in processCollection)
                    {
                        KillAllProcessHierarchy(Convert.ToInt32(mo["ProcessID"]));
                        //kill child processes(also kills childrens of childrens etc.)
                    }
                }
            }
            else if (OperatingSystem.IsLinux())
            {
                try
                {
                    Process proc = Process.GetProcessById(processId);
                    if (!proc.HasExited) proc.Kill();
                }
                catch (ArgumentException)
                {
                    // Process already exited.
                }
            }
            else throw new Exception("KillAllProcessHierarchy doesn't impliment for other operation system");
        }
    }
}
