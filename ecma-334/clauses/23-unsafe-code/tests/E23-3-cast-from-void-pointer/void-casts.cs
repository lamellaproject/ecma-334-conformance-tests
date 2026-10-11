/*
Rules: E23-3-cast-from-void-pointer; E23-3-cast-to-void-pointer; E23-3-compare-void-pointer; E23-3-pointer-conversions
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int* q = (int*)raw;
Into: int* q = (int*)((byte*)raw + 1);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            int value = 73;
            int* p = &value;
            void* raw = (void*)p;
            int* q = (int*)raw;
            byte* bytes = (byte*)raw;
            Check(q == p, "void-to-typed-roundtrip");
            Check(raw == p && raw == bytes, "void-and-other-pointer-comparison");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
