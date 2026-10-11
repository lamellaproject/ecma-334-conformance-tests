/*
Rules: E11-1-switch-input; E11-1-switch-context; E11-2-1-grammar-pattern-2
Authority: ECMA-334 7th ed 11.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: case 29:
Into: case 30:
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int calls;
    static int Next() { calls++; return 29; }
    static void Main()
    {
        int answer = -1;
        switch (Next()) { case 29: answer = 1; break; default: answer = 2; break; }
        Check(answer == 1, "switch-input-value");
        Check(calls == 1, "switch-input-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
