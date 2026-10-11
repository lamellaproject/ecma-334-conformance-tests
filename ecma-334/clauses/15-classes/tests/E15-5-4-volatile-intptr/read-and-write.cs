/*
Rules: E15-5-4-volatile-intptr
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile IntPtr Address;
Into: public volatile IntPtr Other;
*/
using System;
class Holder { public volatile IntPtr Address; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Address = new IntPtr(107);
        Check((long)value.Address == 107L, "volatile-intptr-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
