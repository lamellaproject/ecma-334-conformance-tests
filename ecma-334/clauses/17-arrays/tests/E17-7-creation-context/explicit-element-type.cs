/*
Rules: E17-7-creation-context; E17-7-explicit-type; E17-7-expression-form
Authority: ECMA-334 7th ed 17.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new long[] { Seed() + 2, 17 }
Into: new long[2]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Seed() { return 9; }
    static void Main()
    {
        long[] values = new long[] { Seed() + 2, 17 };
        Check(values.Length == 2, "explicit-initializer-length");
        Check(values[0] == 11 && values[1] == 17, "explicit-type-expression-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
