/*
Rules: E8-2-2-class-static-constructor-members
Authority: ECMA-334 7th ed 8.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Ready = 22;
Into: Ready = 23;
*/
using System;
class Device { public static int Ready; static Device() { Ready = 22; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Device.Ready == 22, "class-static-constructor-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
