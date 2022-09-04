using System.Runtime.InteropServices;
using System.Text;

namespace Rozdzial23_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                // To retrieve the address of a movable data item, it is necessary to fix, or pin, the data
                byte[] bytes = new byte[24];
                fixed (byte* pData = &bytes[0])
                {
                    //
                }

                fixed (byte* pData = bytes)
                {
                    //
                }

                byte* bytesStack = stackalloc byte[24]; // allocating data on the call stack

                #region Modifying an immutable string LOW-LEVEL MEMORY MANIPULATION
                string text = "S5280ft";
                Console.Write($"{text} = ");

                unsafe
                {
                    fixed (char* pText = text)
                    {
                        char* p = pText;
                        *++p = 'm';
                        *++p = 'i';
                        *++p = 'l';
                        *++p = 'e';
                        *++p = ' ';
                        *++p = ' ';
                    }


                }
                Console.WriteLine(text);
                #endregion

                #region Directly Accessing a Referent Type’s Members
                unsafe
                {
                    Angle angle = new Angle(30, 18, 0);
                    //Angle* pAngle = &angle;
                    //System.Console.WriteLine("{0}° {1}' {2}\"",
                    //pAngle->Hours, pAngle->Minutes, pAngle->Seconds);
                }
                #endregion
            }
        }
        #region Designating a block for Unsafe code
        public unsafe delegate void MethodInvoker(byte* buffer);
        public unsafe static int ChapterMain()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                unsafe
                {
                    byte[] codeBytes = new byte[]
                    {
                        0x49, 0x89, 0xd8, // mov %rbx, %r8
                        0x49, 0x89, 0xc9, // mov %rcx, %r9
                        0x48, 0x31, 0xc0, // xor %rax, %rax
                        0x0f, 0xa2,       // cpuid
                        0x4c, 0x89, 0xc8, // mov %r9,%rax
                        0x89, 0x18,       // mov %ebx,0x0(%rax)
                        0x89, 0x50, 0x04, // mov %edx,0x4(%rax)
                        0x89, 0x48, 0x08, // mov %ecx,0x8(%rax)
                        0x4c, 0x89, 0xc3, // mov %r8,%rbx
                        0xc3              // retq
                    };

                    byte[] buffer = new byte[12];
                    using (VirtualMemoryPtr codeBytesPtr = new(codeBytes.Length))
                    {
                        Marshal.Copy(codeBytes, 0, codeBytesPtr, codeBytes.Length);

                        MethodInvoker method = Marshal.GetDelegateForFunctionPointer<MethodInvoker>(codeBytesPtr);
                        fixed (byte* newBuffer = &buffer[0])
                        {
                            method(newBuffer);
                        }
                    }
                    Console.Write("Processor Id:");
                    Console.WriteLine(ASCIIEncoding.ASCII.GetChars(buffer));
                }
            }
            else
            {
                Console.WriteLine("This sample is only valid for Windows");
            }
            return 0;
        }
        #endregion

        private static unsafe int Result() // unsafe method
        {
            return 1 + 1;
        }
    }
}