/*
Rules: E8-2-2-class-property-members
Authority: ECMA-334 7th ed 8.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: stored = value;
Into: stored = value + 1;
*/
using System;
class Device { int stored; public int Value { get { return stored; } set { stored = value; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Device device = new Device(); device.Value = 15;
        Check(device.Value == 15, "class-property-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
