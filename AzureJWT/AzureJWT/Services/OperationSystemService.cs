using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

namespace AzureJWT.Services
{
    internal static class OperationSystemService
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool GetUserName(
        [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpBuffer,
        ref int nSize);

        internal static string GetCurrentUserName()
        {
            StringBuilder buffer = new StringBuilder(1024);
            int bufferSize = buffer.Capacity;
            if (GetUserName(buffer, ref bufferSize) && IsCurrentUserAuthenticated())
            {
                return buffer.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        private static bool IsCurrentUserAuthenticated()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();

            if (identity.IsAuthenticated)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
