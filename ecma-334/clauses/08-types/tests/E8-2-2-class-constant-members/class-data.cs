/*
Rules: E8-2-2-class-constant-members; E8-2-2-class-field-members; E8-2-2-class-method-members; E8-2-2-class-instance-constructor-members; E8-2-2-class-instance-creation
Authority: ECMA-334 7th ed 8.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Value = seed;
Into: Value = seed + 1;
*/
using System;
class Device { public const int Bias = 31; public int Value; public Device(int seed) { Value = seed; } public int Read() { return Value + Bias; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Device device = new Device(7);
        Check(device.Read() == 38, "class-data-and-function-members");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
