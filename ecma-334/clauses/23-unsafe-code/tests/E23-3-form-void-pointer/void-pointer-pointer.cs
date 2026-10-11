/*
Rules: E23-3-form-void-pointer; E23-3-void-pointer
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: raw = &value;
Into: raw = null;
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
            void* raw = null;
            void** indirect = &raw;
            int value = 59;
            raw = &value;
            Check((int*)*indirect == &value, "unknown-referent-and-void-pointer-pointer");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
