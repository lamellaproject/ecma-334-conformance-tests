/*
Rules: E8-8-unmanaged-enum
Authority: ECMA-334 7th ed 8.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Mode value = Mode.Ready;
Into: Mode value = Mode.Idle;
*/
using System;
enum Mode : short { Idle, Ready = 7 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe short Read() { Mode value = Mode.Ready; Mode* pointer = &value; return (short)*pointer; }
    static void Main()
    {
        Check(Read() == 7, "enum-unmanaged-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
