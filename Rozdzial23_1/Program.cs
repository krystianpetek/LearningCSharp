// CHAPTER 23: Platform Interoperability and Unsafe Code

using System.Runtime.InteropServices;
namespace Rozdzial23_1
{
    #region Declaring an External Method
    class VirtualMemoryManager
    {
        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetCurrentProcess();

        #region Declaring the VirtualAllocEx() API in C#
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(
            IntPtr hProcess,
            IntPtr lpAddress,
            IntPtr dwSize,
            AllocationType flAllocationType,
            uint flProtect);
        #endregion

        #region using ref and out RATHER than pointers
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool VirtualProtectEx(
            IntPtr hProcess,
            IntPtr lpAddress,
            IntPtr dwSize,
            uint flNewProtect,
            ref uint lpflOldProtect);
        #endregion
    }
    #endregion

    #region Declaring Types from Unmanaged Structs
    [StructLayout(LayoutKind.Sequential)]
    struct ColorRef
    {
        public byte Red;
        public byte Green;
        public byte Blue;

#pragma warning disable 414
        private readonly byte Unused;
#pragma warning restore 414;

        public ColorRef(byte red, byte green, byte blue)
        {
            Blue = blue;
            Green = green;
            Red = red;
            Unused = 0;
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}