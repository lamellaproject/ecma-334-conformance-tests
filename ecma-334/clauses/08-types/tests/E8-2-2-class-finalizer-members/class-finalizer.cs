/*
Rules: E8-2-2-class-finalizer-members
Authority: ECMA-334 7th ed 8.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ~Device() { }
Into: ~Other() { }
*/
using System;
class Device { ~Device() { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Device device = new Device();
        Check(device != null, "class-with-finalizer-created");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
