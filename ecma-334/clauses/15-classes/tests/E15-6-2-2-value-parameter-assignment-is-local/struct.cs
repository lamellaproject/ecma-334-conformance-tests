/*
Rules: E15-6-2-2-value-parameter-assignment-is-local; E15-6-2-2-value-parameter-initial-value
Authority: ECMA-334 7th ed 15.6.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static int Edit(Cell value)
Into: static int Edit(ref Cell value)
*/
using System;
struct Cell { public int Value; }
class Program
{
    static int Edit(Cell value) { int prior = value.Value; value.Value = 23; return prior; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell original = new Cell();
        original.Value = 7;
        Check(Edit(original) == 7, "struct-value-parameter-starts-as-argument-copy");
        Check(original.Value == 7, "struct-parameter-field-assignment-affects-local-copy");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
