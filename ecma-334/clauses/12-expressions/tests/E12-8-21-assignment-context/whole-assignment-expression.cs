/*
Rules: E12-8-21-assignment-context; E12-8-21-whole-expression
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: values = stackalloc int[2];
Into: values = default(Span<int>);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Span<int> values = stackalloc int[1];
        values = stackalloc int[2];
        Check(values.Length == 2, "stackalloc-assignment-length");
        if (values.Length == 2) { values[0] = 13; values[1] = 29; }
        Check(values.Length == 2 && values[0] == 13 && values[1] == 29, "assigned-span-memory");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
