/*
Rules: E15-6-2-3-input-implementation-variable; E15-6-2-3-input-expression-argument; E15-6-2-3-input-definitely-assigned
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: static int Read(in int value)
Into: static int Read(ref int value)
*/
using System;
class Program
{
    static int Calls;
    static int Next() { Calls++; return 7; }
    static int Read(in int value) { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read(Next() + 4) == 11, "input-reference-to-initialized-expression-temporary");
        Check(Calls == 1, "input-expression-evaluated-once");
        byte value = 17;
        Check(Read(value) == 17, "implicit-conversion-initializes-input-temporary");
        Check(Read(23) == 23, "literal-input-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
