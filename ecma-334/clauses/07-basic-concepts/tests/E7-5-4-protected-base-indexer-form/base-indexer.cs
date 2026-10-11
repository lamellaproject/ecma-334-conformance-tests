/*
Rules: E7-5-4-protected-base-indexer-form
Authority: ECMA-334 7th ed 7.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected int this[int index]
Into: private int this[int index]
*/
using System;
class Root { protected int this[int index] { get { return index + 113; } } }
class Branch : Root { public int Read(int index) { return base[index]; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Branch().Read(5) == 118, "protected-base-indexer-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
