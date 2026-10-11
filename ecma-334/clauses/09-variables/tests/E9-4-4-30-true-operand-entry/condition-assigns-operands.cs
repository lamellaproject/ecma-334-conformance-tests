/*
Rules: E9-4-4-30-true-operand-entry; E9-4-4-30-false-operand-entry
Authority: ECMA-334 7th ed 9.4.4.30
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (cell = source) > 0
Into: source > 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(int source) { int cell; return (cell = source) > 0 ? cell : cell; }
    static void Main()
    {
        Check(Read(18) == 18, "condition-assignment-in-true-operand");
        Check(Read(-23) == -23, "condition-assignment-in-false-operand");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
