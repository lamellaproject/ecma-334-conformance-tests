/*
Rules: E9-4-4-4-expression-entry; E9-4-4-4-expression-exit
Authority: ECMA-334 7th ed 9.4.4.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Fill(out cell);
Into: Ignore();
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Fill(out int value) { value = 73; }
    static void Ignore() { }
    static void Main()
    {
        int cell;
        Fill(out cell);
        Check(cell == 73, "expression-exit-assigns-statement-exit");
        cell += 5;
        Check(cell == 78, "statement-entry-supplies-expression-entry");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
