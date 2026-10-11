/*
Rules: E8-4-3-closed-type-own-statics
Authority: ECMA-334 7th ed 8.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Slot<string>.Value = 27;
Into: Slot<int>.Value = 27;
*/
using System;
class Slot<T> { public static int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Slot<int>.Value = 13; Slot<string>.Value = 27;
        Check(Slot<int>.Value == 13 && Slot<string>.Value == 27, "closed-types-own-separate-statics");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
