/*
Rules: E8-2-2-class-nested-types
Authority: ECMA-334 7th ed 8.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Part
Into: struct Part
*/
using System;
class Device { public class Part { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Device.Part part = new Device.Part();
        Check(part != null, "class-nested-type-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
