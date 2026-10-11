/*
Rules: E15-5-3-1-readonly-initializer-assignment; E15-5-3-1-readonly-classification
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public static readonly int Code = 43;
Into: public static readonly int Code;
*/
using System;
class Holder { public static readonly int Code = 43; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.Code == 43, "static-readonly-declarator-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
