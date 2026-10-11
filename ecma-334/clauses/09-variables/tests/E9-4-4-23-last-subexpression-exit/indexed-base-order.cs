/*
Rules: E9-4-4-23-last-subexpression-exit; E9-4-4-23-embedded-expression-scope; E9-4-4-23-later-subexpression-entry
Authority: ECMA-334 7th ed 9.4.4.23
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: base[cell = 2, cell + 3]
Into: base[2, cell + 3]
*/
using System;
class Parent { protected int this[int a, int b] { get { return a * 10 + b; } } }
class Program : Parent
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    void Probe()
    {
        int cell;
        int result = base[cell = 2, cell + 3];
        Check(result == 25 && cell == 2, "indexed-base-arguments-transfer");
    }
    static void Main()
    {
        new Program().Probe();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
