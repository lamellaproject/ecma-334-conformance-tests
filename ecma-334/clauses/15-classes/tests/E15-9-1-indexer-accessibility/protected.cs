/*
Rules: E15-9-1-indexer-accessibility; E15-9-1-grammar-indexer-modifier-form-3
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected int this[int index]
Into: private int this[int index]
*/
using System;
class Grid { protected int this[int index] => index + 9; }
class Derived : Grid { public int Read(int index) { return this[index]; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Derived().Read(3) == 12, "protected-indexer-derived-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
