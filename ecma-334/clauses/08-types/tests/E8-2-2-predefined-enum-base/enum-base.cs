/*
Rules: E8-2-2-predefined-enum-base
Authority: ECMA-334 7th ed 8.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Enum boxed = Mode.Active;
Into: Enum boxed = Mode.Idle;
*/
using System;
enum Mode { Idle, Active }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Enum boxed = Mode.Active;
        Check((Mode)boxed == Mode.Active, "predefined-enum-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
