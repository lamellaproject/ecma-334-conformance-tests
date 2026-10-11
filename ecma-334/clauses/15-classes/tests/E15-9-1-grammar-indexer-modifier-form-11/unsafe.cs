/*
Rules: E15-9-1-grammar-indexer-modifier-form-11
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public unsafe int this[int index]
Into: public int this[int index]
*/
using System;
class Grid { public unsafe int this[int index] { get { int local = index + 4; int* pointer = &local; return *pointer; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Grid()[7] == 11, "unsafe-indexer-get-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
