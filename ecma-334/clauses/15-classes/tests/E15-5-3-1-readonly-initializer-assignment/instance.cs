/*
Rules: E15-5-3-1-readonly-initializer-assignment; E15-5-3-1-readonly-classification
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public readonly int Code = 39;
Into: public readonly int Code;
*/
using System;
class Holder { public readonly int Code = 39; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Code == 39, "instance-readonly-declarator-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
