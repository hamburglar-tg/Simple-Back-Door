using System.Runtime.InteropServices;

namespace UserInfo
{
    internal class Info
    {
        public string? OS { get; private set; }
        public string? tgFolderPath { get; private set; }

        public Info()
        {
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            bool isOSX = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

            if (isWindows) { OS = "Windows"; }
            else if (isOSX) { OS = "OSX"; }
            else if (isLinux) { OS = "Linux"; }
        }
    }
}
