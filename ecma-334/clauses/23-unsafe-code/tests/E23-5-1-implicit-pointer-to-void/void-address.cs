/*
Rules: E23-5-1-implicit-pointer-to-void; E23-5-1-pointer-conversion-address
Authority: ECMA-334 7th ed 23.5.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: void* address = typed;
Into: void* address = &other;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 59, other = 3;
        int* typed = &value;
        void* address = typed;
        Check(address == (void*)typed, "implicit-void-address");
        byte* bytes = (byte*)address;
        Check((void*)bytes == address, "explicit-byte-address");
        int* restored = (int*)bytes;
        Check(restored == typed && *restored == 59, "typed-roundtrip");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
