/*
Rules: E15-5-4-volatile-uintptr
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile UIntPtr Address;
Into: public volatile UIntPtr Other;
*/
using System;
class Holder { public volatile UIntPtr Address; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Address = new UIntPtr(109u);
        Check((ulong)value.Address == 109UL, "volatile-uintptr-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
