/*
Rules: E17-3-local-creation; E17-7-local-context; E17-7-declaration-type; E17-7-declaration-shorthand; E17-7-initializer-list-form; E17-7-expression-form
Authority: ECMA-334 7th ed 17.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: short[] values = { 7, 18 }
Into: short[] values = new short[2]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        short[] values = { 7, 18 };
        short[] equivalent = new short[] { 7, 18 };
        Check(values.Length == 2, "local-creates-array");
        Check(values[0] == equivalent[0] && values[1] == equivalent[1], "declared-element-type");
        Check(values != equivalent, "fresh-array");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
