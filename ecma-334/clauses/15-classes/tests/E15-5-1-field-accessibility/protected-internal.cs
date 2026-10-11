/*
Rules: E15-5-1-field-accessibility
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: protected internal int Code = 811;
Into: private int Code = 811;
*/
using System;
class Basis { protected internal int Code = 811; }
class Leaf : Basis { public int Read() { return Code; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf value = new Leaf();
        Check(value.Code == 811, "protected-internal-field-in-program");
        Check(value.Read() == 811, "protected-internal-field-in-derived-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
