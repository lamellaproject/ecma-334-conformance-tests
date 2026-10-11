/*
Rules: E9-4-4-24-output-argument-exit-assigned
Authority: ECMA-334 7th ed 9.4.4.24
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Holder(out cell);
Into: new Holder(out _);
*/
using System;
class Holder { public Holder(out int value) { value = 64; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        new Holder(out cell);
        Check(cell == 64, "constructor-output-assigned-after-creation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
