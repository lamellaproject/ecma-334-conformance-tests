/*
Rules: E15-9-1-indexer-accessibility
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private protected int this[int index]
Into: private int this[int index]
*/
using System;
class Grid { private protected int this[int index] => index + 6; }
class Derived : Grid { public int Read() { return this[3]; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Derived().Read() == 9, "private-protected-indexer-derived-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
