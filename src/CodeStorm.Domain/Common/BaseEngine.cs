using System.Diagnostics;

namespace CodeStorm.Domain.Common
{
    public abstract class BaseEngine
    {
        // CMD Info for use cmd.exe in Process
        protected ProcessStartInfo _processInfo;

        /// <summary>
        /// Constructor impliment os type and others 
        /// </summary>
        public BaseEngine()
        {
            if (OperatingSystem.IsWindows())
            {
                _processInfo = new ProcessStartInfo("cmd")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Verb = "runas"
                };
            }
            else if (OperatingSystem.IsLinux())
            {
                _processInfo = new ProcessStartInfo("/bin/bash")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };
            }
            else _processInfo = new ProcessStartInfo();
        }
    }
}
