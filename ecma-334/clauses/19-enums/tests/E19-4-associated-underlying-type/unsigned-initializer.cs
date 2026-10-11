/*
Rules: E19-4-associated-underlying-type; E19-4-initializer-member-type
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Shifted = High >> 1
Into: Shifted = High << 1
*/
using System;
enum Code : uint { High = 0x80000000U, Shifted = High >> 1 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((uint)Code.High == 0x80000000U, "associated-uint-value");
        Check((uint)Code.Shifted == 0x40000000U, "initializer-uses-unsigned-underlying-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
